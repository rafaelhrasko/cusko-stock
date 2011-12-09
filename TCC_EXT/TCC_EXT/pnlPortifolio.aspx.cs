using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;

namespace TCC_EXT
{
    public partial class pnlPortifolio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {
                this.gdpAcoesCadastradas.Store.Primary.DataSource = new List<Acao>
            {
                new Acao ( "3m Co", "71.72", "0.02", "0.03","","","","","","","","","" , "9/1 12:00am"),
                new Acao ( "Alcoa Inc", "29.01", "0.42", "1.47","","","","","","","","",""  , "9/1 12:00am"),
                new Acao ( "Altria Group Inc", "83.81"," 0.28", "0.34","","","","","","","","",""  , "9/1 12:00am"),
                new Acao ( "American Express Company", "52.55", "0.01", "0.02","","","","","","","","","",  "9/1 12:00am"),
                new Acao ( "American International Group, Inc.", "64.13", "0.31", "0.49" ,"","","","","","","","","", "9/1 12:00am" ),
                new Acao ( "AT&T Inc.", "31.61"," -0.48", "-1.54","","","","","","","","",""  , "9/1 12:00am"),
                new Acao ( "Boeing Co.", "75.43", "0.53", "0.71","","","","","","","","","" , "9/1 12:00am" ),
                new Acao ( "Caterpillar Inc.", "67.27", "0.92", "1.39","","","","","","","","",""  , "9/1 12:00am"),
                new Acao ( "Citigroup, Inc.", "49.37", "0.02", "0.04","","","","","","","","",""  , "9/1 12:00am"),
                new Acao ( "E.I. du Pont de Nemours and Company", "40.48", "0.51", "1.28","","","","","","","","","" , "9/1 12:00am" )
            };

                this.gdpAcoesCadastradas.Store.Primary.DataBind();
            }
        }

        public class Acao
        {

            public string strNome { get; set; }
            public string strCodigo { get; set; }
            public string strPreco { get; set; }
            public string strVariacao { get; set; }
            public string strQuantidadeNegociacao { get; set; }
            public string strPrecoUnitarioNegociado { get; set; }
            public string strUltimoFechamento { get; set; }
            public string strUltimaAbertura { get; set; }
            public string strMinima { get; set; }
            public string strMaxima { get; set; }
            public string strMedia { get; set; }
            public string strQtdDisponivel { get; set; }
            public string strVolume { get; set; }
            public string strUltimoUpdate { get; set; }

            public Acao(string nome, string codigo, string preco, string variacao, string quantidade, string precoNegociado, string ultimofechamento, string ultimaabertura, string minima, string maxima, string media, string qtddisponivel, string volume, string ultimoupdate)
            {
                this.strNome = nome;
                this.strCodigo = codigo;
                this.strVariacao = variacao;
                this.strQuantidadeNegociacao = quantidade;
                this.strPrecoUnitarioNegociado = precoNegociado;
                this.strUltimoFechamento = ultimofechamento;
                this.strUltimaAbertura = ultimaabertura;
                this.strMinima = minima;
                this.strMaxima = maxima;
                this.strMedia = media;
                this.strQtdDisponivel = qtddisponivel;
                this.strVolume = volume;
                this.strUltimoUpdate = ultimoupdate;
            }

        }
    }
}