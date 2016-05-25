using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Diagnostics;
using RestSharp;
using RestSharp.Authenticators;

namespace HttpRequest
{
    class HttpRequest
    {
        public string username = "mherzog";
        public string password = "*H00a33t00e44!";
        public void CreateRequest()
        {
            var client = new RestClient();
            client.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/50.0.2661.102 Safari/537.36";
            //for(int i = 0; i < client.DefaultParameters.Count; i++)
            //{
            //    Console.Write(client.DefaultParameters[i].ToString());
            //}
            Console.Write(client.HttpFactory);
            client.BaseUrl = new Uri("http://oneport.unca.edu");
            client.Authenticator = new HttpBasicAuthenticator(username, password);


            var request = new RestRequest(Method.GET);
            //request.Resource =  "statuses/friends_timeline.xml";

            IRestResponse response = client.Execute(request);

            Console.WriteLine(response.Content);
            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            HttpRequest r = new HttpRequest();
            r.CreateRequest();
        }
    }
}
