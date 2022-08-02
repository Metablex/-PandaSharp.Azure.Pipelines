using System;
using Moq;
using NUnit.Framework;
using PandaSharp.AzureDevOps.Services.Build.Aspect;
using PandaSharp.AzureDevOps.Services.Build.Types;
using PandaSharp.AzureDevOps.Services.Common.Types;
using RestSharp;

namespace PandaSharp.AzureDevOps.Test.Services.Build.Aspect
{
    [TestFixture]
    public sealed class GetAllBuildsParameterAspectTest
    {
        private Mock<IRestRequest> _restRequestMock;

        [SetUp]
        public void SetUp()
        {
            _restRequestMock = new Mock<IRestRequest>();
            _restRequestMock
                .Setup(i => i.AddQueryParameter(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(_restRequestMock.Object);
            
            _restRequestMock
                .Setup(i => i.AddQueryParameter(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>()))
                .Returns(_restRequestMock.Object);
            
            _restRequestMock
                .Setup(i => i.AddParameter(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(_restRequestMock.Object);
        }

        [Test]
        public void SetBranchNameFilterTest()
        {
            var aspect = new GetAllBuildsParameterAspect();
            aspect.SetBranchNameFilter("branch");
            aspect.ApplyToRestRequest(_restRequestMock.Object);
            
            _restRequestMock.Verify(i => i.AddQueryParameter("branchName", "branch"), Times.Once);
            _restRequestMock.VerifyNoOtherCalls();
        }

        [Test]
        public void SetBuildIdsFilterTest()
        {
            var aspect = new GetAllBuildsParameterAspect();
            aspect.SetBuildIdsFilter(new[] { 1, 2, 3 });
            aspect.ApplyToRestRequest(_restRequestMock.Object);
            
            _restRequestMock.Verify(i => i.AddQueryParameter("buildIds", "1,2,3"), Times.Once);
            _restRequestMock.VerifyNoOtherCalls();
        }

        [Test]
        public void SetBuildNumberFilterTest()
        {
            var aspect = new GetAllBuildsParameterAspect();
            aspect.SetBuildNumberFilter("MamboNumber5");
            aspect.ApplyToRestRequest(_restRequestMock.Object);
            
            _restRequestMock.Verify(i => i.AddQueryParameter("buildNumber", "MamboNumber5"), Times.Once);
            _restRequestMock.VerifyNoOtherCalls();
        }

        [Test]
        public void SetDefinitionIdsFilterTest()
        {
            var aspect = new GetAllBuildsParameterAspect();
            aspect.SetDefinitionIdsFilter(new[] { 1, 2, 3 });
            aspect.ApplyToRestRequest(_restRequestMock.Object);
            
            _restRequestMock.Verify(i => i.AddQueryParameter("definitions", "1,2,3"), Times.Once);
            _restRequestMock.VerifyNoOtherCalls();
        }

        [Test]
        public void SetMaxBuildsPerDefinitionFilterTest()
        {
            var aspect = new GetAllBuildsParameterAspect();
            aspect.SetMaxBuildsPerDefinitionFilter(42);
            aspect.ApplyToRestRequest(_restRequestMock.Object);
            
            _restRequestMock.Verify(i => i.AddQueryParameter("maxBuildsPerDefinition", "42"), Times.Once);
            _restRequestMock.VerifyNoOtherCalls();
        }

        [Test]
        public void SetMinTimeFilterTest()
        {
            var aspect = new GetAllBuildsParameterAspect();
            aspect.SetMinTimeFilter(new DateTime(2000, 1, 1, 12, 0, 0));
            aspect.ApplyToRestRequest(_restRequestMock.Object);
            
            _restRequestMock.Verify(i => i.AddQueryParameter("minTime", "2000-01-01T12:00:00"), Times.Once);
            _restRequestMock.VerifyNoOtherCalls();
        }

        [Test]
        public void SetMaxTimeFilterTest()
        {
            var aspect = new GetAllBuildsParameterAspect();
            aspect.SetMaxTimeFilter(new DateTime(2000, 1, 1, 12, 0, 0));
            aspect.ApplyToRestRequest(_restRequestMock.Object);
            
            _restRequestMock.Verify(i => i.AddQueryParameter("maxTime", "2000-01-01T12:00:00"), Times.Once);
            _restRequestMock.VerifyNoOtherCalls();
        }

        [Test]
        public void SetResultOrderTest()
        {
            var aspect = new GetAllBuildsParameterAspect();
            aspect.SetResultOrder(BuildResultOrder.OrderByFinishTimeDescending);
            aspect.ApplyToRestRequest(_restRequestMock.Object);
            
            _restRequestMock.Verify(i => i.AddQueryParameter("queryOrder", "finishTimeDescending"), Times.Once);
            _restRequestMock.VerifyNoOtherCalls();
        }

        [Test]
        public void SetIncludeDeletedBuildsFilterTest()
        {
            var aspect = new GetAllBuildsParameterAspect();
            aspect.SetIncludeDeletedBuildsFilter(IncludeDeletedBuilds.OnlyDeleted);
            aspect.ApplyToRestRequest(_restRequestMock.Object);
            
            _restRequestMock.Verify(i => i.AddQueryParameter("deletedFilter", "onlyDeleted"), Times.Once);
            _restRequestMock.VerifyNoOtherCalls();
        }

        [Test]
        public void SetBuildReasonFilterTest()
        {
            var aspect = new GetAllBuildsParameterAspect();
            aspect.SetBuildReasonFilter(BuildReason.Triggered);
            aspect.ApplyToRestRequest(_restRequestMock.Object);
            
            _restRequestMock.Verify(i => i.AddQueryParameter("reasonFilter", "triggered"), Times.Once);
            _restRequestMock.VerifyNoOtherCalls();
        }

        [Test]
        public void SetBuildStatusFilterTest()
        {
            var aspect = new GetAllBuildsParameterAspect();
            aspect.SetBuildStatusFilter(BuildStatus.Postponed);
            aspect.ApplyToRestRequest(_restRequestMock.Object);
            
            _restRequestMock.Verify(i => i.AddQueryParameter("statusFilter", "postponed"), Times.Once);
            _restRequestMock.VerifyNoOtherCalls();
        }

        [Test]
        public void SetBuildResultFilterTest()
        {
            var aspect = new GetAllBuildsParameterAspect();
            aspect.SetBuildResultFilter(BuildResult.Succeeded);
            aspect.ApplyToRestRequest(_restRequestMock.Object);
            
            _restRequestMock.Verify(i => i.AddQueryParameter("resultFilter", "succeeded"), Times.Once);
            _restRequestMock.VerifyNoOtherCalls();
        }

        [Test]
        public void SetPropertiesFilterTest()
        {
            var aspect = new GetAllBuildsParameterAspect();
            aspect.SetPropertiesFilter(new[] { "Heinz", "Wurst" });
            aspect.ApplyToRestRequest(_restRequestMock.Object);
            
            _restRequestMock.Verify(i => i.AddQueryParameter("properties", "Heinz,Wurst"), Times.Once);
            _restRequestMock.VerifyNoOtherCalls();
        }

        [Test]
        public void SetQueueIdsFilterTest()
        {
            var aspect = new GetAllBuildsParameterAspect();
            aspect.SetQueueIdsFilter(new[] { 1, 2, 3 });
            aspect.ApplyToRestRequest(_restRequestMock.Object);
            
            _restRequestMock.Verify(i => i.AddQueryParameter("queues", "1,2,3"), Times.Once);
            _restRequestMock.VerifyNoOtherCalls();
        }

        [Test]
        public void SetRepositoryIdFilterTest()
        {
            var aspect = new GetAllBuildsParameterAspect();
            aspect.SetRepositoryIdFilter("repoId");
            aspect.ApplyToRestRequest(_restRequestMock.Object);
            
            _restRequestMock.Verify(i => i.AddQueryParameter("repositoryId", "repoId"), Times.Once);
            _restRequestMock.VerifyNoOtherCalls();
        }

        [Test]
        public void SetRepositoryTypeFilterTest()
        {
            var aspect = new GetAllBuildsParameterAspect();
            aspect.SetRepositoryTypeFilter(RepositoryType.Github);
            aspect.ApplyToRestRequest(_restRequestMock.Object);
            
            _restRequestMock.Verify(i => i.AddQueryParameter("repositoryType", "Github"), Times.Once);
            _restRequestMock.VerifyNoOtherCalls();
        }

        [Test]
        public void SetTagsFilterTest()
        {
            var aspect = new GetAllBuildsParameterAspect();
            aspect.SetTagsFilter(new[] { "tag1", "tag2" });
            aspect.ApplyToRestRequest(_restRequestMock.Object);
            
            _restRequestMock.Verify(i => i.AddQueryParameter("tagFilters", "tag1,tag2"), Times.Once);
            _restRequestMock.VerifyNoOtherCalls();
        }

        [Test]
        public void SetRequesterFilterTest()
        {
            var aspect = new GetAllBuildsParameterAspect();
            aspect.SetRequesterFilter("Chuck Norris");
            aspect.ApplyToRestRequest(_restRequestMock.Object);
            
            _restRequestMock.Verify(i => i.AddQueryParameter("requestedFor", "Chuck Norris"), Times.Once);
            _restRequestMock.VerifyNoOtherCalls();
        }
        
        [Test]
        public void DefaultParameterAspectTest()
        {
            var aspect = new GetAllBuildsParameterAspect();
            aspect.ApplyToRestRequest(_restRequestMock.Object);

            _restRequestMock.VerifyNoOtherCalls();
        }
    }
}