using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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

    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //btnLol.Click += new EventHandler(btnLol_Click);
        }

        void btnLol_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        protected void eventClick(object sender, EventArgs e)
        {

            localhost.Service1 service = new localhost.Service1();
            double resultado;
            bool wtf;
            service.Somar(10, true, 2, true, out resultado, out wtf);
            var a = 0;
            //lblLoL.Text = EnviaPost.executaAction(url, scope, session, secure, next);            
            //lblLoL.Text = EnviaRequest.post("http://www.underthepixel.com", 
            //    new googleinfo());

        }
    }
}