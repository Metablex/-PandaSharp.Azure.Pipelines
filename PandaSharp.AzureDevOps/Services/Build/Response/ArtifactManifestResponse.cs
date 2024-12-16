using Newtonsoft.Json;

namespace PandaSharp.AzureDevOps.Services.Build.Response
{
    public sealed class ArtifactManifestResponse
    {
        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("blob")]
        public ArtifactBlobResponse Information { get; set; }
    }
}
