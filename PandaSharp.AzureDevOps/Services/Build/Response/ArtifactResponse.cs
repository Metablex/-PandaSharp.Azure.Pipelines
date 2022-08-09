using Newtonsoft.Json;

namespace PandaSharp.AzureDevOps.Services.Build.Response
{
    public sealed class ArtifactResponse
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("resource")]
        public ArtifactResource Resource { get; set; }
    }
}