using Newtonsoft.Json;
using PandaSharp.AzureDevOps.Services.Common.Contract;
using PandaSharp.Framework.Attributes;
using PandaSharp.Framework.Services.Converter;
using PandaSharp.Framework.Services.Response;

namespace PandaSharp.AzureDevOps.Services.Build.Response
{
    [JsonConverter(typeof(RootElementResponseConverter<BuildListResponse, BuildResponse>))]
    [JsonRootElementPath("value")]
    [JsonListContentPath("value.[*]")]
    public sealed class BuildListResponse : ListResponseBase<BuildResponse>, IPaginationSupportedResponse
    {
        public string ContinuationToken { get; set; }
    }
}