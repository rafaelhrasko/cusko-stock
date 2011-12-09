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
        protected virtual string send(string url, string method, string paramsUrlEncoded)
        {
            

            // Prepare web request...
            HttpWebRequest myRequest;

            // Set the content type to a FORM
            if (method == "POST")
            {
                myRequest = (HttpWebRequest)WebRequest.Create(url);

                UTF8Encoding encoding = new UTF8Encoding();

                byte[] buffer = encoding.GetBytes(paramsUrlEncoded);

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
            else
            {
                myRequest = (HttpWebRequest)WebRequest.Create(String.Format("{0}?{1}", url, paramsUrlEncoded));
                //myRequest.ContentType = "application/x-www-form-urlencoded";
            }

            // We use POST ( we can also use GET )
            myRequest.Method = method;

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
                sb.Append(resultData);

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

        protected virtual string enviarParametrosFormatados(string url_, string metodo_, object parametros_)
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
                    //parametros = HttpUtility.UrlEncode(parametroBuilder.ToString());
                    parametros = parametroBuilder.ToString();
                }
            }
            return this.send(url_, metodo_, parametros);
        }
    }
}