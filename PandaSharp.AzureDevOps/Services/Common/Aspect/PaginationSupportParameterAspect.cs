using PandaSharp.Framework.Services.Aspect;
using PandaSharp.Framework.Utils;
using RestSharp;

namespace PandaSharp.AzureDevOps.Services.Common.Aspect
{
    internal sealed class PaginationSupportParameterAspect : RequestParameterAspectBase, IPaginationSupportParameterAspect
    {
        private int? _maxResults;
        private string _continuationToken;

        public void SetMaxResults(int maxResults)
        {
            _maxResults = maxResults;
        }

        public void SetContinuationToken(string continuationToken)
        {
            _continuationToken = continuationToken;
        }

        public override void ApplyToRestRequest(IRestRequest restRequest)
        {
            restRequest
                .AddParameterIfSet("$top", _maxResults)
                .AddParameterIfSet("continuationToken", _continuationToken);
        }
    }
}