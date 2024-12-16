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
    public sealed class GetAllGitRepositoriesRequestTest
    {
        [Test]
        public void UnauthorizedExecuteTest()
        {
            var restFactoryMock = RequestTestMockBuilder.CreateRestFactoryMock<GitRepositoryListResponse>(HttpStatusCode.Unauthorized);
            var contextMock = new RestCommunicationContextMockBuilder()
                .WithContextValue(RequestPropertyNames.Organization, "org")
                .WithContextValue(RequestPropertyNames.Project, "project")
                .Build();

            var request = RequestTestMockBuilder.CreateRequest<GetAllGitRepositoriesRequest, GitRepositoryListResponse>(contextMock.Object, restFactoryMock.Object);

            Should.ThrowAsync<UnauthorizedAccessException>(() => request.ExecuteAsync());
        }

        [Test]
        public void AnyErrorWhileExecuteTest()
        {
            var restFactoryMock = RequestTestMockBuilder.CreateRestFactoryMock<GitRepositoryListResponse>(HttpStatusCode.NotFound);
            var contextMock = new RestCommunicationContextMockBuilder()
                .WithContextValue(RequestPropertyNames.Organization, "org")
                .WithContextValue(RequestPropertyNames.Project, "project")
                .Build();

            var request = RequestTestMockBuilder.CreateRequest<GetAllGitRepositoriesRequest, GitRepositoryListResponse>(contextMock.Object, restFactoryMock.Object);

            Should.ThrowAsync<InvalidOperationException>(() => request.ExecuteAsync());
        }

        [Test]
        public async Task ExecuteAsyncTest()
        {
            var getAllGitRepositoriesParameterAspectMock = RequestTestMockBuilder.CreateParameterAspectMock<IGetAllGitRepositoriesParameterAspect>();
            var restFactoryMock = RequestTestMockBuilder.CreateRestFactoryMock<GitRepositoryListResponse>();
            var contextMock = new RestCommunicationContextMockBuilder()
                .WithContextValue(RequestPropertyNames.Organization, "org")
                .WithContextValue(RequestPropertyNames.Project, "project")
                .Build();

            var request = RequestTestMockBuilder
                .CreateRequest<GetAllGitRepositoriesRequest, GitRepositoryListResponse>(contextMock.Object, restFactoryMock.Object, getAllGitRepositoriesParameterAspectMock)
                .IncludeHidden()
                .IncludeReferenceLinks()
                .IncludeAllRemoteUrls();

            var response = await request.ExecuteAsync();
            response.ShouldNotBeNull();

            restFactoryMock.Verify(r => r.CreateRequest("org/project/_apis/git/repositories", Method.Get), Times.Once);

            getAllGitRepositoriesParameterAspectMock.Verify(i => i.SetIncludeHidden(true), Times.Once);
            getAllGitRepositoriesParameterAspectMock.Verify(i => i.SetIncludeReferenceLinks(true), Times.Once);
            getAllGitRepositoriesParameterAspectMock.Verify(i => i.SetIncludeAllRemoteUrls(true), Times.Once);
        }
    }
}
