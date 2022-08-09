using Newtonsoft.Json;
using PandaSharp.AzureDevOps.Services.Common.Converter;
using PandaSharp.Framework.Services.Response;

namespace PandaSharp.AzureDevOps.Services.Common.Response
{
    [JsonConverter(typeof(ReferenceLinkListResponseConverter))]
    public sealed class ReferenceLinkListResponse : ListResponseBase<ReferenceLinkResponse>
    {
    }
}