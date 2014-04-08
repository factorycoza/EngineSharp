using System;
using System.Configuration;
using System.Globalization;
using RestSharp;
using System.Collections.Generic;
using System.Net;

namespace EngineSample
{
    public class EngineResource
    {
        public int Id { get; set; }

        // Replace these with your own API key and secret from config
        private readonly static string ApiKey = ConfigurationManager.AppSettings["ApiKey"];
        private readonly static string ApiSecret = ConfigurationManager.AppSettings["ApiSecret"];
        private const string BasePath = "https://staging.engine.co.za/v1/property";

        protected static IRestRequest CreateRequest(string path, Method method)
        {
            var request = new RestRequest(path, method)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new EngineSerializer()
            };

            //Required headers
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");
            return request;
        }

        protected static RestClient CreateClient()
        {
            // Restsharp is not thread safe so do not share instances
            // of the same object
            var restClient = new RestClient(BasePath)
            {
                Authenticator = new HttpBasicAuthenticator(ApiKey, ApiSecret)
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
                throw new InvalidOperationException("Create failed: " + response.StatusCode);
            return response.Data;
        }

        public static T Update<T>(T resource, string path) where T : EngineResource, new()
        {
            var request = CreateRequest(path + "/{id}", Method.PATCH);
            request.AddUrlSegment("id", resource.Id.ToString(CultureInfo.InvariantCulture));
            request.AddBody(resource);
            var client = CreateClient();
            var response = client.Execute<T>(request);
            if (response.StatusCode != HttpStatusCode.OK)
                throw new InvalidOperationException("Update failed: " + response.StatusCode);
            return response.Data;
        }        
    }
}

