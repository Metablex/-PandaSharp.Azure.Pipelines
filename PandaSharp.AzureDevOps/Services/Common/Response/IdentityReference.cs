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

        [JsonProperty("uniqueName")]
        public string UniqueName { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("imageUrl")]
        public string ImageUrl { get; set; }

        [JsonProperty("_links")]
        public ReferenceLinkListResponse ReferenceLinks { get; set; }
    }
}