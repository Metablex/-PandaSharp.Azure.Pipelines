using System;
using System.Net;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using PandaSharp.AzureDevOps.Services.Git.Aspect;
using PandaSharp.AzureDevOps.Services.Git.Request;
using PandaSharp.AzureDevOps.Services.Git.Response;
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

            var request = RequestTestMockBuilder.CreateRequest<GetGitRepositoryRequest, GitRepositoryResponse>("org", "project", restFactoryMock);

            Should.ThrowAsync<UnauthorizedAccessException>(() => request.ExecuteAsync());
        }

        [Test]
        public void AnyErrorWhileExecuteTest()
        {
            var restFactoryMock = RequestTestMockBuilder.CreateRestFactoryMock<GitRepositoryResponse>(HttpStatusCode.NotFound);

            var request = RequestTestMockBuilder.CreateRequest<GetGitRepositoryRequest, GitRepositoryResponse>("org", "project", restFactoryMock);

            Should.ThrowAsync<InvalidOperationException>(() => request.ExecuteAsync());
        }

        [Test]
        public async Task ExecuteAsyncTest()
        {
            var getGitRepositoryParameterAspectMock = RequestTestMockBuilder.CreateParameterAspectMock<IGetGitRepositoryParameterAspect>();
            var restFactoryMock = RequestTestMockBuilder.CreateRestFactoryMock<GitRepositoryResponse>();

            var request = RequestTestMockBuilder.CreateRequest<GetGitRepositoryRequest, GitRepositoryResponse>("org", "project", restFactoryMock, getGitRepositoryParameterAspectMock);
            request.RepositoryId = "test";
            request.IncludeParentRepository();

            var response = await request.ExecuteAsync();
            response.ShouldNotBeNull();

            restFactoryMock.Verify(r => r.CreateRequest("org/project/_apis/git/repositories/test", Method.GET), Times.Once);

            getGitRepositoryParameterAspectMock.Verify(i => i.SetIncludeParentRepository(true), Times.Once);
        }
    }
}