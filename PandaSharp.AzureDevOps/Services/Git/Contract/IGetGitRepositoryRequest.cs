using PandaSharp.AzureDevOps.Services.Git.Response;
using PandaSharp.Framework.Services.Contract;

namespace PandaSharp.AzureDevOps.Services.Git.Contract
{
    public interface IGetGitRepositoryRequest : IRequestBase<GitRepositoryResponse>
    {
        IGetGitRepositoryRequest IncludeParentRepository();
    }
}