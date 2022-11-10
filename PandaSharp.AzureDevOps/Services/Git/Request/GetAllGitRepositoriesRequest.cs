using PandaSharp.AzureDevOps.Context;
using PandaSharp.AzureDevOps.Services.Common.Rest;
using PandaSharp.AzureDevOps.Services.Git.Aspect;
using PandaSharp.AzureDevOps.Services.Git.Contract;
using PandaSharp.AzureDevOps.Services.Git.Response;
using PandaSharp.Framework.Attributes;
using PandaSharp.Framework.Rest.Contract;
using PandaSharp.Framework.Services.Aspect;
using PandaSharp.Framework.Services.Request;
using RestSharp;

namespace PandaSharp.AzureDevOps.Services.Git.Request
{
    [SupportsParameterAspect(typeof(IGetAllGitRepositoriesParameterAspect))]
    [RestResponseConverter(typeof(RestResponseConverter))]
    internal sealed class GetAllGitRepositoriesRequest : RequestBase<GitRepositoryListResponse>, IGetAllGitRepositoriesRequest
    {
        private readonly IInstanceMetaInformation _instanceMetaInformation;

        public GetAllGitRepositoriesRequest(IInstanceMetaInformation instanceMetaInformation, IRestFactory restClientFactory, IRequestParameterAspectFactory parameterAspectFactory, IRestResponseConverterFactory responseConverterFactory)
            : base(restClientFactory, parameterAspectFactory, responseConverterFactory)
        {
            _instanceMetaInformation = instanceMetaInformation;
        }

        public IGetAllGitRepositoriesRequest IncludeAllRemoteUrls()
        {
            GetAspect<IGetAllGitRepositoriesParameterAspect>().SetIncludeAllRemoteUrls(true);
            return this;
        }

        public IGetAllGitRepositoriesRequest IncludeHidden()
        {
            GetAspect<IGetAllGitRepositoriesParameterAspect>().SetIncludeHidden(true);
            return this;
        }

        public IGetAllGitRepositoriesRequest IncludeReferenceLinks()
        {
            GetAspect<IGetAllGitRepositoriesParameterAspect>().SetIncludeReferenceLinks(true);
            return this;
        }

        protected override string GetResourcePath()
        {
            return $"{_instanceMetaInformation.Organization}/{_instanceMetaInformation.Project}/_apis/git/repositories";
        }

        protected override Method GetRequestMethod()
        {
            return Method.GET;
        }
    }
}