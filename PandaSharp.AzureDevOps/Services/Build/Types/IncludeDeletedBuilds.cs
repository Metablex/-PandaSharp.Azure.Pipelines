using Newtonsoft.Json;
using PandaSharp.Framework.Attributes;
using PandaSharp.Framework.Services.Converter;

namespace PandaSharp.AzureDevOps.Services.Build.Types
{
    [JsonConverter(typeof(EnumToStringRepresentationConverter))]
    public enum IncludeDeletedBuilds
    {
        [StringRepresentation("excludeDeleted")]
        ExcludeDeleted,
        
        [StringRepresentation("includeDeleted")]
        IncludeDeleted,
        
        [StringRepresentation("onlyDeleted")]
        OnlyDeleted
    }
}