using PandaSharp.AzureDevOps.Context;
using PandaSharp.Framework.IoC.Contract;

namespace PandaSharp.AzureDevOps.Utils
{
    internal static class PandaContainerExtensions
    {
        public static void RegisterOrganizationAndProject(this IPandaContainer container, string organization, string project)
        {
            var metaInformation = new InstanceMetaInformation(organization, project);
            container.RegisterInstance<IInstanceMetaInformation>(metaInformation);
        }
    }
}