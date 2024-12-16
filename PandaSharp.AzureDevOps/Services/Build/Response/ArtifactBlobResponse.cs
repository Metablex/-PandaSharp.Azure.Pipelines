using Newtonsoft.Json;

namespace PandaSharp.AzureDevOps.Services.Build.Response
{
    public sealed class ArtifactBlobResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("size")]
        public long Size { get; set; }
    }
}
