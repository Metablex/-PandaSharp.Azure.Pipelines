using System;
using System.Net;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using PandaSharp.AzureDevOps.Services.Build.Aspect;
using PandaSharp.AzureDevOps.Services.Build.Request;
using PandaSharp.AzureDevOps.Services.Build.Response;
using PandaSharp.AzureDevOps.Test.Framework.Services.Request;
using RestSharp;
using Shouldly;

namespace PandaSharp.AzureDevOps.Test.Services.Build.Request
{
    [TestFixture]
    public sealed class GetBuildRequestTest
    {
        [Test]
        public void UnauthorizedExecuteTest()
        {
            var restFactoryMock = RequestTestMockBuilder.CreateRestFactoryMock<BuildResponse>(HttpStatusCode.Unauthorized);

            var request = RequestTestMockBuilder.CreateRequest<GetBuildRequest, BuildResponse>("org", "project", restFactoryMock);

            Should.ThrowAsync<UnauthorizedAccessException>(() => request.ExecuteAsync());
        }

        [Test]
        public void AnyErrorWhileExecuteTest()
        {
            var restFactoryMock = RequestTestMockBuilder.CreateRestFactoryMock<BuildResponse>(HttpStatusCode.NotFound);

            var request = RequestTestMockBuilder.CreateRequest<GetBuildRequest, BuildResponse>("org", "project", restFactoryMock);

            Should.ThrowAsync<InvalidOperationException>(() => request.ExecuteAsync());
        }
        
        [Test]
        public async Task ExecuteAsyncTest()
        {
            var getBuildByIdParameterAspectMock = RequestTestMockBuilder.CreateParameterAspectMock<IGetBuildByIdParameterAspect>();
            var restFactoryMock = RequestTestMockBuilder.CreateRestFactoryMock<BuildResponse>();
            
            var request = RequestTestMockBuilder.CreateRequest<GetBuildRequest, BuildResponse>("org", "project", restFactoryMock, getBuildByIdParameterAspectMock);
            request.BuildId = 42;
            request.WithPropertiesFilter("TestMeHard");
            
            var response = await request.ExecuteAsync();
            response.ShouldNotBeNull();
            
            restFactoryMock.Verify(r => r.CreateRequest("org/project/_apis/build/builds/42", Method.GET), Times.Once);
            
            getBuildByIdParameterAspectMock.Verify(i => i.SetPropertiesFilter("TestMeHard"), Times.Once);
        }
    }
}