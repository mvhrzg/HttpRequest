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
        public string url = "http://oneport.unca.edu";
        public string referer = "https://oneport.unca.edu/group/students/home/";
        public string username;
        public string password;

        public void CreateRequest()
        {
            //Create GET request for oneport.unca.edu
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Host = "oneport.unca.edu";
            
            //Set request referer
            request.Referer = referer;

            //Get username and password
            Console.Write("Enter username: ");
            username = Console.ReadLine();
            Console.Write("Enter password: ");
            password = Console.ReadLine();

            //Set username and password
            CredentialCache.DefaultNetworkCredentials.UserName = username;
            CredentialCache.DefaultNetworkCredentials.Password = password;

            //Set up POST request
            var postData = username + password;
            var data = Encoding.ASCII.GetBytes(postData);

            //Set request credentials to above

            //Set user-agent from postman
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/50.0.2661.102 Safari/537.36";

            //Create request method
            request.Method = "POST";

            //Set content type
            request.ContentType = "application/x-www-form-urlencoded";//"text/plain;charset=UTF-8";


            request.Method = "POST";
            request.ContentLength = data.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }
            try
            {
                request.Credentials = CredentialCache.DefaultNetworkCredentials;
                var response = (HttpWebResponse)request.GetResponse();
                
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                Console.Write(responseString.ToString());
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