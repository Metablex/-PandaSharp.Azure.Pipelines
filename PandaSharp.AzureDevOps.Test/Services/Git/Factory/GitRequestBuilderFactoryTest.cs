using NUnit.Framework;
using PandaSharp.AzureDevOps.Services.Git.Contract;
using PandaSharp.AzureDevOps.Services.Git.Factory;
using PandaSharp.AzureDevOps.Services.Git.Types;
using PandaSharp.AzureDevOps.Test.Framework.Services.Factory;
using Shouldly;

namespace PandaSharp.AzureDevOps.Test.Services.Git.Factory
{
    [TestFixture]
    public sealed class GitRequestBuilderFactoryTest
    {
        [Test]
        public void GetAllGitRepositoriesTest()
        {
            var containerMock = RequestBuilderFactoryMockBuilder.CreateRequestRegistrationMock<IGetAllGitRepositoriesRequest>(injectedInformation => injectedInformation.ShouldBeEmpty());

            var factory = new GitRequestBuilderFactory(containerMock.Object);
            var request = factory.GetAllGitRepositories();
            request.ShouldNotBeNull();

            containerMock.Verify();
            containerMock.VerifyNoOtherCalls();
        }

        [Test]
        public void GetGitRepositoryTest()
        {
            var containerMock = RequestBuilderFactoryMockBuilder.CreateRequestRegistrationMock<IGetGitRepositoryRequest>(
                injectedInformation =>
                {
                    injectedInformation.Length.ShouldBe(1);
                    injectedInformation.ShouldContain(p => p.PropertyName == RequestPropertyNames.RepositoryId && p.PropertyValue.Equals("test"));
                });

            var factory = new GitRequestBuilderFactory(containerMock.Object);
            var request = factory.GetGitRepository("test");
            request.ShouldNotBeNull();

            containerMock.Verify();
            containerMock.VerifyNoOtherCalls();
        }
    }
}