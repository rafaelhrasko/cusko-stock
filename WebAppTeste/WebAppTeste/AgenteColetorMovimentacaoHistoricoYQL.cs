using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Text;

namespace WebAppTeste
{
    public class AgenteColetorMovimentacaoHistoricoYQL : AgenteColetorMovimentacaoYQL
    {
        public class HistoricoDTO
        {
            public string s, c;

            public HistoricoDTO(string ticker_)
            {
                s = ticker_;
                c = "2011";
            }
        }

        DateTime minLimitDate;
        HistoricoDTO dtoHistorico;
        private bool pegandoHistorico;
        public AgenteColetorMovimentacaoHistoricoYQL(string ticker_, int idAcao_, DateTime ultimaVerificacao_)
            : base(ticker_, idAcao_, ultimaVerificacao_)
        {
            this.dtoHistorico = new HistoricoDTO(ticker_);
            pegandoHistorico = true;
            if (ultimaVerificacao_ > minUsefulDateTime)
            {
                minLimitDate = ultimaVerificacao_;
            }
            else
            {
                minLimitDate = minUsefulDateTime;
            }
        }

        protected override void Work()
        {
            if (pegandoHistorico)
            {
                try
                {
                    this.envia.get("http://ichart.finance.yahoo.com/table.csv", this.dtoHistorico, parseHistorico);
                }
                catch (Exception e)
                {
                    Log(e.Message);
                }
            }
            else
            {
                base.Work();
            }
        }

        private void parseHistorico(string response)
        {
            Log("começando a procura por dados antigos");
            string data = response.Replace("r", "").Replace("\n", "|");

            string[] rows = data.Split('|');
            StringBuilder sb = new StringBuilder("");
            string stringToAppend;

            //Dai em diante, colocar as virgulas
            for (int i = 1; i < rows.Length; i++)
            {
                if (this.getValueFromCols(rows, i, out stringToAppend))
                {
                    if (sb.Length > 0)
                    {
                        sb.Append(',');
                    }
                    sb.Append(stringToAppend);
                }
            }
            Log("dados encontrados");
            using (MySqlConnection connection = new MySqlConnection(connstring))
            {
                try
                {
                    connection.Open();
                    Log("Inserindo dados no banco");
                    //MySqlCommand commandInsert = new MySqlCommand(String.Format("INSERT INTO HistoricoMovimentacaoTesteLoL VALUES {0}", sb.ToString(), connection));
                    string asd = String.Format("INSERT INTO HistoricoMovimentacao VALUES {0}",sb.ToString());
                    MySqlCommand commandInsert = new MySqlCommand(asd, connection);
                    commandInsert.ExecuteNonQuery();
                    Log("Atualizando tabela Acao");
                    MySqlCommand commandUpdate = new MySqlCommand(String.Format("UPDATE Acao SET ultimaVerificacao = {0}", this.formatDate(DateTime.Now)), connection);
                    commandUpdate.ExecuteNonQuery();
                    pegandoHistorico = false;
                    connection.Close();
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(e.Message);
                }
            }

        }

        private bool getValueFromCols(string[] rows, int index, out string value)
        {
            try
            {
                string[] cols = rows[index].Split(',');
                MovimentacaoBDDTO bdDTO = new MovimentacaoBDDTO();
                bdDTO.data = DateTime.Parse(cols[0]);
                bdDTO.data.AddHours(18);
                bdDTO.valor = float.Parse(cols[4].Replace('.', ','));
                bdDTO.volume = long.Parse(cols[5]);
                value = this.parseHistoricoValue(bdDTO, this.idAcao);
                if (bdDTO.data < DateTime.Now && bdDTO.data > minLimitDate)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            value = "";
            return false;
        }

    }
}