using PandaSharp.AzureDevOps.Context;
using PandaSharp.AzureDevOps.Services.Git.Aspect;
using PandaSharp.AzureDevOps.Services.Git.Contract;
using PandaSharp.AzureDevOps.Services.Git.Response;
using PandaSharp.AzureDevOps.Services.Git.Types;
using PandaSharp.Framework.Attributes;
using PandaSharp.Framework.Rest.Contract;
using PandaSharp.Framework.Services.Aspect;
using PandaSharp.Framework.Services.Request;
using RestSharp;

namespace PandaSharp.AzureDevOps.Services.Git.Request
{
    [SupportsParameterAspect(typeof(IGetGitRepositoryParameterAspect))]
    internal sealed class GetGitRepositoryRequest : RequestBase<GitRepositoryResponse>, IGetGitRepositoryRequest
    {
        private readonly IInstanceMetaInformation _instanceMetaInformation;

        [InjectedProperty(RequestPropertyNames.RepositoryId)]
        public string RepositoryId { get; set; }

        public GetGitRepositoryRequest(IInstanceMetaInformation instanceMetaInformation, IRestFactory restClientFactory, IRequestParameterAspectFactory parameterAspectFactory, IRestResponseConverter responseConverter)
            : base(restClientFactory, parameterAspectFactory, responseConverter)
        {
            _instanceMetaInformation = instanceMetaInformation;
        }

        public IGetGitRepositoryRequest IncludeParentRepository()
        {
            GetAspect<IGetGitRepositoryParameterAspect>().SetIncludeParentRepository(true);
            return this;
        }

        protected override string GetResourcePath()
        {
            return $"{_instanceMetaInformation.Organization}/{_instanceMetaInformation.Project}/_apis/git/repositories/{RepositoryId}";
        }

        protected override Method GetRequestMethod()
        {
            return Method.GET;
        }
    }
}