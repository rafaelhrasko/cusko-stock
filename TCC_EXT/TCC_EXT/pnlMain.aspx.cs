using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TCC_EXT
{
    public partial class pnlMain : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.gdpLOL.Store.Primary.DataSource = new List<Company> 
         { 
             new Company("Alcoa Inc", 29.01, 0.42, 1.47),
             new Company("Boeing Co.", 75.43, 0.53, 0.71),
             new Company("General Electric Company", 34.14, -0.08, -0.23),
             new Company("JP Morgan & Chase & Co", 45.73, 0.07, 0.15),
             new Company("The Home Depot, Inc.", 34.64, 0.35, 1.02),
             new Company("Verizon Communications", 35.57, 0.39, 1.11),
         };

            this.gdpLOL.Store.Primary.DataBind();


            this.gdpSaldo.Store.Primary.DataSource = new List<Saldo> { new Saldo("Saldo disponível:", "R$ 3000,00") };
            this.gdpSaldo.Store.Primary.DataBind();
        }

        public class Saldo
        {

            public string strNomeSaldo { get; set; }
            public string strValorSaldo { get; set; }

            public Saldo(string saldo, string valor)
            {
                this.strNomeSaldo = saldo;
                this.strValorSaldo = valor;
            }
        }

        public class Company
        {
            public Company(string name, double price, double change, double pctChange)
            {
                this.Name = name;
                this.Price = price;
                this.Change = change;
                this.PctChange = pctChange;
            }

            public string Name { get; set; }
            public double Price { get; set; }
            public double Change { get; set; }
            public double PctChange { get; set; }
            public double IQuant { get; set; }

        }
    }
}