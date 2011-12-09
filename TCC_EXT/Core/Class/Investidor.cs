using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Class
{
    [Serializable()]
    public class Investidor
    {

        #region Atributos
        private int iCodigo;
        private string strLogin;
        private string strNome;
        private string strEmail;
        private string strKeyPass;
        private List<Carteira> lstCarteiras;
        #endregion

        #region Propriedades
        public int ICodigo
        {
            get { return iCodigo; }
            set { iCodigo = value; }
        }
        public string StrLogin
        {
            get { return strLogin; }
            set { strLogin = value; }
        }
        public string StrNome
        {
            get { return strNome; }
            set { strNome = value; }
        }
        public string StrEmail
        {
            get { return strEmail; }
            set { strEmail = value; }
        }
        public string StrKeyPass
        {
            get { return strKeyPass; }
            set { strKeyPass = value; }
        }
        public List<Carteira> LstCarteiras
        {
            get { return lstCarteiras; }
            set { lstCarteiras = value; }
        }
        #endregion

        public Investidor()
        {
            LstCarteiras = new List<Carteira>();
        }

    }
}
