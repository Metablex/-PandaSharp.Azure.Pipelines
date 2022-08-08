using PandaSharp.AzureDevOps.Services.Git.Contract;

namespace PandaSharp.AzureDevOps.Services.Git.Factory
{
    public interface IGitRequestBuilderFactory
    {
        IGetAllGitRepositoriesRequest GetAllGitRepositories();
    }
}