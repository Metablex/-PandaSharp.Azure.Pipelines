using PandaSharp.AzureDevOps.Services.Build.Aspect;
using PandaSharp.AzureDevOps.Services.Build.Contract;
using PandaSharp.AzureDevOps.Services.Build.Factory;
using PandaSharp.AzureDevOps.Services.Build.Request;
using PandaSharp.Framework.IoC.Contract;

namespace PandaSharp.AzureDevOps.Services.Build
{
    internal sealed class BuildModule : IPandaContainerModule
    {
        public void RegisterModule(IPandaContainer container)
        {
            container.RegisterType<IGetAllBuildsRequest, GetAllBuildsRequest>();
            container.RegisterType<IGetBuildByIdRequest, GetBuildByIdRequest>();
            container.RegisterType<IBuildRequestBuilderFactory, BuildRequestBuilderFactory>();
            container.RegisterType<IGetAllBuildsParameterAspect, GetAllBuildsParameterAspect>();
            container.RegisterType<IGetBuildByIdParameterAspect, GetBuildByIdParameterAspect>();
        }
    }
}