using Moq;
using NUnit.Framework;
using PandaSharp.AzureDevOps.Context;
using PandaSharp.AzureDevOps.Utils;
using PandaSharp.Framework.IoC.Contract;
using Shouldly;

namespace PandaSharp.AzureDevOps.Test.Utils
{
    [TestFixture]
    public sealed class PandaContainerExtensionsTest
    {
        [Test]
        public void RegisterOrganizationAndProjectTest()
        {
            IInstanceMetaInformation metaInformation = null;
            var containerMock = new Mock<IPandaContainer>();
            containerMock
                .Setup(i => i.RegisterInstance(It.IsAny<IInstanceMetaInformation>()))
                .Callback<IInstanceMetaInformation>(i => metaInformation = i);
            
            containerMock.Object.RegisterOrganizationAndProject("org", "project");

            metaInformation.ShouldNotBeNull();
            metaInformation.Organization.ShouldBe("org");
            metaInformation.Project.ShouldBe("project");
        }
    }
}