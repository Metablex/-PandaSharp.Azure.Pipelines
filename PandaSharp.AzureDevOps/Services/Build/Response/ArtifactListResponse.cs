using Newtonsoft.Json;
using PandaSharp.Framework.Attributes;
using PandaSharp.Framework.Services.Converter;
using PandaSharp.Framework.Services.Response;

namespace PandaSharp.AzureDevOps.Services.Build.Response
{
    [JsonConverter(typeof(RootElementResponseConverter<ArtifactListResponse, ArtifactResponse>))]
    [JsonListContentPath("value.[*]")]
    public sealed class ArtifactListResponse : ListResponseBase<ArtifactResponse>
    {
    }
}