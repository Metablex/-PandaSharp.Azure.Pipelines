using Newtonsoft.Json;

namespace PandaSharp.AzureDevOps.Services.Build.Response
{
    public sealed class ArtifactResource
    {
        [JsonProperty("type")] 
        public string Type { get; set; }

        [JsonProperty("downloadUrl")]
        public string DownloadUrl { get; set; }
    }
}