using Newtonsoft.Json;
using PandaSharp.Framework.Attributes;
using PandaSharp.Framework.Services.Converter;

namespace PandaSharp.AzureDevOps.Services.Build.Types
{
    [JsonConverter(typeof(EnumToStringRepresentationConverter))]
    public enum BuildPriority
    {
        [StringRepresentation("low")]
        Low,
        
        [StringRepresentation("belowNormal")]
        BelowNormal,
        
        [StringRepresentation("normal")]
        Normal,
        
        [StringRepresentation("aboveNormal")]
        AboveNormal,
        
        [StringRepresentation("high")]
        High
    }
}