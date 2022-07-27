using NUnit.Framework;
using PandaSharp.AzureDevOps.Services.Build.Contract;
using PandaSharp.AzureDevOps.Services.Build.Factory;
using PandaSharp.AzureDevOps.Test.Framework.Services.Factory;
using Shouldly;

namespace PandaSharp.AzureDevOps.Test.Services.Build.Factory
{
    [TestFixture]
    public sealed class BuildRequestBuilderFactoryTest
    {
        [Test]
        public void GetAllBuildsTest()
        {
            var containerMock = RequestBuilderFactoryMockBuilder.CreateRequestRegistrationMock<IGetAllBuildsRequest>(injectedInformation => injectedInformation.ShouldBeEmpty());
            
            var factory = new BuildRequestBuilderFactory(containerMock.Object);
            var request = factory.GetAllBuilds();
            request.ShouldNotBeNull();

            containerMock.Verify();
            containerMock.VerifyNoOtherCalls();
        }
    }
}