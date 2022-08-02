using PandaSharp.AzureDevOps.Services.Build.Contract;

namespace PandaSharp.AzureDevOps.Services.Build.Factory
{
    public interface IBuildRequestBuilderFactory
    {
        IGetAllBuildsRequest GetAllBuilds();

        IGetBuildByIdRequest GetBuildById(int buildId);
    }
}