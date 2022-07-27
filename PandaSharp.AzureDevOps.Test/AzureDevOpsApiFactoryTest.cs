using NUnit.Framework;
using Shouldly;

namespace PandaSharp.AzureDevOps.Test
{
    [TestFixture]
    public sealed class AzureDevOpsApiFactoryTest
    {
        [Test]
        public void AzureDevOpsApiPersonalAccessTokenConstructionTest()
        {
            var bambooApi = AzureDevOpsApiFactory.CreateWithPersonalAccessToken("org", "TestBob", "tokenXYZ");

            bambooApi.BuildRequest.ShouldNotBeNull();
        }
    }
}