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
        public string url = "https://oneport.unca.edu/group/students/home/";//"http://oneport.unca.edu";
        public string username;
        public string password;

        public void CreateRequest()
        {
            //Create GET request for oneport.unca.edu
            WebRequest request = WebRequest.Create(url);

            Console.Write("Enter username: ");
            username = Console.ReadLine();
            Console.Write("Enter password: ");
            password = Console.ReadLine();

            //Set username and password
            CredentialCache.DefaultNetworkCredentials.UserName = username;
            CredentialCache.DefaultNetworkCredentials.Password = password;
            //Set request credentials to above
            request.Credentials = CredentialCache.DefaultNetworkCredentials;

            //Set user-agent from postman
            ((HttpWebRequest)request).UserAgent = " Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/50.0.2661.102 Safari/537.36";

            //Create POST request
            request.Method = "post";

            //Set content length
            //request.ContentLength = 3030;

            //Set content type
            request.ContentType = "text/plain;charset=UTF-8";

            try
            {
                Stream objStream = request.GetResponse().GetResponseStream();
                StreamReader objReader = new StreamReader(objStream);
                string sLine = "";
                int i = 0;

                while (sLine != null)
                {
                    i++;
                    sLine = objReader.ReadLine();
                    //if (sLine != null)
                    Console.WriteLine("{0}:{1}", i, sLine);
                    //Close console if ESC
                    if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                    {
                        Process.GetCurrentProcess().Kill();
                    }
                }
            }
            catch(WebException we)
            {
                Console.WriteLine(we.Message);
                Console.ReadKey();
            }
        }
		static void Main(string[] args)
        {
            HttpRequest r = new HttpRequest();
            r.CreateRequest();
        }
    }
}