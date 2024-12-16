using PandaSharp.AzureDevOps.Services.Common.Rest;
using PandaSharp.AzureDevOps.Services.Git.Aspect;
using PandaSharp.AzureDevOps.Services.Git.Contract;
using PandaSharp.AzureDevOps.Services.Git.Response;
using PandaSharp.AzureDevOps.Services.Git.Types;
using PandaSharp.Framework.Attributes;
using PandaSharp.Framework.Rest.Contract;
using PandaSharp.Framework.Services.Aspect;
using PandaSharp.Framework.Services.Contract;
using PandaSharp.Framework.Services.Request;
using RestSharp;

namespace PandaSharp.AzureDevOps.Services.Git.Request
{
    [SupportsParameterAspect(typeof(IGetAllGitRepositoriesParameterAspect))]
    [RestResponseConverter(typeof(RestResponseConverter))]
    internal sealed class GetAllGitRepositoriesRequest : RequestBase<GitRepositoryListResponse>, IGetAllGitRepositoriesRequest
    {
        private readonly IRestCommunicationContext _restCommunicationContext;

        public GetAllGitRepositoriesRequest(IRestCommunicationContext restCommunicationContext, IRestFactory restClientFactory, IRequestParameterAspectFactory parameterAspectFactory, IRestResponseConverterFactory responseConverterFactory)
            : base(restClientFactory, parameterAspectFactory, responseConverterFactory)
        {
            _restCommunicationContext = restCommunicationContext;
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
            var organization = _restCommunicationContext.GetContextParameter<string>(RequestPropertyNames.Organization);
            var project = _restCommunicationContext.GetContextParameter<string>(RequestPropertyNames.Project);

            return $"{organization}/{project}/_apis/git/repositories";
        }

        protected override Method GetRequestMethod()
        {
            return Method.Get;
        }
    }
}
