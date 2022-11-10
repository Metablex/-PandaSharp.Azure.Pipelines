using PandaSharp.AzureDevOps.Utils;
using PandaSharp.Framework.IoC;
using PandaSharp.Framework.Utils;
using RestSharp.Authenticators;

namespace PandaSharp.AzureDevOps
{
    public static class AzureDevOpsApiFactory
    {
        public static IAzureDevOpsApi CreateWithPersonalAccessToken(string baseUrl, string organization, string project, string accessToken)
        {
            var container = new PandaContainer();
            container.RegisterWithBasicAuthentication(baseUrl, string.Empty, accessToken);
            container.RegisterOrganizationAndProject(organization, project);
            container.RegisterPandaModules();

            return container.Resolve<IAzureDevOpsApi>();
        }

        public static IAzureDevOpsApi CreateWithCustomAuthenticator(string baseUrl, string organization, string project, IAuthenticator authenticator)
        {
            var container = new PandaContainer();
            container.RegisterWithCustomAuthentication(baseUrl, authenticator);
            container.RegisterOrganizationAndProject(organization, project);
            container.RegisterPandaModules();

            return container.Resolve<IAzureDevOpsApi>();
        }
    }
}