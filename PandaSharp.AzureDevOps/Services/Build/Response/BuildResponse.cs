using System;
using Newtonsoft.Json;
using PandaSharp.AzureDevOps.Services.Build.Types;
using PandaSharp.AzureDevOps.Services.Common.Response;

namespace PandaSharp.AzureDevOps.Services.Build.Response
{
    public sealed class BuildResponse
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        
        [JsonProperty("buildNumber")]
        public string Number { get; set; }
        
        [JsonProperty("buildNumberRevision")]
        public int Revision { get; set; }
        
        [JsonProperty("status")]
        public BuildStatus Status { get; set; }
        
        [JsonProperty("result")]
        public BuildResult Result { get; set; }
        
        [JsonProperty("reason")]
        public BuildReason Reason { get; set; }
        
        [JsonProperty("priority")]
        public BuildPriority Priority { get; set; }
        
        [JsonProperty("queueTime")]
        public DateTime QueueTime { get; set; }
        
        [JsonProperty("startTime")]
        public DateTime StartTime { get; set; }
        
        [JsonProperty("finishTime")]
        public DateTime FinishTime { get; set; }
        
        [JsonProperty("requestedBy")]
        public IdentityReference RequestedBy { get; set; }
        
        [JsonProperty("requestedFor")]
        public IdentityReference RequestedFor { get; set; }
        
        [JsonProperty("sourceBranch")]
        public string SourceBranch { get; set; }
        
        [JsonProperty("sourceVersion")]
        public string SourceVersion { get; set; }
        
        [JsonProperty("_links")]
        public ReferenceLinkListResponse ReferenceLinks { get; set; }
    }
}