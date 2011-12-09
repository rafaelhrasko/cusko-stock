using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.IO;
using MySql.Data.MySqlClient;

namespace WebAppTeste
{
    public class MovimentacaoYQLDTO
    {
        public string q;
        public string env = "http%3A%2F%2Fdatatables.org%2Falltables.env";

        public MovimentacaoYQLDTO(string ticker_)
        {
            q = string.Format("select%20Bid,LastTradeDate,LastTradeTime,Volume%20from%20yahoo.finance.quotes%20where%20symbol%20=%20'{0}'", ticker_);
        }

    }

    public class MovimentacaoBDDTO
    {
        public DateTime data;
        public float valor;
        public long volume;
    }

    public class AgenteColetorMovimentacaoYQL : Agente
    {
        const int maxSleepTime = 3600000;
        public static int minSleepTime = 1000;
        protected static DateTime minUsefulDateTime = new DateTime(1990, 1, 1);

        MovimentacaoYQLDTO dtoYQL;
        MovimentacaoBDDTO dtoBD;

        protected int idAcao;
        protected DateTime lastTime;

        protected string ticker;

        public MovimentacaoBDDTO DtoBD { get { return this.dtoBD; } }

        public AgenteColetorMovimentacaoYQL(string ticker_, int idAcao_, DateTime ultimaVerificacao_)
            :base("ColetorMovYQL "+ticker_)
        {
            dtoYQL = new MovimentacaoYQLDTO(ticker_);
            this.ticker = ticker_;
            idAcao = idAcao_;
            lastTime = ultimaVerificacao_;
        }

        private void getMovimentacao()
        {
            Log("Procurando por movimentacoes");
            try
            {
                this.envia.get("http://query.yahooapis.com/v1/public/yql", this.dtoYQL, parseResponse);
            }
            catch (Exception e)
            {
                Log(e.Message);
            }
        }

        protected bool continuetoSend;
        private void parseResponse(string response)
        {
            dtoBD = new MovimentacaoBDDTO();
            continuetoSend = false;
            // Create an XmlReader
            Log("Movimentacao Encontrada. Verificando se é nova");
            using (XmlReader reader = XmlReader.Create(new StringReader(response)))
            {
                XmlWriterSettings ws = new XmlWriterSettings();
                ws.Indent = true;
                string[] datas,horario;
                int horas;
                // Parse the file and display each of the nodes.                
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        //writer.WriteStartElement(reader.Name);
                        
                            try
                            {
                                switch (reader.Name)
                                {
                                    case "Bid":
                                        reader.Read();
                                        dtoBD.valor = float.Parse(reader.Value.Replace('.', ','));
                                        break;
                                    case "LastTradeDate":
                                        reader.Read();
                                        datas = reader.Value.Split('/');
                                        reader.Read(); //end lasttradedate
                                        reader.Read(); //lasttradetime
                                        reader.Read();
                                        horario = reader.Value.Split(':');
                                        horas = int.Parse(horario[0]);
                                        if (horario[1][2] == 'p' && horas != 12)
                                        {
                                            horas += 12;
                                        }
                                        dtoBD.data = new DateTime(int.Parse(datas[2]), int.Parse(datas[0]), int.Parse(datas[1]), horas, int.Parse(horario[1].Substring(0, 2)), 0);
                                        continuetoSend = dtoBD.data > this.lastTime;
                                        if (dtoBD.data < DateTime.Now.Subtract(TimeSpan.FromDays(30)) && dtoBD.data > minUsefulDateTime)
                                        {
                                            continuetoSend = false;
                                        }
                                        break;
                                    case "Volume":
                                        reader.Read();
                                        dtoBD.volume = long.Parse(reader.Value);
                                        break;
                                }
                            }// end switch
                            catch (Exception e)
                            {
                                System.Diagnostics.Debug.WriteLine(e.Message);
                            }// end try
                        
                    } //end if element
                } // end while
            } //end using
            if (continuetoSend)
            {
                Log("É nova. Mandando pro banco de dados");
                sendCollectedData(dtoBD);
                this.lastTime = dtoBD.data;
                this.threadSleepTime /= 2;
                if (this.threadSleepTime < minSleepTime)
                {
                    this.threadSleepTime = minSleepTime;
                }
            }
            else
            {
                Log("Não é");
                this.threadSleepTime *= 2;
                if (this.threadSleepTime > maxSleepTime)
                {
                    this.threadSleepTime = maxSleepTime;
                }
            }
        }

        protected string parseHistoricoValue(MovimentacaoBDDTO dto,int idAcao)
        {
            return String.Format("({0},{1},{2},{3})", this.formatDate(dto.data), idAcao, dto.valor.ToString().Replace(',', '.'), dto.volume);
        }

        protected long formatDate(DateTime date)
        {
            return long.Parse(date.ToString("yyyyMMddHHmmss"));
        }

        private void sendCollectedData(MovimentacaoBDDTO dto)
        {
            long timestamp = this.formatDate(dto.data);
            using (MySqlConnection connection = new MySqlConnection(connstring))
            {
                try
                {
                    connection.Open();
                    string value = this.parseHistoricoValue(dto,idAcao);
                    Log(String.Format("Dado a ser inserido: {0}", value, dto.volume));
                    Log("Inserindo novo dado no historico");
                    MySqlCommand commandInsert = new MySqlCommand(String.Format("INSERT INTO HistoricoMovimentacao VALUES {0}", value), connection);
                    commandInsert.ExecuteNonQuery();
                    Log("Atualizando acao");
                    MySqlCommand commandUpdate = new MySqlCommand(String.Format("UPDATE Acao SET ultimaVerificacao = {0}", timestamp), connection);
                    commandUpdate.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception e)
                {
                    Log(e.Message);
                }
            }
        }



        protected override void Work()
        {
            getMovimentacao();            
        }
    }
}