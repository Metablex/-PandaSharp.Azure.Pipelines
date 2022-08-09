using Newtonsoft.Json;
using PandaSharp.Framework.Attributes;
using PandaSharp.Framework.Services.Converter;

namespace PandaSharp.AzureDevOps.Services.Build.Types
{
    [JsonConverter(typeof(EnumToStringRepresentationConverter))]
    public enum BuildResult
    {
        [StringRepresentation("none")]
        NoResult,
        
        [StringRepresentation("canceled")]
        Canceled,
        
        [StringRepresentation("failed")]
        Failed,
        
        [StringRepresentation("partiallySucceeded")]
        PartiallySucceeded,
        
        [StringRepresentation("succeeded")]
        Succeeded
    }
}