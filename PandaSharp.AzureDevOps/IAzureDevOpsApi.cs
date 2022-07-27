using PandaSharp.AzureDevOps.Services.Build.Factory;

namespace PandaSharp.AzureDevOps
{
    public interface IAzureDevOpsApi
    {
        IBuildRequestBuilderFactory BuildRequest { get; }
    }
}