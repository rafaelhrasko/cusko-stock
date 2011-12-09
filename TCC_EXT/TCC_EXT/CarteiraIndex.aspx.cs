using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Core.Class;
using Ext.Net;
using Ext.Net.Utilities;
using Core.App;

namespace TCC_EXT
{
    public partial class CarteiraIndex : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //forDebugPurposes();
                carregarCarteiras();
            }

        }

        private void forDebugPurposes()
        {
            Investidor usu = new Investidor();

            usu.StrEmail = "fakemail@fakeprov.com";
            usu.StrKeyPass = "iKeyPass";
            usu.StrLogin = "LolUsu";

            for (int i = 0; i < 5; i++)
            {
                Carteira asd = new Carteira();
                asd.StrNome = "Carteira_" + i;

                usu.LstCarteiras.Add(asd);
            }
            Session.Add("usuario", usu);
        }

        private void carregarCarteiras()
        {
            Investidor usu = Session["usuario"] as Investidor;

            Ext.Net.TreeNode treeCarteiras = new Ext.Net.TreeNode("Carteiras");
            treeCarteiras.Expandable = Ext.Net.ThreeStateBool.True;

            treeMenu.Root.Add(treeCarteiras);

            if (usu.LstCarteiras != null)
                foreach (Carteira item in usu.LstCarteiras)
                {
                    Ext.Net.TreeNode piece = new Ext.Net.TreeNode(item.StrNome, Icon.Money);
                    piece.Listeners.Click.Handler = "addTab(#{DoodTp}, '" + item.StrNome + "' , 'CarteirasPnl.aspx?id=" + item.StrNome + "');";

                    treeCarteiras.Nodes.Add(piece);
                }

            Ext.Net.TreeNode add = new Ext.Net.TreeNode("Adicionar", Icon.Add);
            add.Listeners.Click.Handler = "Ext.net.DirectMethods.newCarteira();";

            treeCarteiras.Nodes.Add(add);
        }

        [DirectMethod]
        public void newCarteira()
        {
            MessageBox msb = new MessageBox();
            msb.Prompt("Nova Carteira", "Digite o nome para a Nova Carteira", new JFunction { Fn = "saveWrittenText" });
            msb.Show();
        }

        [DirectMethod]
        public void NovaCarteira(string text)
        {
            Investidor usu = Session["usuario"] as Investidor;

            Carteira cart = persisteCarteira(text, usu);
            usu.LstCarteiras.Add(cart);

            //reloadCarteiras(usu);
            carregarCarteiras();

            Session.Add("usuario", usu);

            Panel1.UpdateContent();

        }

        protected void reloadCarteiras(Investidor usu)
        {
            Ext.Net.TreeNode treeCarteiras = new Ext.Net.TreeNode("Carteiras");
            treeCarteiras.Expandable = Ext.Net.ThreeStateBool.True;

            treeMenu.Root.Add(treeCarteiras);

            foreach (Carteira item in usu.LstCarteiras)
            {
                Ext.Net.TreeNode piece = new Ext.Net.TreeNode(item.StrNome, Icon.Money);
                piece.Listeners.Click.Handler = "addTab(#{DoodTp}, '" + item.StrNome + "' , 'CarteirasPnl.aspx?id=" + item.StrNome + "');";

                treeCarteiras.Nodes.Add(piece);
            }

            Ext.Net.TreeNode add = new Ext.Net.TreeNode("Adicionar", Icon.Add);
            add.Listeners.Click.Handler = "Ext.net.DirectMethods.newCarteira();";

            //Ext.Net.TreeNode lol = new Ext.Net.TreeNode(text, Icon.Money);
            //lol.Listeners.Click.Handler = "addTab(#{DoodTp}, '" + text + "' , 'CarteirasPnl.aspx?id=" + text + "');";

            //treeCarteiras.Nodes.Add(lol);
            treeCarteiras.Nodes.Add(add);
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