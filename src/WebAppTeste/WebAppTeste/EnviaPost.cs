using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.IO;
using System.Text;

namespace WebAppTeste
{
    public class EnviaPost
    {

        public static string executaAction(String url, params string[] parametros)
        {
            WebResponse webResponse = null;
            StreamReader sr = null;
            Stream webReqStream = null;

            //Preparando o WebRequest para Fazer o Post
            WebRequest webReq = WebRequest.Create(url);
            webReq.Method = WebRequestMethods.Http.Post;

            webReq.ContentType = "application/x-www-form-urlencoded";

            //Preparando os parametros que serão passados.
            char[] specials = { '?', '=', '&' };

            //Alocando o bytebuffer
            byte[] byteBuffer = null;

            StringBuilder finalParameters = new StringBuilder();

            if (parametros.Length > 0)
            {
                foreach (string str in parametros)
                {
                    if (parametros.First() == str)
                        finalParameters.Append('?');

                    finalParameters.Append(str);

                    if (parametros.Last() != str)
                        finalParameters.Append('&');
                }
                byteBuffer = Encoding.UTF8.GetBytes(finalParameters.ToString());

                webReq.ContentLength = byteBuffer.Length;
                webReqStream = webReq.GetRequestStream();
                webReqStream.Write(byteBuffer, 0, byteBuffer.Length);
                webReqStream.Close();
            }
            else
            {
                webReq.ContentLength = 0;
            }

            //Dados Recebidos
            webResponse = webReq.GetResponse();
            Stream responseStream = webResponse.GetResponseStream();

            // Codifica os caracteres especiais para que possam ser exibidos corretamente
            System.Text.Encoding encoding = System.Text.Encoding.Default;

            sr = new StreamReader(responseStream, encoding);

            char[] charBuffs = new char[256];
            int count = sr.Read(charBuffs, 0, charBuffs.Length);
            StringBuilder dados = new StringBuilder();

            while (count > 0)
            {
                dados.Append(new String(charBuffs, 0, count));
                count = sr.Read(charBuffs, 0, charBuffs.Length);
            }

            //Fechando todos os streammers, caso nao tenham sido fechados ainda
            if (webReqStream != null)
                webReqStream.Close();
            if (webResponse != null)
                webResponse.Close();
            if (sr != null)
                sr.Close();

            return dados.ToString();
        }

        public static string executeDirectPost(String url, string lol)
        {
            WebResponse webResponse = null;
            StreamReader sr = null;
            Stream webReqStream = null;

            //Preparando o WebRequest para Fazer o Post
            WebRequest webReq = WebRequest.Create(url + lol);
            webReq.Method = WebRequestMethods.Http.Post;

            webReq.ContentType = "application/x-www-form-urlencoded";
            webReq.ContentLength = 0;

            webResponse = webReq.GetResponse();
            Stream responseStream = webResponse.GetResponseStream();

            System.Text.Encoding enc = System.Text.Encoding.Default;

            sr = new StreamReader(responseStream, enc);
            char[] charbuffs = new char[256];
            int count = sr.Read(charbuffs, 0, charbuffs.Length);
            StringBuilder dados = new StringBuilder();

            while (count > 0)
            {
                dados.Append(new string(charbuffs, 0, count));
                count = sr.Read(charbuffs, 0, charbuffs.Length);
            }

            if (webReqStream != null)
                webReqStream.Close();
            if (webResponse != null)
                webResponse.Close();
            if (sr != null)
                sr.Close();

            return dados.ToString().Replace("\r\n", "");

        }


    }
}