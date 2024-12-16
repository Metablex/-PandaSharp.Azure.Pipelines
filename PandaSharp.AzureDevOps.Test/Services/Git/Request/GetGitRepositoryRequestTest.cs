using System;
using System.Net;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using PandaSharp.AzureDevOps.Services.Git.Aspect;
using PandaSharp.AzureDevOps.Services.Git.Request;
using PandaSharp.AzureDevOps.Services.Git.Response;
using PandaSharp.AzureDevOps.Services.Git.Types;
using PandaSharp.AzureDevOps.Test.Framework.Services.Request;
using RestSharp;
using Shouldly;

namespace PandaSharp.AzureDevOps.Test.Services.Git.Request
{
    [TestFixture]
    public sealed class GetGitRepositoryRequestTest
    {
        [Test]
        public void UnauthorizedExecuteTest()
        {
            var restFactoryMock = RequestTestMockBuilder.CreateRestFactoryMock<GitRepositoryResponse>(HttpStatusCode.Unauthorized);
            var contextMock = new RestCommunicationContextMockBuilder()
                .WithContextValue(RequestPropertyNames.Organization, "org")
                .WithContextValue(RequestPropertyNames.Project, "project")
                .Build();

            var request = RequestTestMockBuilder.CreateRequest<GetGitRepositoryRequest, GitRepositoryResponse>(contextMock.Object, restFactoryMock.Object);

            Should.ThrowAsync<UnauthorizedAccessException>(() => request.ExecuteAsync());
        }

        [Test]
        public void AnyErrorWhileExecuteTest()
        {
            var restFactoryMock = RequestTestMockBuilder.CreateRestFactoryMock<GitRepositoryResponse>(HttpStatusCode.NotFound);
            var contextMock = new RestCommunicationContextMockBuilder()
                .WithContextValue(RequestPropertyNames.Organization, "org")
                .WithContextValue(RequestPropertyNames.Project, "project")
                .Build();

            var request = RequestTestMockBuilder.CreateRequest<GetGitRepositoryRequest, GitRepositoryResponse>(contextMock.Object, restFactoryMock.Object);

            Should.ThrowAsync<InvalidOperationException>(() => request.ExecuteAsync());
        }

        [Test]
        public async Task ExecuteAsyncTest()
        {
            var getGitRepositoryParameterAspectMock = RequestTestMockBuilder.CreateParameterAspectMock<IGetGitRepositoryParameterAspect>();
            var restFactoryMock = RequestTestMockBuilder.CreateRestFactoryMock<GitRepositoryResponse>();
            var contextMock = new RestCommunicationContextMockBuilder()
                .WithContextValue(RequestPropertyNames.Organization, "org")
                .WithContextValue(RequestPropertyNames.Project, "project")
                .WithContextValue(RequestPropertyNames.RepositoryId, "test")
                .Build();

            var request = RequestTestMockBuilder.CreateRequest<GetGitRepositoryRequest, GitRepositoryResponse>(contextMock.Object, restFactoryMock.Object, getGitRepositoryParameterAspectMock);
            request.IncludeParentRepository();

            var response = await request.ExecuteAsync();
            response.ShouldNotBeNull();

            restFactoryMock.Verify(r => r.CreateRequest("org/project/_apis/git/repositories/test", Method.Get), Times.Once);

            getGitRepositoryParameterAspectMock.Verify(i => i.SetIncludeParentRepository(true), Times.Once);
        }
    }
}
