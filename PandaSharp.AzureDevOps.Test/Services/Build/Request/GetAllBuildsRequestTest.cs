using System;
using System.Net;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using PandaSharp.AzureDevOps.Services.Build.Aspect;
using PandaSharp.AzureDevOps.Services.Build.Request;
using PandaSharp.AzureDevOps.Services.Build.Response;
using PandaSharp.AzureDevOps.Services.Build.Types;
using PandaSharp.AzureDevOps.Services.Common.Types;
using PandaSharp.AzureDevOps.Test.Framework.Services.Request;
using RestSharp;
using Shouldly;

namespace PandaSharp.AzureDevOps.Test.Services.Build.Request
{
    [TestFixture]
    internal sealed class GetAllBuildsRequestTest 
    {
        [Test]
        public void UnauthorizedExecuteTest()
        {
            var restFactoryMock = RequestTestMockBuilder.CreateRestFactoryMock<BuildListResponse>(HttpStatusCode.Unauthorized);

            var request = RequestTestMockBuilder.CreateRequest<GetAllBuildsRequest, BuildListResponse>("org", "project", restFactoryMock);

            Should.ThrowAsync<UnauthorizedAccessException>(() => request.ExecuteAsync());
        }

        [Test]
        public void AnyErrorWhileExecuteTest()
        {
            var restFactoryMock = RequestTestMockBuilder.CreateRestFactoryMock<BuildListResponse>(HttpStatusCode.NotFound);

            var request = RequestTestMockBuilder.CreateRequest<GetAllBuildsRequest, BuildListResponse>("org", "project", restFactoryMock);

            Should.ThrowAsync<InvalidOperationException>(() => request.ExecuteAsync());
        }

        [Test]
        public async Task ExecuteAsyncTest()
        {
            var getAllBuildsParameterAspectMock = RequestTestMockBuilder.CreateParameterAspectMock<IGetAllBuildsParameterAspect>();
            var restFactoryMock = RequestTestMockBuilder.CreateRestFactoryMock<BuildListResponse>();
            var currentDateTime = DateTime.Now;
            
            var request = RequestTestMockBuilder
                .CreateRequest<GetAllBuildsRequest, BuildListResponse>("org", "project", restFactoryMock, getAllBuildsParameterAspectMock)
                .WithBranchName("branch")
                .WithBuildIds(1, 2)
                .WithBuildNumber("number")
                .WithDefinitionIds(3, 4)
                .WithMaxBuildsPerDefinition(2)
                .WithMinTime(currentDateTime)
                .WithMaxTime(currentDateTime)
                .WithResultOrder(BuildResultOrder.OrderByQueueTimeAscending)
                .WithDeletedBuilds(IncludeDeletedBuilds.IncludeDeleted)
                .WithBuildReason(BuildReason.BatchedCi)
                .WithBuildStatus(BuildStatus.InProgress)
                .WithBuildResult(BuildResult.Failed)
                .WithProperties("X", "Y")
                .WithQueueIds(5, 6)
                .WithRepositoryId("repoId")
                .WithRepositoryType(RepositoryType.Github)
                .WithTags("tag1", "tag2")
                .WithRequester("Chuck Norris");
            
            var response = await request.ExecuteAsync();
            response.ShouldNotBeNull();
            
            restFactoryMock.Verify(r => r.CreateRequest("org/project/_apis/build/builds", Method.GET), Times.Once);
            
            getAllBuildsParameterAspectMock.Verify(i => i.SetBranchNameFilter("branch"), Times.Once);
            getAllBuildsParameterAspectMock.Verify(i => i.SetBuildIdsFilter(new[] { 1, 2 }), Times.Once);
            getAllBuildsParameterAspectMock.Verify(i => i.SetBuildNumberFilter("number"), Times.Once);
            getAllBuildsParameterAspectMock.Verify(i => i.SetDefinitionIdsFilter(new[] { 3, 4 }), Times.Once);
            getAllBuildsParameterAspectMock.Verify(i => i.SetMaxBuildsPerDefinitionFilter(2), Times.Once);
            getAllBuildsParameterAspectMock.Verify(i => i.SetMinTimeFilter(currentDateTime), Times.Once);
            getAllBuildsParameterAspectMock.Verify(i => i.SetMaxTimeFilter(currentDateTime), Times.Once);
            getAllBuildsParameterAspectMock.Verify(i => i.SetResultOrder(BuildResultOrder.OrderByQueueTimeAscending), Times.Once);
            getAllBuildsParameterAspectMock.Verify(i => i.SetIncludeDeletedBuildsFilter(IncludeDeletedBuilds.IncludeDeleted), Times.Once);
            getAllBuildsParameterAspectMock.Verify(i => i.SetBuildReasonFilter(BuildReason.BatchedCi), Times.Once);
            getAllBuildsParameterAspectMock.Verify(i => i.SetBuildStatusFilter(BuildStatus.InProgress), Times.Once);
            getAllBuildsParameterAspectMock.Verify(i => i.SetBuildResultFilter(BuildResult.Failed), Times.Once);
            getAllBuildsParameterAspectMock.Verify(i => i.SetPropertiesFilter(new[] { "X", "Y" }), Times.Once);
            getAllBuildsParameterAspectMock.Verify(i => i.SetQueueIdsFilter(new[] { 5, 6 }), Times.Once);
            getAllBuildsParameterAspectMock.Verify(i => i.SetRepositoryIdFilter("repoId"), Times.Once);
            getAllBuildsParameterAspectMock.Verify(i => i.SetRepositoryTypeFilter(RepositoryType.Github), Times.Once);
            getAllBuildsParameterAspectMock.Verify(i => i.SetTagsFilter(new[] { "tag1", "tag2" }), Times.Once);
            getAllBuildsParameterAspectMock.Verify(i => i.SetRequesterFilter("Chuck Norris"), Times.Once);
        }
    }
}