using System;
using System.Net;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using PandaSharp.AzureDevOps.Services.Build.Request;
using PandaSharp.AzureDevOps.Services.Build.Response;
using PandaSharp.AzureDevOps.Test.Framework.Services.Request;
using RestSharp;
using Shouldly;

namespace PandaSharp.AzureDevOps.Test.Services.Build.Request
{
    [TestFixture]
    public sealed class GetArtifactOfBuildRequestTest
    {
        [Test]
        public void UnauthorizedExecuteTest()
        {
            var restFactoryMock = RequestTestMockBuilder.CreateRestFactoryMock<ArtifactResponse>(HttpStatusCode.Unauthorized);

            var request = RequestTestMockBuilder.CreateRequest<GetArtifactOfBuildRequest, ArtifactResponse>("org", "project", restFactoryMock);

            Should.ThrowAsync<UnauthorizedAccessException>(() => request.ExecuteAsync());
        }

        [Test]
        public void AnyErrorWhileExecuteTest()
        {
            var restFactoryMock = RequestTestMockBuilder.CreateRestFactoryMock<ArtifactResponse>(HttpStatusCode.NotFound);

            var request = RequestTestMockBuilder.CreateRequest<GetArtifactOfBuildRequest, ArtifactResponse>("org", "project", restFactoryMock);

            Should.ThrowAsync<InvalidOperationException>(() => request.ExecuteAsync());
        }
        
        [Test]
        public async Task ExecuteAsyncTest()
        {
            var restRequestMock = new Mock<IRestRequest>();
            restRequestMock
                .Setup(i => i.AddQueryParameter(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(restRequestMock.Object);
            
            var restFactoryMock = RequestTestMockBuilder.CreateRestFactoryMock<ArtifactResponse>(restRequestMock: restRequestMock);
            
            var request = RequestTestMockBuilder.CreateRequest<GetArtifactOfBuildRequest, ArtifactResponse>("org", "project", restFactoryMock);
            request.BuildId = 42;
            request.ArtifactName = "Test";
            
            var response = await request.ExecuteAsync();
            response.ShouldNotBeNull();
            
            restFactoryMock.Verify(r => r.CreateRequest("org/project/_apis/build/builds/42/artifacts", Method.GET), Times.Once);
            
            restRequestMock.Verify(i => i.AddQueryParameter("artifactName", "Test"), Times.Once);
        }
    }
}