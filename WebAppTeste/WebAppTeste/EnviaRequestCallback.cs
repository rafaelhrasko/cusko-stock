using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppTeste
{
    public class EnviaRequestCallback : EnviaRequest
    {
        public delegate void RequestTerminou(string retorno);

        protected void send(string url, string method, string paramsUrlEncoded, RequestTerminou callback)
        {
            callback(base.send(url, method, paramsUrlEncoded));
        }

        protected void enviarParametrosFormatados(string url_, string metodo_, object parametros_, RequestTerminou callback)
        {
            callback(base.enviarParametrosFormatados(url_, metodo_, parametros_));
        }

        public void post(string url_, object parametros_, RequestTerminou callback)
        {
            this.enviarParametrosFormatados(url_, "POST", parametros_,callback);
        }

        public void get(string url_, object parametros_, RequestTerminou callback)
        {
            this.enviarParametrosFormatados(url_, "GET", parametros_, callback);
        }
    }
}