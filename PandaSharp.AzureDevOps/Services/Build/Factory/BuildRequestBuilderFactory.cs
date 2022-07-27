using PandaSharp.AzureDevOps.Services.Build.Contract;
using PandaSharp.Framework.IoC.Contract;

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
    }
}