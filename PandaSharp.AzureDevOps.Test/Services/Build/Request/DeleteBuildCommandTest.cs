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
    public sealed class DeleteBuildCommandTest
    {
        [Test]
        public void UnauthorizedExecuteTest()
        {
            var restFactoryMock = RequestTestMockBuilder.CreateRestFactoryMock(HttpStatusCode.Unauthorized);

            var request = RequestTestMockBuilder.CreateCommand<DeleteBuildCommand>("org", "project", restFactoryMock);

            Should.ThrowAsync<UnauthorizedAccessException>(() => request.ExecuteAsync());
        }

        [Test]
        public void AnyErrorWhileExecuteTest()
        {
            var restFactoryMock = RequestTestMockBuilder.CreateRestFactoryMock(HttpStatusCode.NotFound);

            var request = RequestTestMockBuilder.CreateCommand<DeleteBuildCommand>("org", "project", restFactoryMock);

            Should.ThrowAsync<InvalidOperationException>(() => request.ExecuteAsync());
        }
        
        [Test]
        public async Task ExecuteAsyncTest()
        {
            var restFactoryMock = RequestTestMockBuilder.CreateRestFactoryMock();
            
            var command = RequestTestMockBuilder.CreateCommand<DeleteBuildCommand>("org", "project", restFactoryMock);
            command.BuildId = 42;
            
            await command.ExecuteAsync();
            
            restFactoryMock.Verify(r => r.CreateRequest("org/project/_apis/build/builds/42", Method.DELETE), Times.Once);
        }
    }
}