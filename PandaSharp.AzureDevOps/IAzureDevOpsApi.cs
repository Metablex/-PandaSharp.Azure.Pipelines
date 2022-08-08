using PandaSharp.AzureDevOps.Services.Build.Factory;
using PandaSharp.AzureDevOps.Services.Git.Factory;

namespace PandaSharp.AzureDevOps
{
    public interface IAzureDevOpsApi
    {
        IBuildRequestBuilderFactory BuildRequest { get; }

        IGitRequestBuilderFactory GitRepositoryRequest { get; }
    }
}