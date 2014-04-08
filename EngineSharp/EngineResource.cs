using System;
using System.Configuration;
using System.Reflection.Emit;
using RestSharp;
using System.Text;
using System.Collections.Generic;
using System.Net;

namespace EngineSample
{
    public class EngineResource
    {
        public int Id { get; set; }

        // Replace these with your own API key and secret from config
        private readonly static string ApiKey = ConfigurationManager.AppSettings["4F058B962F98EBC48684369E1825268A"];
        private readonly static string ApiSecret = ConfigurationManager.AppSettings["8496DBDFF8AEA7D6B8748C2A33FB9258"];
        private const string BasePath = "https://staging.engine.co.za/v1/property";

        protected static IRestRequest CreateRequest(string path, Method method)
        {
            var request = new RestRequest(path, method)
            {
                RequestFormat = DataFormat.Json
            };
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");
            var basicAuth = Convert.ToBase64String(Encoding.Default.GetBytes(ApiKey + ":" + ApiSecret));
            request.AddHeader("Authorization", "Basic " + basicAuth);
            return request;
        }

        protected static RestClient CreateClient()
        {
            // Restsharp is not thread safe so do not share instances
            // of the same object
            var restClient = new RestClient(BasePath)
            {
                Authenticator = new HttpBasicAuthenticator(ApiKey, ApiSecret),
                FollowRedirects = true,
                Proxy = new WebProxy("localhost", 8888)
            };
            return restClient;
        }

        public static List<T> All<T>(string path) where T : EngineResource, new()
        {
            var request = CreateRequest(path, Method.GET);
            var client = CreateClient();
            var resources = client.Execute<List<T>>(request);
            return resources.Data;
        }

        public static T Create<T>(T resource, string path) where T : EngineResource, new()
        {
            var request = CreateRequest(path, Method.POST);
            request.AddBody(resource);
            var client = CreateClient();
            var response = client.Execute<T>(request);
            if (response.StatusCode != HttpStatusCode.Created)
                throw new InvalidOperationException("Create failed: " + response.StatusCode.ToString());
            return response.Data;
        }

        public static T Update<T>(T resource, string path) where T : EngineResource, new()
        {
            var request = CreateRequest(path + "/" + resource.Id, Method.PATCH);
            request.AddBody(resource);
            var client = CreateClient();
            var response = client.Execute<T>(request);
            if (response.StatusCode != HttpStatusCode.OK)
                throw new InvalidOperationException("Update failed: " + response.StatusCode.ToString());
            return response.Data;
        }

    }
}

