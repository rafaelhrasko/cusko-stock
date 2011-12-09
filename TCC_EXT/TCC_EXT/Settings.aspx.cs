using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Core.Class;
using Ext.Net;

namespace TCC_EXT
{
    public partial class Settings : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [DirectMethod]
        public void adicionarFundos()
        {
            MessageBox msg = new MessageBox();
            msg.Prompt("Adição de novos fundos", "Digite a quantia a ser adicionada aos fundos da aplicação.");
            msg.Show();
        }
    }
}