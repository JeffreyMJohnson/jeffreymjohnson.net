using System;
using System.Net;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFoo
{
    class Program
    {
        static void Main(string[] args)
        {

            string url = "https://api.github.com/zen";

            // *** Establish the request
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);

            // *** Set properties
            //webRequest.Timeout = 10000;     // 10 secs
            webRequest.UserAgent = "anonymous";

            // *** Retrieve request info headers
            try
            {
                HttpWebResponse loWebResponse = (HttpWebResponse) webRequest.GetResponse();
                Encoding enc = Encoding.GetEncoding(1252);  // Windows default Code Page

                StreamReader loResponseStream =
                   new StreamReader(loWebResponse.GetResponseStream(), enc);

                string lcHtml = loResponseStream.ReadToEnd();

                loWebResponse.Close();
                loResponseStream.Close();

                Console.WriteLine(lcHtml);
            }
            catch (WebException e)
            {
                Console.WriteLine(e.Message);
            }

           

            Console.Read();
        }
    }
}
