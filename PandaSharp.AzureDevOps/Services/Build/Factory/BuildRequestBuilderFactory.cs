using PandaSharp.AzureDevOps.Context;
using PandaSharp.AzureDevOps.Services.Build.Contract;
using PandaSharp.AzureDevOps.Services.Build.Request;
using PandaSharp.AzureDevOps.Services.Build.Types;
using PandaSharp.Framework.IoC.Contract;
using PandaSharp.Framework.Rest.Common;
using PandaSharp.Framework.Rest.Contract;
using PandaSharp.Framework.Services.Aspect;
using PandaSharp.Framework.Services.Request;
using RestSharp.Serializers;

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
            var context = CreateContext();
            var restFactory = CreateRestFactory(JsonRestSerializer.Default);

            return new GetAllBuildsRequest(
                context,
                restFactory,
                _container.Resolve<IRequestParameterAspectFactory>(),
                _container.Resolve<IRestResponseConverterFactory>());
        }

        public IGetBuildRequest GetBuild(int buildId)
        {
            var context = CreateContext();
            context.AddContextParameter(RequestPropertyNames.BuildId, buildId);

            var restFactory = CreateRestFactory(JsonRestSerializer.Default);

            return new GetBuildRequest(
                context,
                restFactory,
                _container.Resolve<IRequestParameterAspectFactory>(),
                _container.Resolve<IRestResponseConverterFactory>());
        }

        public IDeleteBuildCommand DeleteBuild(int buildId)
        {
            var context = CreateContext();
            context.AddContextParameter(RequestPropertyNames.BuildId, buildId);

            var restFactory = CreateRestFactory(JsonRestSerializer.Default);

            return new DeleteBuildCommand(
                context,
                restFactory,
                _container.Resolve<IRequestParameterAspectFactory>());
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
            var context = CreateContext();
            context.AddContextParameter(RequestPropertyNames.BuildId, buildId);
            context.AddContextParameter(RequestPropertyNames.ArtifactName, artifactName);

            var restFactory = CreateRestFactory(JsonRestSerializer.Default);

            return new GetArtifactOfBuildRequest(
                context,
                restFactory,
                _container.Resolve<IRequestParameterAspectFactory>(),
                _container.Resolve<IRestResponseConverterFactory>());
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
