using PandaSharp.AzureDevOps.Utils;
using PandaSharp.Framework.IoC;
using PandaSharp.Framework.Utils;

namespace PandaSharp.AzureDevOps
{
    public static class AzureDevOpsApiFactory
    {
        public static IAzureDevOpsApi CreateWithPersonalAccessToken(string organization, string project, string accessToken)
        {
            var container = new PandaContainer();
            container.RegisterWithBasicAuthentication("https://dev.azure.com/", string.Empty, accessToken);
            container.RegisterOrganizationAndProject(organization, project);
            container.RegisterPandaModules();

            return container.Resolve<IAzureDevOpsApi>();
        }
    }
}