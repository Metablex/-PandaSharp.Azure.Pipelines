using PandaSharp.Framework.Services.Aspect;
using PandaSharp.Framework.Utils;
using RestSharp;

namespace PandaSharp.AzureDevOps.Services.Git.Aspect
{
    internal sealed class GetAllGitRepositoriesParameterAspect : RequestParameterAspectBase, IGetAllGitRepositoriesParameterAspect
    {
        private bool? _includeAllRemoteUrls;
        private bool? _includeHidden;
        private bool? _includeReferenceLinks;

        public void SetIncludeAllRemoteUrls(bool includeAllRemoteUrls)
        {
            _includeAllRemoteUrls = includeAllRemoteUrls;
        }

        public void SetIncludeHidden(bool includeHidden)
        {
            _includeHidden = includeHidden;
        }

        public void SetIncludeReferenceLinks(bool includeReferenceLinks)
        {
            _includeReferenceLinks = includeReferenceLinks;
        }

        public override void ApplyToRestRequest(IRestRequest restRequest)
        {
            restRequest
                .AddParameterIfSet("includeAllUrls", _includeAllRemoteUrls)
                .AddParameterIfSet("includeHidden", _includeHidden)
                .AddParameterIfSet("includeLinks", _includeReferenceLinks);
        }
    }
}