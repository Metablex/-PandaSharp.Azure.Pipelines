using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PandaSharp.AzureDevOps.Services.Common.Response;

namespace PandaSharp.AzureDevOps.Services.Common.Converter
{
    public sealed class ReferenceLinkListResponseConverter : JsonConverter<ReferenceLinkListResponse>
    {
        public override bool CanWrite => false;

        public override void WriteJson(JsonWriter writer, ReferenceLinkListResponse value, JsonSerializer serializer)
        {
        }

        public override ReferenceLinkListResponse ReadJson(JsonReader reader, Type objectType, ReferenceLinkListResponse existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var referenceLinkList = new ReferenceLinkListResponse();
            
            var json = JObject.Load(reader);
            foreach (var keys in json)
            {
                if (keys.Value is JObject values)
                {
                    var linkProperty = values.Property("href");
                    if (linkProperty?.Value is JValue value)
                    {
                        var referenceLink = new ReferenceLinkResponse
                        {
                            Key = keys.Key,
                            Url = (string)value.Value
                        };
                        
                        referenceLinkList.AddResponse(referenceLink);
                    }
                }
            }
            
            return referenceLinkList;
        }
    }
}