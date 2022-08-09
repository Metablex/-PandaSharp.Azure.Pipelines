using PandaSharp.AzureDevOps.Services.Git.Contract;
using PandaSharp.AzureDevOps.Services.Git.Types;
using PandaSharp.Framework.IoC.Contract;
using PandaSharp.Framework.IoC.Injections;

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

        public IGetGitRepositoryRequest GetGitRepository(string repositoryId)
        {
            return _container.Resolve<IGetGitRepositoryRequest>(
                new InjectProperty(RequestPropertyNames.RepositoryId, repositoryId));
        }
    }
}