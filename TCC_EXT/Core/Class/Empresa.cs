using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Class
{
    [Serializable()]
    public class Empresa
    {

        #region Atributos
        private string iCodigo;
        private string strNome;
        #endregion

        #region Propriedades
        public string ICodigo
        {
            get { return iCodigo; }
            set { iCodigo = value; }
        }
        public string StrNome
        {
            get { return strNome; }
            set { strNome = value; }
        }
        #endregion


    }
}
