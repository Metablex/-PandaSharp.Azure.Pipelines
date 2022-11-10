using Moq;
using NUnit.Framework;
using RestSharp.Authenticators;
using Shouldly;

namespace PandaSharp.AzureDevOps.Test
{
    [TestFixture]
    public sealed class AzureDevOpsApiFactoryTest
    {
        [Test]
        public void AzureDevOpsApiPersonalAccessTokenConstructionTest()
        {
            var bambooApi = AzureDevOpsApiFactory.CreateWithPersonalAccessToken("url", "org", "TestBob", "tokenXYZ");

            bambooApi.BuildRequest.ShouldNotBeNull();
            bambooApi.GitRepositoryRequest.ShouldNotBeNull();
        }

        [Test]
        public void AzureDevOpsApiCustomAuthenticatorConstructionTest()
        {
            var bambooApi = AzureDevOpsApiFactory.CreateWithCustomAuthenticator("url", "org", "TestBob", new Mock<IAuthenticator>().Object);

            bambooApi.BuildRequest.ShouldNotBeNull();
            bambooApi.GitRepositoryRequest.ShouldNotBeNull();
        }
    }
}