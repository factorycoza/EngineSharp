using System;
using RestSharp;
using System.Text;
using System.Collections.Generic;
using System.Net;

namespace EngineSample
{
    public class EngineResource
    {
        public EngineResource() { }

        public int id { get; set; }

        // Replace these with your own API key and secret from config
        private const string ApiKey = "4F058B962F98EBC48684369E1825268A";
        private const string ApiSecret = "8496DBDFF8AEA7D6B8748C2A33FB9258";
        private const string BasePath = "http://staging.engine.co.za/v1/property";
        private static RestClient _client;

        protected static IRestRequest CreateRequest(string path, Method method)
        {
            var request = new RestRequest(path, method);
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");
            var basicAuth = Convert.ToBase64String(Encoding.Default.GetBytes(ApiKey + ":" + ApiSecret));
            request.AddHeader("Authorization", "Basic " + basicAuth);
            return request;
        }

        protected static RestClient Client()
        {
            if (_client == null)
                _client = new RestClient(BasePath);
            return _client;
        }

        public static List<T> All<T>(string path) where T : EngineResource, new()
        {
            var request = CreateRequest(path, Method.GET);
            var resources = Client().Execute<List<T>>(request);
            return resources.Data;
        }

        public static T Create<T>(T resource, string path) where T : EngineResource, new()
        {
            var request = CreateRequest(path, Method.POST);
            request.AddBody(resource);
            var response = Client().Execute<T>(request);
            if (response.StatusCode != HttpStatusCode.Created)
                throw new InvalidOperationException("Create failed: " + response.StatusCode.ToString());
            return response.Data;
        }

        public static T Update<T>(T resource, string path) where T : EngineResource, new()
        {
            var request = CreateRequest(path + "/" + resource.id, Method.PATCH);
            request.AddBody(resource);
            var response = Client().Execute<T>(request);
            if (response.StatusCode != HttpStatusCode.OK)
                throw new InvalidOperationException("Update failed: " + response.StatusCode.ToString());
            return response.Data;
        }

    }
}

