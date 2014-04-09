using Newtonsoft.Json;
using RestSharp.Serializers;

namespace EngineSample
{
    public class EngineSerializer : ISerializer
    {
        public EngineSerializer()
        {
            ContentType = "application/json";
        }

        public string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj, new JsonSerializerSettings
            {
                ContractResolver = new EngineMappingResolver(),
                NullValueHandling = NullValueHandling.Ignore
            });
        }

        public string RootElement { get; set; }
        public string Namespace { get; set; }
        public string DateFormat { get; set; }
        public string ContentType { get; set; }
    }
}