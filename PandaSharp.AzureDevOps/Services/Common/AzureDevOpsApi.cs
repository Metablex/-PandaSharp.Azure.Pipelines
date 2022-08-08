using PandaSharp.AzureDevOps.Services.Build.Factory;
using PandaSharp.AzureDevOps.Services.Git.Factory;

namespace PandaSharp.AzureDevOps.Services.Common
{
    internal sealed class AzureDevOpsApi : IAzureDevOpsApi
    {
        public IBuildRequestBuilderFactory BuildRequest { get; }
        
        public IGitRequestBuilderFactory GitRepositoryRequest { get; }

        public AzureDevOpsApi(IBuildRequestBuilderFactory buildRequestBuilderFactory, IGitRequestBuilderFactory gitRepositoryRequest)
        {
            BuildRequest = buildRequestBuilderFactory;
            GitRepositoryRequest = gitRepositoryRequest;
        }
    }
}