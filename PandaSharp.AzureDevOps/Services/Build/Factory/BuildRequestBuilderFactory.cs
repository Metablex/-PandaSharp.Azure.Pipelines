using PandaSharp.AzureDevOps.Context;
using PandaSharp.AzureDevOps.Services.Build.Contract;
using PandaSharp.AzureDevOps.Services.Build.Request;
using PandaSharp.AzureDevOps.Services.Build.Types;
using PandaSharp.Framework.IoC.Contract;
using PandaSharp.Framework.IoC.Injections;
using PandaSharp.Framework.Rest.Common;
using PandaSharp.Framework.Rest.Contract;
using PandaSharp.Framework.Services.Aspect;
using PandaSharp.Framework.Services.Request;
using RestSharp.Serialization;

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
            var context = CreateContext();
            context.AddContextParameter(RequestPropertyNames.BuildId, buildId);

            var restFactory = CreateRestFactory(JsonRestSerializer.Default);

            return new GetAllArtifactsOfBuildRequest(
                context,
                restFactory,
                _container.Resolve<IRequestParameterAspectFactory>(),
                _container.Resolve<IRestResponseConverterFactory>());
        }

        public IGetArtifactOfBuildRequest GetArtifactOfBuild(int buildId, string artifactName)
        {
            return _container.Resolve<IGetArtifactOfBuildRequest>(
                new InjectProperty(RequestPropertyNames.BuildId, buildId),
                new InjectProperty(RequestPropertyNames.ArtifactName, artifactName));
        }

        public IGetArtifactResourceManifest GetArtifactResourceManifest(int buildId, string artifactName, string resourceId)
        {
            var context = CreateContext();
            context.AddContextParameter(RequestPropertyNames.BuildId, buildId);
            context.AddContextParameter(RequestPropertyNames.ArtifactName, artifactName);
            context.AddContextParameter(RequestPropertyNames.ResourceId, resourceId);

            var restFactory = CreateRestFactory(new JsonRestSerializer(new [] { "application/octet-stream" }));

            return new GetArtifactResourceManifest(
                context,
                restFactory,
                _container.Resolve<IRequestParameterAspectFactory>(),
                _container.Resolve<IRestResponseConverterFactory>());
        }

        private IRestFactory CreateRestFactory(IRestSerializer serializer)
        {
            return new RestFactory(_container.Resolve<IRestOptions>(), serializer);
        }

        private RestCommunicationContext CreateContext()
        {
            var instanceMetaInformation = _container.Resolve<IInstanceMetaInformation>();

            var context = new RestCommunicationContext();
            context.AddContextParameter(RequestPropertyNames.Organization, instanceMetaInformation.Organization);
            context.AddContextParameter(RequestPropertyNames.Project, instanceMetaInformation.Project);

            return context;
        }
    }
}
