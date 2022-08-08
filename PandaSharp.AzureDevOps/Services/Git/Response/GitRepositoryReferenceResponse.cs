using Newtonsoft.Json;

namespace PandaSharp.AzureDevOps.Services.Git.Response
{
    public sealed class GitRepositoryReferenceResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("remoteUrl")]
        public string RemoteUrl { get; set; }

        [JsonProperty("sshUrl")]
        public string SshUrl { get; set; }

        [JsonProperty("webUrl")]
        public string WebUrl { get; set; }

        [JsonProperty("isFork")]
        public bool IsFork { get; set; }
    }
}