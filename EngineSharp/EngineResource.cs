using System;
using RestSharp;
using System.Text;
using System.Collections.Generic;
using System.Net;

namespace EngineSample
{
  public class EngineResource
	{
    public EngineResource() {}

    public int id { get; set; } 

    // Replace these with your own API key and secret from config
		private static string api_key = "4F058B962F98EBC48684369E1825268A";
		private static string api_secret = "8496DBDFF8AEA7D6B8748C2A33FB9258";
    private static string base_path = "http://staging.engine.co.za/v1/property";
		private static RestClient client;

		protected static IRestRequest CreateRequest(string path, Method method) {
			var request	= new RestRequest (path, method);
      request.RequestFormat = DataFormat.Json;
      request.AddHeader ("Content-Type", "application/json");
			request.AddHeader ("Accept", "application/json");
      var basic_auth = Convert.ToBase64String (Encoding.Default.GetBytes (api_key + ":" + api_secret));
			request.AddHeader ("Authorization", "Basic " + basic_auth);
			return request;
		}

		protected static RestClient Client() {
			if (client == null)
				client = new RestClient (base_path);
			return client;
		}

    public static List<T> All<T>(string path) where T : EngineResource, new() {
      IRestRequest request = CreateRequest (path, Method.GET);
      IRestResponse<List<T>> resources = Client().Execute<List<T>> (request);
      return resources.Data;
    }

    public static T Create<T>(T resource, string path) where T : EngineResource, new() {
      IRestRequest request = CreateRequest (path, Method.POST);
      request.AddBody (resource);
      IRestResponse<T> response = Client().Execute<T> (request);
      if (response.StatusCode != HttpStatusCode.Created)
        throw new InvalidOperationException ("Create failed: " + response.StatusCode.ToString ());
      return response.Data;
    }
      
    public static T Update<T>(T resource, string path) where T : EngineResource, new() {
      IRestRequest request = CreateRequest (path + "/" + resource.id, Method.PATCH);
      request.AddBody (resource);
      IRestResponse<T> response = Client ().Execute<T> (request);
      if (response.StatusCode != HttpStatusCode.OK)
        throw new InvalidOperationException ("Update failed: " + response.StatusCode.ToString ());
      return response.Data;
    }

	}
}

