using Newtonsoft.Json;
using PandaSharp.Framework.Attributes;
using PandaSharp.Framework.Services.Converter;

namespace PandaSharp.AzureDevOps.Services.Build.Types
{
    [JsonConverter(typeof(EnumToStringRepresentationConverter))]
    public enum BuildStatus
    {
        [StringRepresentation("none")]
        NoStatus,
        
        [StringRepresentation("cancelling")]
        Cancelling,
        
        [StringRepresentation("completed")]
        Completed,
        
        [StringRepresentation("inProgress")]
        InProgress,
        
        [StringRepresentation("notStarted")]
        NotStarted,
        
        [StringRepresentation("postponed")]
        Postponed,
        
        [StringRepresentation("all")]
        AllStatus
    }
}