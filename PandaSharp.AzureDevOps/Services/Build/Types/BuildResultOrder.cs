using Newtonsoft.Json;
using PandaSharp.Framework.Attributes;
using PandaSharp.Framework.Services.Converter;

namespace PandaSharp.AzureDevOps.Services.Build.Types
{
    [JsonConverter(typeof(EnumToStringRepresentationConverter))]
    public enum BuildResultOrder
    {
        [StringRepresentation("finishTimeAscending")]
        OrderByFinishTimeAscending,
        
        [StringRepresentation("finishTimeDescending")]
        OrderByFinishTimeDescending,
        
        [StringRepresentation("queueTimeAscending")]
        OrderByQueueTimeAscending,
        
        [StringRepresentation("queueTimeDescending")]
        OrderByQueueTimeDescending,
        
        [StringRepresentation("startTimeAscending")]
        OrderByStartTimeAscending,
        
        [StringRepresentation("startTimeDescending")]
        OrderByStartTimeDescending
    }
}