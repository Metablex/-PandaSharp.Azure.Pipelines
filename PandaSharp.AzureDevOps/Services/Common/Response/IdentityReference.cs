using System;
using Newtonsoft.Json;

namespace PandaSharp.AzureDevOps.Services.Common.Response
{
    public sealed class IdentityReference
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
        
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }
        
        [JsonProperty("descriptor")]
        public string Descriptor { get; set; }
    }
}