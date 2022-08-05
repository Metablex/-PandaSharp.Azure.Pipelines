using NUnit.Framework;
using PandaSharp.AzureDevOps.Services.Build.Contract;
using PandaSharp.AzureDevOps.Services.Build.Factory;
using PandaSharp.AzureDevOps.Services.Build.Types;
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
        
        [Test]
        public void GetBuildTest()
        {
            var containerMock = RequestBuilderFactoryMockBuilder.CreateRequestRegistrationMock<IGetBuildRequest>(
                parameters =>
                {
                    parameters.Length.ShouldBe(1);
                    parameters.ShouldContain(p => p.PropertyName == RequestPropertyNames.BuildId && p.PropertyValue.Equals(42));
                });
            
            var factory = new BuildRequestBuilderFactory(containerMock.Object);
            var request = factory.GetBuild(42);
            request.ShouldNotBeNull();

            containerMock.Verify();
            containerMock.VerifyNoOtherCalls();
        }
        
        [Test]
        public void DeleteBuildTest()
        {
            var containerMock = RequestBuilderFactoryMockBuilder.CreateRequestRegistrationMock<IDeleteBuildCommand>(
                parameters =>
                {
                    parameters.Length.ShouldBe(1);
                    parameters.ShouldContain(p => p.PropertyName == RequestPropertyNames.BuildId && p.PropertyValue.Equals(666));
                });
            
            var factory = new BuildRequestBuilderFactory(containerMock.Object);
            var request = factory.DeleteBuild(666);
            request.ShouldNotBeNull();

            containerMock.Verify();
            containerMock.VerifyNoOtherCalls();
        }
    }
}