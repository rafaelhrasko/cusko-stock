using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Net;
using System.IO;

namespace WebAppTeste
{
    public class EnviaRequest
    {
        public delegate void RequestTerminou(string retorno);

        public static string send(string url, string method, string paramsUrlEncoded)
        {
            UTF8Encoding encoding = new UTF8Encoding();

            byte[] buffer = encoding.GetBytes(paramsUrlEncoded);

            // Prepare web request...
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(url);

            // We use POST ( we can also use GET )
            myRequest.Method = method;

            // Set the content type to a FORM
            if (method == "POST")
            {
                myRequest.ContentType = "application/x-www-form-urlencoded";

                // Get length of content
                myRequest.ContentLength = buffer.Length;

                // Get request stream
                Stream newStream = myRequest.GetRequestStream();

                // Send the data.
                newStream.Write(buffer, 0, buffer.Length);

                // Close stream
                newStream.Close();
            }

            // Assign the response object of 'HttpWebRequest' to a 'HttpWebResponse' variable.
            HttpWebResponse myHttpWebResponse = (HttpWebResponse)myRequest.GetResponse();

            // Display the contents of the page to the console.
            Stream streamResponse = myHttpWebResponse.GetResponseStream();

            // Get stream object
            StreamReader streamRead = new StreamReader(streamResponse);

            Char[] readBuffer = new Char[256];

            // Read from buffer
            int count = streamRead.Read(readBuffer, 0, 256);
            StringBuilder sb = new StringBuilder();
            while (count > 0)
            {
                // get string
                String resultData = new String(readBuffer, 0, count);
                
                // Write the data
                sb.AppendLine(resultData);

                // Read from buffer
                count = streamRead.Read(readBuffer, 0, 256);
            }

            // Release the response object resources.
            streamRead.Close();
            streamResponse.Close();

            // Close response
            myHttpWebResponse.Close();

            return sb.ToString();
        }

        public static void send(string url, string method, string paramsUrlEncoded, RequestTerminou callback)
        {
            callback(send(url, method, paramsUrlEncoded));
        }

        private static string enviarParametrosFormatados(string url_, string metodo_, object parametros_)
        {   
            string parametros = "";
            if (parametros_ != null)
            {
                Type type = parametros_.GetType();
                System.Reflection.FieldInfo[] fields = type.GetFields();

                if (fields.Length != 0)
                {
                    StringBuilder parametroBuilder = new StringBuilder('?');
                    parametroBuilder.Append(fields[0].Name);
                    parametroBuilder.Append('=');
                    parametroBuilder.Append(fields[0].GetValue(parametros_));
                    for (int i = 1; i < fields.Length; i++)
                    {
                        parametroBuilder.Append('&');
                        parametroBuilder.Append(fields[i].Name);
                        parametroBuilder.Append('=');
                        parametroBuilder.Append(fields[i].GetValue(parametros_));
                    }
                    parametros = HttpUtility.UrlEncode(parametroBuilder.ToString());
                }
            }
            return EnviaRequest.send(url_, metodo_, parametros);
        }

        private static void enviarParametrosFormatados(string url_, string metodo_, object parametros_, RequestTerminou callback)
        {
            callback(enviarParametrosFormatados(url_,metodo_,parametros_));
        }

        public static string post(string url_, object parametros_)
        {
            return enviarParametrosFormatados(url_, "POST", parametros_);
        }

        public static void post(string url_, object parametros_, RequestTerminou callback)
        {
            enviarParametrosFormatados(url_, "POST", parametros_,callback);
        }


        public static string get(string url_, object parametros_)
        {
            return enviarParametrosFormatados(url_, "GET", parametros_);
        }

        public static void get(string url_, object parametros_, RequestTerminou callback)
        {
            enviarParametrosFormatados(url_, "GET", parametros_,callback);
        }

    }
}