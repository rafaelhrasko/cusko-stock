using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppTeste
{
    public class EnviaRequestSimples : EnviaRequest
    {
        public string post(string url_, object parametros_)
        {
            return this.enviarParametrosFormatados(url_, "POST", parametros_);
        }

        public string get(string url_, object parametros_)
        {
            return this.enviarParametrosFormatados(url_, "GET", parametros_);
        }
    }
}