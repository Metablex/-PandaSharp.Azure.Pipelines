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
        public void GetBuildByIdTest()
        {
            var containerMock = RequestBuilderFactoryMockBuilder.CreateRequestRegistrationMock<IGetBuildByIdRequest>(
                parameters =>
                {
                    parameters.Length.ShouldBe(1);
                    parameters.ShouldContain(p => p.PropertyName == RequestPropertyNames.BuildId && p.PropertyValue.Equals(42));
                });
            
            var factory = new BuildRequestBuilderFactory(containerMock.Object);
            var request = factory.GetBuildById(42);
            request.ShouldNotBeNull();

            containerMock.Verify();
            containerMock.VerifyNoOtherCalls();
        }
        
        [Test]
        public void DeleteBuildByIdTest()
        {
            var containerMock = RequestBuilderFactoryMockBuilder.CreateRequestRegistrationMock<IDeleteBuildByIdCommand>(
                parameters =>
                {
                    parameters.Length.ShouldBe(1);
                    parameters.ShouldContain(p => p.PropertyName == RequestPropertyNames.BuildId && p.PropertyValue.Equals(666));
                });
            
            var factory = new BuildRequestBuilderFactory(containerMock.Object);
            var request = factory.DeleteBuildById(666);
            request.ShouldNotBeNull();

            containerMock.Verify();
            containerMock.VerifyNoOtherCalls();
        }
    }
}