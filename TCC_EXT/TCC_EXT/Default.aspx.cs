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
using Newtonsoft.Json;

namespace TCC_EXT
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, DirectEventArgs e)
        {
            Investidor usu = new Investidor();
            string strLoginApelido;
            string strPassword;

            strLoginApelido = this.txtUsuario.Text;
            strPassword = this.txtPassword.Text;
            Core.App.InvestidorAPL.asdasdasd();

            try
            {
                usu.StrLogin = txtUsuario.Text;
                usu.StrKeyPass = strPassword;

                if (logarUsuario(ref usu))
                {
                    Session.Add("usuario", usu);
                    Page.Response.Redirect("Desktop.aspx");
                }
                else
                    throw new Exception("Verifique o Login e Senha");
            }
            catch (Exception ex)
            {
                X.Msg.Alert("Erro", ex.Message).Show();
                return;
            }
        }

        private bool logarUsuario(ref Investidor usu)
        {
            if (fillInvestidor(ref usu) != null)
                return true;
            return false;
        }

        private Investidor fillInvestidor(ref Investidor usu)
        {
            usu = InvestidorAPL.logarUsuario(usu);
            return usu;
        }

    }
}