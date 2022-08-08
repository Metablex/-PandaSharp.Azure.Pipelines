using Newtonsoft.Json;
using PandaSharp.Framework.Attributes;
using PandaSharp.Framework.Services.Converter;
using PandaSharp.Framework.Services.Response;

namespace PandaSharp.AzureDevOps.Services.Git.Response
{
    [JsonConverter(typeof(RootElementResponseConverter<GitRepositoryListResponse, GitRepositoryResponse>))]
    [JsonListContentPath("value.[*]")]
    public sealed class GitRepositoryListResponse : ListResponseBase<GitRepositoryResponse>
    {
    }
}