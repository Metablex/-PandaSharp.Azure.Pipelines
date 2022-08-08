using PandaSharp.AzureDevOps.Services.Git.Aspect;
using PandaSharp.AzureDevOps.Services.Git.Contract;
using PandaSharp.AzureDevOps.Services.Git.Factory;
using PandaSharp.AzureDevOps.Services.Git.Request;
using PandaSharp.Framework.IoC.Contract;

namespace PandaSharp.AzureDevOps.Services.Git
{
    internal sealed class GitModule : IPandaContainerModule
    {
        public void RegisterModule(IPandaContainer container)
        {
            container.RegisterType<IGitRequestBuilderFactory, GitRequestBuilderFactory>();
            container.RegisterType<IGetAllGitRepositoriesRequest, GetAllGitRepositoriesRequest>();
            container.RegisterType<IGetAllGitRepositoriesParameterAspect, GetAllGitRepositoriesParameterAspect>();
        }
    }
}