using PandaSharp.Framework.Services.Aspect;
using PandaSharp.Framework.Utils;
using RestSharp;

namespace PandaSharp.AzureDevOps.Services.Git.Aspect
{
    internal sealed class GetGitRepositoryParameterAspect : RequestParameterAspectBase, IGetGitRepositoryParameterAspect
    {
        private bool? _includeParentRepository;

        public void SetIncludeParentRepository(bool includeParentRepository)
        {
            _includeParentRepository = includeParentRepository;
        }

        public override void ApplyToRestRequest(RestRequest restRequest)
        {
            restRequest.AddParameterIfSet("includeParent", _includeParentRepository);
        }
    }
}
