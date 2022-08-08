using PandaSharp.AzureDevOps.Services.Build.Contract;
using PandaSharp.AzureDevOps.Services.Build.Types;
using PandaSharp.Framework.IoC.Contract;
using PandaSharp.Framework.IoC.Injections;

namespace PandaSharp.AzureDevOps.Services.Build.Factory
{
    internal sealed class BuildRequestBuilderFactory : IBuildRequestBuilderFactory
    {
        private readonly IPandaContainer _container;

        public BuildRequestBuilderFactory(IPandaContainer container)
        {
            _container = container;
        }

        public IGetAllBuildsRequest GetAllBuilds()
        {
            return _container.Resolve<IGetAllBuildsRequest>();
        }

        public IGetBuildRequest GetBuild(int buildId)
        {
            return _container.Resolve<IGetBuildRequest>(
                new InjectProperty(RequestPropertyNames.BuildId, buildId));
        }

        public IDeleteBuildCommand DeleteBuild(int buildId)
        {
            return _container.Resolve<IDeleteBuildCommand>(
                new InjectProperty(RequestPropertyNames.BuildId, buildId));
        }

        public IGetAllArtifactsOfBuildRequest GetAllArtifactsOfBuild(int buildId)
        {
            return _container.Resolve<IGetAllArtifactsOfBuildRequest>(
                new InjectProperty(RequestPropertyNames.BuildId, buildId));
        }

        public IGetArtifactOfBuildRequest GetArtifactOfBuild(int buildId, string artifactName)
        {
            return _container.Resolve<IGetArtifactOfBuildRequest>(
                new InjectProperty(RequestPropertyNames.BuildId, buildId),
                new InjectProperty(RequestPropertyNames.ArtifactName, artifactName));
        }
    }
}