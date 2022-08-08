using Newtonsoft.Json;
using PandaSharp.AzureDevOps.Services.Common.Response;

namespace PandaSharp.AzureDevOps.Services.Git.Response
{
    public sealed class GitRepositoryResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("defaultBranch")]
        public string DefaultBranch { get; set; }
        
        [JsonProperty("remoteUrl")]
        public string RemoteUrl { get; set; }
        
        [JsonProperty("sshUrl")]
        public string SshUrl { get; set; }
        
        [JsonProperty("webUrl")]
        public string WebUrl { get; set; }
        
        [JsonProperty("isDisabled")]
        public bool IsDisabled { get; set; }
        
        [JsonProperty("_links")]
        public ReferenceLinkListResponse ReferenceLinks { get; set; }
        
        [JsonProperty("validRemoteUrls")]
        public string[] ValidRemoteUrls { get; set; }
    }
}