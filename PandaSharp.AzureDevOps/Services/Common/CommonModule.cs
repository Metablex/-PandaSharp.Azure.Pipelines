using PandaSharp.Framework.IoC.Contract;

namespace PandaSharp.AzureDevOps.Services.Common
{
    internal sealed class CommonModule : IPandaContainerModule
    {
        public void RegisterModule(IPandaContainer container)
        {
            container.RegisterType<IAzureDevOpsApi, AzureDevOpsApi>();
        }
    }
}