using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace EngineSample
{
    public class EngineMappingResolver : DefaultContractResolver
    {
        // Format Properties to the lowercase underscore convention
        protected override string ResolvePropertyName(string propertyName)
        {
            return System.Text.RegularExpressions.Regex.Replace(
                propertyName, @"([A-Z])([A-Z][a-z])|([a-z0-9])([A-Z])", "$1$3_$2$4").ToLower();
        }

        // Exclude the id when posting
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);

            if (property.DeclaringType == typeof(EngineResource) && property.PropertyName == "Id")
            {
                property.ShouldSerialize = delegate
                {
                    return false;
                };
            }

            return property;
        }
    }
}