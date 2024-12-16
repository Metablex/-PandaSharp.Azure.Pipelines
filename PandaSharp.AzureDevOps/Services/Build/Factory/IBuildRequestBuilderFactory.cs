using PandaSharp.AzureDevOps.Services.Build.Contract;

namespace PandaSharp.AzureDevOps.Services.Build.Factory
{
    public interface IBuildRequestBuilderFactory
    {
        IGetAllBuildsRequest GetAllBuilds();

        IGetBuildRequest GetBuild(int buildId);

        IDeleteBuildCommand DeleteBuild(int buildId);

        IGetAllArtifactsOfBuildRequest GetAllArtifactsOfBuild(int buildId);

        IGetArtifactOfBuildRequest GetArtifactOfBuild(int buildId, string artifactName);

        IGetArtifactResourceManifest GetArtifactResourceManifest(int buildId, string artifactName, string resourceId);
    }
}
