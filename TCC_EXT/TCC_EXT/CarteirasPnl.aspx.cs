using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Core.Class;
using Ext.Net;
using Core.App;
using Newtonsoft.Json;

namespace TCC_EXT
{
    public partial class CarteirasPnl : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                //forDebugPurposes();
                carregarGrid();
        }

        protected void carregarGrid()
        {
            Investidor usu = Session["usuario"] as Investidor;
            String strNome = Request.QueryString["id"].ToString();

            if (usu.LstCarteiras.Find(cart => cart.StrNome.Equals(strNome)).LstAcoes.Count > 0)
            {
                List<Acao> lstAcoes = usu.LstCarteiras.Find(cart => cart.StrNome.Equals(strNome)).LstAcoes;
                List<HistMovimentacao> histFinal = new List<HistMovimentacao>();

                if (lstAcoes != null)
                {
                    foreach (Acao item in lstAcoes)
                    {
                        histFinal.Add(HistMovimentacaoAPL.listarUltimaNegociacaoAcao(item));
                    }
                }

                GridPanel1.Store.Primary.DataSource = histFinal;
                GridPanel1.Store.Primary.DataBind();


            }

        }

        private void forDebugPurposes()
        {
            Investidor usu = Session["usuario"] as Investidor;
            String strNome = Request.QueryString["id"].ToString();

            List<Acao> lstAcoes = new List<Acao>();

            lstAcoes.Add(
                new Acao() { Empresa = new Empresa() { StrNome = "Bradesco PN" }, FPercentual = 1.43f, StrSimbolo = "BBDC4", INegociacoes = 14600000 }
                );
            lstAcoes.Add(
                new Acao() { Empresa = new Empresa() { StrNome = "OGX PETROLEO ON" }, FPercentual = 0.00f, StrSimbolo = "OGXP3", INegociacoes = 10300000 }
                );

            lstAcoes.First().LstTicks.Add(new HistMovimentacao() { Acao = new Acao() { StrSimbolo = "BBDC4" }, DtNegociada = DateTime.Today, FPercentual = 1.43f, FValorNegociado = 13.87f, IQuantidadeNegociada = 25400 });
            lstAcoes.Find(a => a.StrSimbolo == "OGXP3").LstTicks.Add(new HistMovimentacao() { Acao = new Acao() { StrSimbolo = "OGXP3" }, DtNegociada = DateTime.Today, FPercentual = 0.00f, FValorNegociado = 13.70f, IQuantidadeNegociada = 138790 });


            usu.LstCarteiras.Find(cart => cart.StrNome.Equals(strNome)).LstAcoes = lstAcoes;

            Session["usuario"] = usu;
        }

        protected void salvarCarteira(object sender, DirectEventArgs e)
        {
            X.Msg.Alert("Salvamento", "Salvou!");
        }

        protected void adicionarAcao(object sender, DirectEventArgs e)
        {
            MessageBox mb = new MessageBox();
            mb.Prompt("Adicionar Ação", "Indique o simbolo da ação que quer adicionar", new JFunction { Fn = "AcaoWrittenText" });
            mb.Show();
        }

        protected void persistirAcao(object stock)
        {
            Acao newStock = (Acao)stock;
            Investidor usu = Session["usuario"] as Investidor;
            string strCarteira = Request.QueryString["id"].ToString();
            Carteira cart = usu.LstCarteiras.Find(a => a.StrNome.Equals(strCarteira));

            AcaoAPL.inserirAcaoCarteira(cart, newStock);
        }

        protected void compararAcoes(object sender, DirectEventArgs e)
        {

            string lol = e.ExtraParams["selected"].ToString();

            List<HistMovimentacao> HistMov = JsonConvert.DeserializeObject<List<HistMovimentacao>>(lol);
            List<Acao> lstAcao = new List<Acao>();
            lol = "asdasdasd";

            foreach (HistMovimentacao item in HistMov)
            {
                lstAcao.Add(AcaoAPL.obterAcaoPorSimbolo(item.Acao.StrSimbolo));
            }

            Mathematica mathe = new Mathematica();
            mathe.compararAcoes(lstAcao);

        }

        protected void sugerirPrecoVenda(string text)
        {
            int iQuantidade = 0;
            string symbol = text;

            Mathematica mathe = new Mathematica();
            List<HistMovimentacao> lstHistMov = new List<HistMovimentacao>();

            lstHistMov = HistMovimentacaoAPL.obterHistoricoCompletoPorSimboloDiaAnterior(symbol);
            decimal dSugestao = Decimal.Parse(mathe.SugestaoVenda(lstHistMov, 1000).ToString());

            MessageBox msb = new MessageBox();

            msb.Alert("Sugestão de Preço", "O sistema sugere que a venda de " + symbol + " seja feita por " + decimal.Round(dSugestao, 2));
            msb.Show();
        }

        [DirectMethod]
        public void reloadForSymbol(string text)
        {
            Investidor usu = Session["usuario"] as Investidor;
            String strNome = Request.QueryString["id"].ToString();

            System.Threading.Thread DAO = new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(persistirAcao));

            Acao newstock = AcaoAPL.obterAcaoPorSimbolo(text);


            if (usu.LstCarteiras.Find(cart => cart.StrNome.Equals(strNome)).LstAcoes == null)
                usu.LstCarteiras.Find(cart => cart.StrNome.Equals(strNome)).LstAcoes = new List<Acao>();

            List<Acao> lstAcoes = usu.LstCarteiras.Find(cart => cart.StrNome.Equals(strNome)).LstAcoes;
            List<HistMovimentacao> histFinal = new List<HistMovimentacao>();


            if (newstock != null)
            {
                DAO.Start(newstock);
                lstAcoes.Add(newstock);
            }
            else
            {
                X.Msg.Alert("Erro", "Ação " + text + " não foi localizada nos repositórios!").Show();
                return;
            }

            usu.LstCarteiras.Find(cart => cart.StrNome.Equals(strNome)).LstAcoes = lstAcoes;
            Session.Add("usuario", usu);

            carregarGrid();

        }

        [DirectMethod]
        public void BigSwitch(string command, string text)
        {
            if (command.Equals("Delete"))
                deletarAcaoDoBanco(text);
            else
                sugerirPrecoVenda(text);
        }


        public void deletarAcaoDoBanco(string text)
        {
            Investidor usu = Session["usuario"] as Investidor;
            Acao newstock = AcaoAPL.obterAcaoPorSimbolo(text);
            string strCarteira = Request.QueryString["id"].ToString();
            Carteira cart = usu.LstCarteiras.Find(a => a.StrNome.Equals(strCarteira));

            CarteiraAPL.excluirAcaoCarteira(newstock, cart);
            cart.LstAcoes.RemoveAll(a => a.StrSimbolo == text);

            carregarGrid();

            if (cart.LstAcoes.Count <= 0)
            {
                GridPanel1.Reload();
            }

        }

    }
}