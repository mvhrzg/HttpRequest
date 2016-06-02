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
using RestSharp.Serializers;
using RestSharp.Deserializers;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel;

namespace HttpRequest
{

    class HttpRequest
    {
        public string username = "mherzog";
        public string password = "*H00a33t00e44!";

        public void CreateRequest()
        {
            var client = new RestClient("https://oneport.unca.edu/cas/login?p_l_id=16294&%3Bp_p_id=56_INSTANCE_C8Hw&%3Bp_p_restore=false&%3BdoAsUserId=&%3Bcmd=minimize&%3Breferer=%25252Fc%25252Fportal%25252Flayout%25253Fp_l_id%25253D16294%252526doAsUserId%25253D&%3Brefresh=1");
            var request = new RestRequest(Method.POST);
            request.AddHeader("postman-token", "24113e63-b301-2c56-0498-3d3478fb06ba");
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("authorization", "Basic bWhlcnpvZzoqSDAwYTMzdDAwZTQ0IQ==");
            request.AddHeader("cookie", "JSESSIONID=BE509984F3543B1422308012A765B66B; _ga=GA1.2.827633366.1464042219; viewedAlerts=true; JSESSIONID=FF36F39B87A3EBB1851BDAB64C713F8F; _ga=GA1.2.827633366.1464042219; viewedAlerts=true; JSESSIONID=BC8B6F560368158BCED5E0EDF9A7C3E2");
            request.AddHeader("accept-language", "en-US,en;q=0.8,pt;q=0.6");
            request.AddHeader("accept-encoding", "gzip, deflate");
            request.AddHeader("referer", "https://oneport.unca.edu/cas/login?service=https%3A%2F%2Foneport.unca.edu%2Fc%2Fportal%2Flogin");
            request.AddHeader("content-type", "application/javascript");
            request.AddHeader("user-agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/50.0.2661.102 Safari/537.36");
            request.AddHeader("upgrade-insecure-requests", "1");
            request.AddHeader("origin", "https://oneport.unca.edu");
            request.AddHeader("accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8");
            request.AddParameter("application/javascript", "var settings = {\r\n  \"async\": true,\r\n  \"crossDomain\": true,\r\n  \"url\": \"https://oneport.unca.edu/cas/login?p_l_id=16294&%3Bp_p_id=56_INSTANCE_C8Hw&%3Bp_p_restore=false&%3BdoAsUserId=&%3Bcmd=minimize&%3Breferer=%25252Fc%25252Fportal%25252Flayout%25253Fp_l_id%25253D16294%252526doAsUserId%25253D&%3Brefresh=1&_eventId=submit\",\r\n  \"method\": \"POST\",\r\n  \"headers\": {\r\n    \"accept\": \"text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8\",\r\n    \"origin\": \"https://oneport.unca.edu\",\r\n    \"upgrade-insecure-requests\": \"1\",\r\n    \"user-agent\": \"Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/50.0.2661.102 Safari/537.36\",\r\n    \"content-type\": \"application/json\",\r\n    \"referer\": \"https://oneport.unca.edu/cas/login?service=https%3A%2F%2Foneport.unca.edu%2Fc%2Fportal%2Flogin\",\r\n    \"accept-encoding\": \"gzip, deflate\",\r\n    \"accept-language\": \"en-US,en;q=0.8,pt;q=0.6\",\r\n    \"cookie\": \"JSESSIONID=BE509984F3543B1422308012A765B66B; _ga=GA1.2.827633366.1464042219; viewedAlerts=true; JSESSIONID=FF36F39B87A3EBB1851BDAB64C713F8F; _ga=GA1.2.827633366.1464042219; viewedAlerts=true; JSESSIONID=BC8B6F560368158BCED5E0EDF9A7C3E2\",\r\n    \"authorization\": \"Basic bWhlcnpvZzoqSDAwYTMzdDAwZTQ0IQ==\",\r\n    \"cache-control\": \"no-cache\",\r\n    \"postman-token\": \"f44071be-1061-56b4-a95b-567ac10612ed\"\r\n  },\r\n  \"data\": {}\r\n}\r\n\r\n$.ajax(settings).done(function (response) {\r\n  console.log(response);\r\n});", ParameterType.RequestBody);
            request.AddHeader("password", password);
            request.AddHeader("username", username);
            IRestResponse response = client.Execute(request);

            Console.Write(response.ResponseUri);

            Console.WriteLine(response.Content);
            
            System.IO.File.WriteAllText(@"C:/Users/mvher/Desktop/responses/"+concat()+".html", response.Content);
            Console.ReadLine();
        }

        public string concat()
        {
            string responseText = DateTime.Now.ToString();
            char[] separator = { ':', '/', ' ' };
            string[] r = responseText.Split(separator);
            string now = string.Empty;
            for(int i = 0; i < r.Length; i++)
            {
                now += r[i];
            }
            return now;
        }

        static void Main(string[] args)
        {
            HttpRequest r = new HttpRequest();
            r.CreateRequest();
        }
    }
}
