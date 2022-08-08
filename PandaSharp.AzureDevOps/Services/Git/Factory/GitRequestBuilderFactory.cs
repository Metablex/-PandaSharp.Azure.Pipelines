using PandaSharp.AzureDevOps.Services.Git.Contract;
using PandaSharp.Framework.IoC.Contract;

namespace PandaSharp.AzureDevOps.Services.Git.Factory
{
    internal sealed class GitRequestBuilderFactory : IGitRequestBuilderFactory
    {
        private readonly IPandaContainer _container;

        public GitRequestBuilderFactory(IPandaContainer container)
        {
            _container = container;
        }

        public IGetAllGitRepositoriesRequest GetAllGitRepositories()
        {
            return _container.Resolve<IGetAllGitRepositoriesRequest>();
        }
    }
}