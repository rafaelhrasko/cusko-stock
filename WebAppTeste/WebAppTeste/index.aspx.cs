using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace WebAppTeste
{
    public class googleinfo
    {
        public string url = "https://www.google.com/accounts/AuthSubRequest";
        public string next = "http://localhost:1053/index.aspx";
        public string scope = "http://finance.google.com/finance/feeds/";
        public string secure = "1";
        public string session = "1";
    }

    public class yahooInfo
    {
        public string s = "GE";
        public string f = "nkqwxyr1l9t5p4";

    }

    public class yqlInfo
    {
        //public string q = "select%20*%20from%20yahoo.finance.quotes%20where%20symbol%20in%20(%22YHOO%22%2C%22AAPL%22%2C%22GOOG%22%2C%22MSFT%22)%0A%09%09&diagnostics=true&env=http%3A%2F%2Fdatatables.org%2Falltables.env";
        //public string q = "select%20Ask%20from%20yahoo.finance.quotes%20where%20symbol%20in%20(%27YHOO%27)";
        public string q = "select%20Ask%20from%20yahoo.finance.quotes%20where%20symbol%20in%20('YHOO'%2C'AAPL'%2C'GOOG'%2C'MSFT')";
        public string env = "http%3A%2F%2Fdatatables.org%2Falltables.env";
        //http://www1.caixa.gov.br/loterias/_arquivos/loterias/D_megase.zip
    }

    public partial class index : System.Web.UI.Page
    {
        AgenteColetorAcaoNASDAQ agente;
        List<Bolsa> bolsasConhecidas;
        bool stop;

        protected void Page_Load(object sender, EventArgs e)
        {
            stop = true;
            btnStop.Enabled = false;
            //using (MySqlConnection connection = new MySqlConnection(Agente.connstring))
            //{
            //    try
            //    {
            //        connection.Open();

            //        MySqlCommand commandBolsa = new MySqlCommand("SELECT idBolsa,Nome FROM Bolsa", connection);
            //        MySqlDataReader readerBolsa = commandBolsa.ExecuteReader();
            //        while (readerBolsa.Read())
            //        {
            //            bolsasConhecidas.Add(new Bolsa(readerBolsa.GetInt32(0), readerBolsa.GetString(1)));
            //        }
            //        readerBolsa.Close();

            //        foreach (var bolsa in bolsasConhecidas)
            //        {
                        agente = new AgenteColetorAcaoNASDAQ("nasdaq", 0);
                        agente.Start();
                        btnStop.Enabled = true;
                        btnStop.Text = "Stop All";
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        System.Diagnostics.Debug.WriteLine(ex.Message);
            //    }
            //}
        }

        protected void eventClick(object sender, EventArgs e)
        {
            if (stop)
            {
                btnStop.Enabled = false;
                agente.StopThread();
                btnStop.Text = "Restart";
                stop = false;
                btnStop.Enabled = true;
            }
            else
            {
                btnStop.Enabled = false;
                agente.Start();
                btnStop.Text = "Stop All";
                stop = true;
                btnStop.Enabled = true;
            }
            //lblLoL.Text = EnviaPost.executaAction(url, scope, session, secure, next);            
            //EnviaRequestSimples envia = new EnviaRequestSimples();
            //lblLoL.Text = envia.get("http://finance.yahoo.com/d/quotes.csv", new yahooInfo());
            //lblLoL.Text = envia.get("http://query.yahooapis.com/v1/public/yql", new yqlInfo());
            //    new googleinfo());
            //AgenteColetorMovimentacaoYQL agente = new AgenteColetorMovimentacaoYQL("GOOG", 0, "2011-11-22 18:56:53");
            //AgenteColetorAcaoNASDAQ agente = new AgenteColetorAcaoNASDAQ();
            //agente.Start();
            //AgenteColetorMovimentacaoHistoricoYQL agente = new AgenteColetorMovimentacaoHistoricoYQL("GOOG", 0, DateTime.Now);
        }
    }
}