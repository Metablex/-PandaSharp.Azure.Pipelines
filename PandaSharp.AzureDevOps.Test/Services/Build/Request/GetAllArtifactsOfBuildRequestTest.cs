using System;
using System.Net;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using PandaSharp.AzureDevOps.Services.Build.Request;
using PandaSharp.AzureDevOps.Services.Build.Response;
using PandaSharp.AzureDevOps.Services.Build.Types;
using PandaSharp.AzureDevOps.Test.Framework.Services.Request;
using RestSharp;
using Shouldly;

namespace PandaSharp.AzureDevOps.Test.Services.Build.Request
{
    [TestFixture]
    public sealed class GetAllArtifactsOfBuildRequestTest
    {
        [Test]
        public void UnauthorizedExecuteTest()
        {
            var restFactoryMock = RequestTestMockBuilder.CreateRestFactoryMock<ArtifactListResponse>(HttpStatusCode.Unauthorized);
            var contextMock = new RestCommunicationContextMockBuilder()
                .WithContextValue(RequestPropertyNames.Organization, "org")
                .WithContextValue(RequestPropertyNames.Project, "project")
                .Build();

            var request = RequestTestMockBuilder.CreateRequest<GetAllArtifactsOfBuildRequest, ArtifactListResponse>(
                contextMock.Object,
                restFactoryMock.Object);

            Should.ThrowAsync<UnauthorizedAccessException>(() => request.ExecuteAsync());
        }

        [Test]
        public void AnyErrorWhileExecuteTest()
        {
            var restFactoryMock = RequestTestMockBuilder.CreateRestFactoryMock<ArtifactListResponse>(HttpStatusCode.NotFound);
            var contextMock = new RestCommunicationContextMockBuilder()
                .WithContextValue(RequestPropertyNames.Organization, "org")
                .WithContextValue(RequestPropertyNames.Project, "project")
                .Build();

            var request = RequestTestMockBuilder.CreateRequest<GetAllArtifactsOfBuildRequest, ArtifactListResponse>(
                contextMock.Object,
                restFactoryMock.Object);

            Should.ThrowAsync<InvalidOperationException>(() => request.ExecuteAsync());
        }

        [Test]
        public async Task ExecuteAsyncTest()
        {
            var restFactoryMock = RequestTestMockBuilder.CreateRestFactoryMock<ArtifactListResponse>();
            var contextMock = new RestCommunicationContextMockBuilder()
                .WithContextValue(RequestPropertyNames.Organization, "org")
                .WithContextValue(RequestPropertyNames.Project, "project")
                .WithContextValue(RequestPropertyNames.BuildId, 42)
                .Build();

            var request = RequestTestMockBuilder.CreateRequest<GetAllArtifactsOfBuildRequest, ArtifactListResponse>(
                contextMock.Object,
                restFactoryMock.Object);

            var response = await request.ExecuteAsync();
            response.ShouldNotBeNull();

            restFactoryMock.Verify(r => r.CreateRequest("org/project/_apis/build/builds/42/artifacts", Method.Get), Times.Once);
        }
    }
}
