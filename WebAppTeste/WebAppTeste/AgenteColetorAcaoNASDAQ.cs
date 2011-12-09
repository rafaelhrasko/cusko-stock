using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using DOMSharp;

namespace WebAppTeste
{
    public class NASDAQDTO
    {
        public int letter;
        public string render;
        public string exchange;

        public NASDAQDTO(string exchange_)
        {
            exchange = exchange_;
            letter = 0;
            render = "download";
        }

    }

    public class Acao
    {
        public int id;
        public string symbol;
        public string nomeEmpresa;
        public DateTime ultimaVerificacao;

        public Acao(int id_, string symbol_, DateTime ultimaVerificacao_)
        {
            id = id_;
            symbol = symbol_;
            ultimaVerificacao = ultimaVerificacao_;
        }

        public Acao(string symbol_,string nomeEmpresa_)
        {
            symbol = symbol_;
            nomeEmpresa = nomeEmpresa_;
        }
    }

    public class AcaoEquitable : IEqualityComparer<Acao>
    {

        public bool Equals(Acao x, Acao y)
        {
            return x.symbol == y.symbol;
        }

        public int GetHashCode(Acao obj)
        {
            throw new NotImplementedException();
        }
    }

    public class Bolsa
    {
        public string nome;
        public int id;

        public List<Acao> acoes;

        public Bolsa(int id_, string nome_)
        {
            id = id_;
            nome = nome_;
            acoes = new List<Acao>();
        }
    }

    public class AgenteColetorAcaoNASDAQ : Agente
    {
        Bolsa bolsa;
        Queue<AgenteColetorMovimentacaoYQL> agentesColetoresParaAcionar;
        List<AgenteColetorMovimentacaoYQL> agentesAcionados;

        Queue<Acao> acoesParaAdicionar;

        public AgenteColetorAcaoNASDAQ(string nomeBolsa_,int idBolsa_)
            :base("ColetorAcaoNASDAQ")
        {
            bolsa = new Bolsa(idBolsa_, nomeBolsa_);
            agentesAcionados = new List<AgenteColetorMovimentacaoYQL>();
            agentesColetoresParaAcionar = new Queue<AgenteColetorMovimentacaoYQL>();
            acoesParaAdicionar = new Queue<Acao>();

            Log("procurando pelas bolsas conhecidas");
            this.popularBolsas();
            
            this.workerThread.Priority = System.Threading.ThreadPriority.Lowest;
            Log("procurando pelas ações conhecidas");
            this.iniciarAcoesConhecidas();
        }

        private void iniciarAcoesConhecidas()
        {
            AgenteColetorMovimentacaoYQL agente;
            Log("inicializando agentes da bolsa " + bolsa.nome);
            foreach (var acao in bolsa.acoes)
            {
                DateTime ultimaAbertura = DateTime.Now;
                if (ultimaAbertura.Day != acao.ultimaVerificacao.Day)
                {
                    if (ultimaAbertura.DayOfWeek == DayOfWeek.Sunday)
                    {
                        ultimaAbertura.Subtract(TimeSpan.FromDays(2));
                    }
                    else if (ultimaAbertura.DayOfWeek == DayOfWeek.Saturday)
                    {
                        ultimaAbertura.Subtract(TimeSpan.FromDays(1));
                    }
                    if (acao.ultimaVerificacao < ultimaAbertura)
                    {
                        agente = new AgenteColetorMovimentacaoHistoricoYQL(acao.symbol, acao.id, acao.ultimaVerificacao);
                    }
                    else
                    {
                        agente = new AgenteColetorMovimentacaoYQL(acao.symbol, acao.id, acao.ultimaVerificacao);
                    }
                }
                else
                {
                    agente = new AgenteColetorMovimentacaoYQL(acao.symbol, acao.id, acao.ultimaVerificacao);
                }
                agentesColetoresParaAcionar.Enqueue(agente);
            }
        }

        private void popularBolsas()
        {
            Log("procurando por ações conhecidas em " + bolsa.nome);

            using (MySqlConnection connection = new MySqlConnection(connstring))
            {
                try
                {
                    connection.Open();

                    MySqlCommand commandAcao = new MySqlCommand(String.Format("SELECT idAcao,symbol,ultimaVerificacao FROM Acao WHERE Bolsa_idBolsa = {0}", bolsa.id), connection);
                    MySqlDataReader readerAcao = commandAcao.ExecuteReader();
                    while (readerAcao.Read())
                    {
                        bolsa.acoes.Add(new Acao((int)readerAcao[0], (string)readerAcao[1], (DateTime)readerAcao[2]));
                    }
                    readerAcao.Close();
                    //}
                    MySqlConnection.ClearAllPools();
                    connection.Close();
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(e.Message);
                }
            }
        }

        public override void StopThread()
        {
            base.StopThread();
            foreach (var agente in agentesAcionados)
            {
                agente.StopThread();
                agentesColetoresParaAcionar.Enqueue(agente);
            }
            agentesAcionados.Clear();
        }

        protected override void Work()
        {
            if (agentesColetoresParaAcionar.Count > 0)
            {
                AgenteColetorMovimentacaoYQL agente = agentesColetoresParaAcionar.Dequeue();
                agentesAcionados.Add(agente);
                AgenteColetorMovimentacaoYQL.minSleepTime = 3600000 / (3600 / agentesAcionados.Count);
                agente.Start();
                
            }

            if (acoesParaAdicionar.Count > 0)
            {
                this.threadSleepTime = 10000;
                Acao acao = acoesParaAdicionar.Dequeue();
                AgenteColetorMovimentacaoHistoricoYQL agente;
                using (MySqlConnection connection = new MySqlConnection(connstring))
                {
                    try
                    {
                        connection.Open();
                        MySqlCommand insertAcao = new MySqlCommand(String.Format("INSERT INTO Acao (symbol,ultimaVerificacao,nomeEmpresa,Bolsa_idBolsa) VALUES ('{0}',{1},'{2}',{3})", acao.symbol, "19700101000001", acao.nomeEmpresa, bolsa.id), connection);
                        insertAcao.ExecuteNonQuery();
                        MySqlCommand commandAcao = new MySqlCommand(String.Format("SELECT idAcao,ultimaVerificacao FROM Acao WHERE symbol = '{0}'", acao.symbol), connection);
                        MySqlDataReader readerAcao = commandAcao.ExecuteReader();
                        if (readerAcao.Read())
                        {
                            acao.id = (int)readerAcao[0];
                            acao.ultimaVerificacao = (DateTime)readerAcao[1];
                            bolsa.acoes.Add(acao);

                            agente = new AgenteColetorMovimentacaoHistoricoYQL(acao.symbol, acao.id, acao.ultimaVerificacao);
                            
                            Log("Colocando agente para acionar para a nova acao " + acao.symbol);                            
                            agentesColetoresParaAcionar.Enqueue(agente);
                        }
                        readerAcao.Close();
                        MySqlConnection.ClearAllPools();
                        connection.Close();
                    }
                    catch (Exception e)
                    {
                        Log(e.Message);
                    }
                }
            }
            else
            {
                Log("procurando por novas ações em " + bolsa.nome);
                NASDAQDTO dto = new NASDAQDTO(bolsa.nome);
                try
                {
                    this.envia.get("http://www.nasdaq.com/screening/companies-by-name.aspx", dto, bolsaCallback);
                }
                catch (Exception e)
                {
                    Log(e.Message);
                }
            }
        }

        private void bolsaCallback(string response)
        {
            Log("Verificando as possiveis novas acoes");
            using (System.IO.StringReader reader = new System.IO.StringReader(response))
            {
                string line;
                string[] row;
                Acao acao;
                reader.ReadLine();
                while ((line = reader.ReadLine()) != null)
                {
                    row = line.Split(',');
                    acao = new Acao(row[0].Replace("\"", ""), row[1].Replace("\"", ""));
                    if (!bolsa.acoes.Contains(acao, new AcaoEquitable()))
                    {
                        acoesParaAdicionar.Enqueue(acao);
                    }
                }
            }
            if (acoesParaAdicionar.Count > 0)
            {
                Log("Encontrei" + acoesParaAdicionar.Count + " acoes novas! Adicionarei em breve");
                this.threadSleepTime = 1000;
            }
            else
            {
                Log("Nenhuma acao nova");
                this.threadSleepTime = 3600000;
            }
        }
    }
}