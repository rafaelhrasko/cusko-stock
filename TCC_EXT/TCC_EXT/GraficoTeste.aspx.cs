using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Ext.Net.Utilities;
using Core.Class;
using Core.App;

namespace TCC_EXT
{
    public partial class GraficoTeste : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //List<HistMovimentacao> lstHist = new List<HistMovimentacao>();
            //lstHist = HistMovimentacaoAPL.ultimasNegociacoes();

            //List<Acao> listaAcao = new List<Acao>();
            //listaAcao = AcaoAPL.listarAcoes();

            //Dictionary<int, List<HistMovimentacao>> dic = new Dictionary<int, List<HistMovimentacao>>();
            //foreach (Acao item in listaAcao)
            //{
            //    dic.Add(item.ICodigo, lstHist.FindAll(a => a.Acao.ICodigo == item.ICodigo));
            //}

            Mathematica lol = new Mathematica();

            ////Curva de bollinger OK =3
            List<HistMovimentacao> lstLoL = new List<HistMovimentacao>();
            lstLoL = HistMovimentacaoAPL.obterHistoricoCompletoPorSimboloDiaAnterior("AAPL");


            //DateTime.Compare(lstLoL.Max(a => a.DtNegociada), lstLoL.Min(a => a.DtNegociada))
            Chart1.Series.Add(lol.CurvaBollingerInferior(lstLoL,20 , 2));
            Chart1.Series.Add(lol.CurvaBollingerIntermediaria(lstLoL, 20));
            Chart1.Series.Add(lol.CurvaBollingerSuperior(lstLoL, 20, 2));

            //Histograma funciona nice =3
            //Chart1.Series.Add(lol.Histograma(dic[5]));

            //Chart1.Series.Add(lol.LinhaMACD(HistMovimentacaoAPL.obterHistoricoCompletoPorSimbolo("AAPL")));
            //Chart1.Series.Add(lol.LinhaSinal(HistMovimentacaoAPL.obterHistoricoCompletoPorSimbolo("AAPL")));

            //Chart1.Series.Add(lol.VolumeWeightedAvaragePrice(HistMovimentacaoAPL.obterHistoricoCompletoPorSimbolo("GOOG"), "GOOG"));
            //Chart1.Series.Add(lol.VolumeWeightedAvaragePrice(HistMovimentacaoAPL.obterHistoricoCompletoPorSimbolo("AAPL"), "APPL"));

            List<DateTime> asdasdasd = new List<DateTime>();
        }
    }
}