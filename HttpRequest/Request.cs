using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Diagnostics;

namespace HttpRequest
{
    class HttpRequest
    {
        public string url =     "https://oneport.unca.edu/cas/login?service=https%3A%2F%2Foneport.unca.edu%2Fc%2Fportal%2Flogin";
        public string username = "mherzog";
        public string password = "*H00a33t00e44!";

        static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        public void CreateRequest()
        {
            // Create web client simulating IE6.
            WebClient client = new WebClient();
            //CredentialCache.DefaultNetworkCredentials.Password = password;
            //CredentialCache.DefaultNetworkCredentials.UserName = username;
            client.Headers["Accept"] = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
            client.Headers["Origin"] = "https://oneport.unca.edu";
            client.Headers["Upgrade-Insecure-Requests"] = "1";
            client.Headers["User-Agent"] = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/50.0.2661.102 Safari/537.36";
            client.Headers["Content-Type"] = "application/x-www-form-urlencoded";
            client.Headers["Referer"] = url;
            client.Headers["Accept-Encoding"] = "gzip, deflate";
            client.Headers["Accept-Language"] = "en-US,en;q=0.8,pt;q=0.6";
            client.Headers["Cookie"] = "JSESSIONID=13FA0A5BD4752232BA1A6AD324D91549; _ga=GA1.2.827633366.1464042219; viewedAlerts=true; JSESSIONID=FF36F39B87A3EBB1851BDAB64C713F8F";
            try
            {
                //client.ResponseHeaders["_eventId=submit&lt="] = "_c2C4C481B-F72C-564D-F09E-DEFAF289975D_kA73603A1-82C7-B2A6-B2EC-132FA9638E94&password=*H00a33t00e44!&submit=Verifying+Credentials...&username=mherzog";
                //client.Credentials = CredentialCache.DefaultNetworkCredentials;
                Byte[] pageData = client.DownloadData(url);
                string pageHtml = Encoding.ASCII.GetString(pageData);
                for (int i = 0; i < client.ResponseHeaders.Count; i++)
                {
                    Console.Write("Reponse headers: " + client.ResponseHeaders[i] + "\n");
                }
                Console.WriteLine(pageHtml);
                Console.ReadKey();

            }
            catch(WebException we)
            {
                Console.WriteLine($"Error: {we.Message}");
                Console.ReadKey();
            }


            Console.Write(client.ToString());
            Console.ReadKey();
	        
             //   client.Headers["User-Agent"] = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/50.0.2661.102 Safari/537.36";
             //   //client.Headers["Content-Type"] = "application/x-www-form-urlencoded";
             //   //client.Headers["Referer"] = referer;
             //   //client.UseDefaultCredentials = true;
             //   //client.Credentials

             //   // Download data.
             //   byte[] arr = client.DownloadData(url);

             //   // Get response header.
             //   string contentEncoding = client.ResponseHeaders["password"];

             //   // Write values.
             //   Console.WriteLine("--- WebClient result ---");
	            //Console.WriteLine(arr.Length);
             //   string s = ;// ByteArrayToString(arr);
             //   Console.WriteLine(s.ToString());
             //   Console.WriteLine(contentEncoding);
             //   if (Console.ReadKey(true).Key == ConsoleKey.Escape)
             //   {
             //       Process.GetCurrentProcess().Kill();
             //   }
        }

        //public string ByteArrayToString(byte[] ba)
        //{
        //    StringBuilder hex = new StringBuilder(ba.Length * 2);
        //    foreach (byte b in ba)
        //        hex.AppendFormat("{0:x2}", b);
        //    return hex.ToString();
        //}
        static void Main(string[] args)
        {
            HttpRequest r = new HttpRequest();
            r.CreateRequest();
        }
    }
}