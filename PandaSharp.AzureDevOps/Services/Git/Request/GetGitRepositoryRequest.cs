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
    [SupportsParameterAspect(typeof(IGetGitRepositoryParameterAspect))]
    [RestResponseConverter(typeof(RestResponseConverter))]
    internal sealed class GetGitRepositoryRequest : RequestBase<GitRepositoryResponse>, IGetGitRepositoryRequest
    {
        private readonly IRestCommunicationContext _restCommunicationContext;

        public GetGitRepositoryRequest(IRestCommunicationContext restCommunicationContext, IRestFactory restClientFactory, IRequestParameterAspectFactory parameterAspectFactory, IRestResponseConverterFactory responseConverterFactory)
            : base(restClientFactory, parameterAspectFactory, responseConverterFactory)
        {
            _restCommunicationContext = restCommunicationContext;
        }

        public IGetGitRepositoryRequest IncludeParentRepository()
        {
            GetAspect<IGetGitRepositoryParameterAspect>().SetIncludeParentRepository(true);
            return this;
        }

        protected override string GetResourcePath()
        {
            var organization = _restCommunicationContext.GetContextParameter<string>(RequestPropertyNames.Organization);
            var project = _restCommunicationContext.GetContextParameter<string>(RequestPropertyNames.Project);
            var repositoryId = _restCommunicationContext.GetContextParameter<string>(RequestPropertyNames.RepositoryId);

            return $"{organization}/{project}/_apis/git/repositories/{repositoryId}";
        }

        protected override Method GetRequestMethod()
        {
            return Method.Get;
        }
    }
}
