using Newtonsoft.Json;
using PandaSharp.Framework.Attributes;
using PandaSharp.Framework.Services.Converter;

namespace PandaSharp.AzureDevOps.Services.Build.Types
{
    [JsonConverter(typeof(EnumToStringRepresentationConverter))]
    public enum BuildReason
    {
        [StringRepresentation("none")]
        NoReason,
        
        [StringRepresentation("all")]
        AllReasons,
        
        [StringRepresentation("batchedCI")]
        BatchedCi,
        
        [StringRepresentation("buildCompletion")]
        BuildCompletion,
        
        [StringRepresentation("checkInShelveset")]
        CheckInShelveset,
        
        [StringRepresentation("individualCI")]
        IndividualCi,
        
        [StringRepresentation("manual")]
        Manual,
        
        [StringRepresentation("pullRequest")]
        PullRequest,
        
        [StringRepresentation("resourceTrigger")]
        ResourceTrigger,
        
        [StringRepresentation("schedule")]
        Schedule,
        
        [StringRepresentation("scheduleForced")]
        ScheduleForced,
        
        [StringRepresentation("triggered")]
        Triggered,
        
        [StringRepresentation("userCreated")]
        UserCreated,
        
        [StringRepresentation("validateShelveset")]
        ValidateShelveset
    }
}