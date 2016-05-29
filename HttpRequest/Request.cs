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

namespace HttpRequest
{

    class CustomConverter : ISerializer, IDeserializer
    {
        private static readonly JsonSerializerSettings SerializerSettings;

        static CustomConverter()
        {
            SerializerSettings = new JsonSerializerSettings
            {
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                Converters = new List<JsonConverter> { new IsoDateTimeConverter() },
                NullValueHandling = NullValueHandling.Ignore
            };
        }

        public string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.None, SerializerSettings);
        }

        public T Deserialize<T>(IRestResponse response)
        {
            var type = typeof(T);

            return (T)JsonConvert.DeserializeObject(response.Content, type, SerializerSettings);
        }

        string IDeserializer.RootElement { get; set; }
        string IDeserializer.Namespace { get; set; }
        string IDeserializer.DateFormat { get; set; }
        string ISerializer.RootElement { get; set; }
        string ISerializer.Namespace { get; set; }
        string ISerializer.DateFormat { get; set; }
        public string ContentType { get; set; }
    }


    class HttpRequest
    {
        public string username = "mherzog";
        public string password = "*H00a33t00e44!";
        public int _timeout = 3000;

        public IRestRequest ICreateRequest(Uri uri, Method method, object body)
        {
            IRestRequest request = new RestRequest(uri, method);
            request.Resource = uri.ToString();
            request.Timeout = _timeout;
            CredentialCache.DefaultNetworkCredentials.Password = password;
            CredentialCache.DefaultNetworkCredentials.UserName = username;
            request.Credentials = CredentialCache.DefaultNetworkCredentials;


            if (body != null)
            {
                request.AddHeader("Content-Type", "application/json");
                request.RequestFormat = DataFormat.Json;
                request.JsonSerializer = new CustomConverter { ContentType = "application/json" };
                request.AddBody(body);
            }
            return request;
        }


        public void CreateRequest()
        {
            var client = new RestClient();

            client.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/50.0.2661.102 Safari/537.36";
            //for(int i = 0; i < client.DefaultParameters.Count; i++)
            //{
            //    Console.Write(client.DefaultParameters[i].ToString());
            //}
            client.BaseUrl = new Uri("https://oneport.unca.edu/c/portal/login?_eventId=submit&It=_c14CC922F-342C-6157-9899-9E7122310C47_k383B74A2-FB7D-AB60-35E5-9488FBA7C97F&password=*H00a33t00e44!&username=mherzog");
            client.Authenticator = new HttpBasicAuthenticator(username, password);

            var myrequest = new RestRequest(Method.POST);

            //request.Resource = $"/c/portal/login?p_l_id=16294";

            //request.Resource =  "statuses/friends_timeline.xml";
            //for (int i = 0; i < ICreateRequest(client.BaseUrl, myrequest.Method, client).Parameters.Count; i++)
            //{
                //var icr = ICreateRequest(client.BaseUrl, myrequest.Method, client);
            IRestResponse response = client.Execute(myrequest);
            Console.Write(response.ResponseUri);

            Console.WriteLine(response.Content);
            //System.IO.File.WriteAllText(@"C:/Users/mvher/Desktop/response.txt", response.Content);
            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            HttpRequest r = new HttpRequest();
            r.CreateRequest();
        }
    }
}
