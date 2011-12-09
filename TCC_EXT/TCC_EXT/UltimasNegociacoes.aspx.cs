using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Core.Class;
using Core.App;

namespace TCC_EXT
{
    public partial class UltimasNegociacoes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Store1.DataSource = loadData();
            Store1.DataBind();
        }

        private List<HistMovimentacao> loadData()
        {
            List<HistMovimentacao> lstHistMov = new List<HistMovimentacao>();

            lstHistMov = HistMovimentacaoAPL.ultimasNegociacoes();

            return null;
        }
    }
}