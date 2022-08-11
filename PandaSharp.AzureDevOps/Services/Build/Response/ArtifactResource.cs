using System.Collections.Generic;
using Newtonsoft.Json;

namespace PandaSharp.AzureDevOps.Services.Build.Response
{
    public sealed class ArtifactResource
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("data")]
        public string DataId { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("downloadUrl")]
        public string DownloadUrl { get; set; }

        [JsonProperty("properties")]
        public Dictionary<string, object> Properties { get; set; }
    }
}