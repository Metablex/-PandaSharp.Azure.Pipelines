using PandaSharp.AzureDevOps.Services.Build.Factory;

namespace PandaSharp.AzureDevOps.Services.Common
{
    internal sealed class AzureDevOpsApi : IAzureDevOpsApi
    {
        public IBuildRequestBuilderFactory BuildRequest { get; }

        public AzureDevOpsApi(IBuildRequestBuilderFactory buildRequestBuilderFactory)
        {
            BuildRequest = buildRequestBuilderFactory;
        }
    }
}