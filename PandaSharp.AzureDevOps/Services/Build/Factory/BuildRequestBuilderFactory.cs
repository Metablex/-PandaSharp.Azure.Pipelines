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

        public IGetBuildByIdRequest GetBuildById(int buildId)
        {
            return _container.Resolve<IGetBuildByIdRequest>(
                new InjectProperty(RequestPropertyNames.BuildId, buildId));
        }

        public IDeleteBuildByIdCommand DeleteBuildById(int buildId)
        {
            return _container.Resolve<IDeleteBuildByIdCommand>(
                new InjectProperty(RequestPropertyNames.BuildId, buildId));
        }
    }
}