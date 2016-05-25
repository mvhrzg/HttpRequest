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
        public string referer = "https://oneport.unca.edu/group/students/home/";
        public static string username = "mherzog";
        public static string password = "*H00a33t00e44!";
        public string url = $"https://oneport.unca.edu/";

        public void CreateRequest()
        {
            //Create GET request for oneport.unca.edu
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Host = "oneport.unca.edu";

            //Set request referer
            //request.Referer = referer;

            //Get username and password
            Console.Write("Enter username: ");
            //username = Console.ReadLine();
            Console.Write(username + "\n");
            Console.Write("Enter password: ");
            //password = Console.ReadLine();
            Console.WriteLine(password);

            //Set username and password
            CredentialCache.DefaultNetworkCredentials.UserName = username;
            CredentialCache.DefaultNetworkCredentials.Password = password;

            //Set up POST request
            //var postData = username;
            //postData += password;
            var data = Encoding.ASCII.GetBytes(username);

            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
            request.Headers["Upgrade-Insecure-Requests"] = "1";
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/50.0.2661.102 Safari/537.36";
            request.ContentType = "application/x-www-form-urlencoded";
            request.Referer = "https://oneport.unca.edu/cas/login?service=https%3A%2F%2Foneport.unca.edu%2Fc%2Fportal%2Flogin";
            request.Method = "POST";
            request.ContentLength = data.Length;
            CredentialCache.DefaultNetworkCredentials.Password = password;
            CredentialCache.DefaultNetworkCredentials.UserName = username;
            request.UseDefaultCredentials = true;
            Console.Write($"request.RequestUri.PathAndQuery: {request.RequestUri.PathAndQuery}\n");// = $"/?username={username}&password={password}";
            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }
            try
            {
                Console.Write($"request.RequestUri.PathAndQuery: {request.RequestUri.PathAndQuery}\n");// = $"/?username={username}&password={password}";

                //CredentialCache.DefaultNetworkCredentials.Domain = url;
                //request.Credentials = CredentialCache.DefaultNetworkCredentials;
                var response = (HttpWebResponse)request.GetResponse();

                Console.Write($"response.ResponseUri.Segments[2].ToString(): {response.ResponseUri.Segments[2].ToString()}");
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                //Console.Write(responseString.ToString());
                if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                {
                    Process.GetCurrentProcess().Kill();
                }
            }
            catch (WebException we)
            {
                Console.Write(we.Message);
            }



            //    try
            //    {
            //        Stream objStream = request.GetResponse().GetResponseStream();
            //        StreamReader objReader = new StreamReader(objStream);
            //        string sLine = "";
            //        int i = 0;

            //        while (sLine != null)
            //        {
            //            i++;
            //            sLine = objReader.ReadLine();
            //            //if (sLine != null)
            //            Console.WriteLine("{0}:{1}", i, sLine);
            //            //Close console if ESC
            //            if (Console.ReadKey(true).Key == ConsoleKey.Escape)
            //            {
            //                Process.GetCurrentProcess().Kill();
            //            }
            //        }
            //    }
            //    catch(WebException we)
            //    {
            //        Console.WriteLine(we.Message);
            //        Console.ReadKey();
            //    }
        }
        static void Main(string[] args)
        {
            HttpRequest r = new HttpRequest();
            r.CreateRequest();
        }
    }
}