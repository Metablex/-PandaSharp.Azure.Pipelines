using PandaSharp.AzureDevOps.Services.Common.Aspect;
using PandaSharp.AzureDevOps.Services.Common.Rest;
using PandaSharp.Framework.IoC.Contract;
using PandaSharp.Framework.Rest.Contract;

namespace PandaSharp.AzureDevOps.Services.Common
{
    internal sealed class CommonModule : IPandaContainerModule
    {
        public void RegisterModule(IPandaContainer container)
        {
            container.RegisterType<IAzureDevOpsApi, AzureDevOpsApi>();
            container.RegisterType<IPaginationSupportParameterAspect, PaginationSupportParameterAspect>();
        }
    }
}