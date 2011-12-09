using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TCC_EXT
{
    public partial class PesquisarHistAtualizacao : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<HistFundos> lstHistFundos = new List<HistFundos>();
            lstHistFundos.Add(new HistFundos() { DataFundo = DateTime.Today.AddDays(-210), FundosTotais = 10000, GanhoAcumulado = 0, GanhoMensal = 0.0d });
            lstHistFundos.Add(new HistFundos() { DataFundo = DateTime.Today.AddDays(-182), FundosTotais = 11234, GanhoAcumulado = 2, GanhoMensal = 0.3d });
            lstHistFundos.Add(new HistFundos() { DataFundo = DateTime.Today.AddDays(-174), FundosTotais = 11233, GanhoAcumulado = 2, GanhoMensal = 0.3d });
            lstHistFundos.Add(new HistFundos() { DataFundo = DateTime.Today.AddDays(-150), FundosTotais = 11450, GanhoAcumulado = 2, GanhoMensal = 0.3d });
            lstHistFundos.Add(new HistFundos() { DataFundo = DateTime.Today.AddDays(-120), FundosTotais = 12000, GanhoAcumulado = 2, GanhoMensal = 0.3d });
            lstHistFundos.Add(new HistFundos() { DataFundo = DateTime.Today.AddDays(-111), FundosTotais = 14000, GanhoAcumulado = 2, GanhoMensal = 0.3d });
            lstHistFundos.Add(new HistFundos() { DataFundo = DateTime.Today.AddDays(-99), FundosTotais = 19000, GanhoAcumulado = 2, GanhoMensal = 0.3d });

            for (int i = 0; i < lstHistFundos.Count; i++)
            {
                if (i > 0)
                {
                    HistFundos histTemp = lstHistFundos[i];
                    histTemp.GanhoMensal = (histTemp.FundosTotais - lstHistFundos[i - 1].FundosTotais) / 100;
                    histTemp.GanhoAcumulado = (histTemp.FundosTotais - lstHistFundos[0].FundosTotais) / 100;
                }
            }

            Store1.DataSource = lstHistFundos;
            Store1.DataBind();
        }
    }

    public class HistFundos
    {
        public double FundosTotais { get; set; }
        public double GanhoMensal { get; set; }
        public double GanhoAcumulado { get; set; }
        public DateTime DataFundo { get; set; }
    }
}