using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Core.Class;
using Core.App;

namespace TCC_EXT
{
    public partial class SettingsPnl : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                carregarGrid();
        }

        [DirectMethod]
        public void NovaCarteira(string text)
        {
            Investidor usu = Session["usuario"] as Investidor;

            Carteira cart = persisteCarteira(text, usu);
            usu.LstCarteiras.Add(cart);

            //reloadCarteiras(usu);
            carregarGrid();

            Session.Add("usuario", usu);

        }

        [DirectMethod]
        public void newCarteira()
        {
            MessageBox msb = new MessageBox();
            msb.Prompt("Nova Carteira", "Digite o nome para a Nova Carteira", new JFunction { Fn = "saveWrittenText" });
            msb.Show();
        }

        [DirectMethod]
        public void deletarAcoes(string iCodigo)
        {
            Investidor usu = Session["usuario"] as Investidor;
            Carteira delCart = usu.LstCarteiras.Find(a => a.ICodigo == int.Parse(iCodigo));

            CarteiraAPL.excluirCarteira(delCart);

            usu.LstCarteiras.Remove(delCart);

            Session.Add("usuario", usu);

            carregarGrid();
        }

        private void carregarGrid()
        {
            Investidor usu = Session["usuario"] as Investidor;

            List<Carteira> lstCarteiras = usu.LstCarteiras;

            GridPanel1.Store.Primary.DataSource = lstCarteiras;
            GridPanel1.Store.Primary.DataBind();

        }

        protected Carteira persisteCarteira(string txt, Investidor usu)
        {
            Carteira cart = new Carteira();
            cart.StrNome = txt;
            cart.Usuario = usu;

            cart.ICodigo = CarteiraAPL.inserirCarteira(cart);

            return cart;
        }

    }
}