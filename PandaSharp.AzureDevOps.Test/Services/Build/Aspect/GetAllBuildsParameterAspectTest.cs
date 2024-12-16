using System;
using NUnit.Framework;
using PandaSharp.AzureDevOps.Services.Build.Aspect;
using PandaSharp.AzureDevOps.Services.Build.Types;
using PandaSharp.AzureDevOps.Services.Common.Types;
using RestSharp;
using Shouldly;

namespace PandaSharp.AzureDevOps.Test.Services.Build.Aspect
{
    [TestFixture]
    public sealed class GetAllBuildsParameterAspectTest
    {
        [Test]
        public void SetBranchNameFilterTest()
        {
            var request = new RestRequest();

            var aspect = new GetAllBuildsParameterAspect();
            aspect.SetBranchNameFilter("branch");
            aspect.ApplyToRestRequest(request);

            request.Parameters.Count.ShouldBe(1);
            request.Parameters.Exists(new QueryParameter("branchName", "branch")).ShouldBeTrue();
        }

        [Test]
        public void SetBuildIdsFilterTest()
        {
            var request = new RestRequest();

            var aspect = new GetAllBuildsParameterAspect();
            aspect.SetBuildIdsFilter(new[] { 1, 2, 3 });
            aspect.ApplyToRestRequest(request);

            request.Parameters.Count.ShouldBe(1);
            request.Parameters.Exists(new QueryParameter("buildIds", "1,2,3")).ShouldBeTrue();
        }

        [Test]
        public void SetBuildNumberFilterTest()
        {
            var request = new RestRequest();

            var aspect = new GetAllBuildsParameterAspect();
            aspect.SetBuildNumberFilter("MamboNumber5");
            aspect.ApplyToRestRequest(request);

            request.Parameters.Count.ShouldBe(1);
            request.Parameters.Exists(new QueryParameter("buildNumber", "MamboNumber5")).ShouldBeTrue();
        }

        [Test]
        public void SetDefinitionIdsFilterTest()
        {
            var request = new RestRequest();

            var aspect = new GetAllBuildsParameterAspect();
            aspect.SetDefinitionIdsFilter(new[] { 1, 2, 3 });
            aspect.ApplyToRestRequest(request);

            request.Parameters.Count.ShouldBe(1);
            request.Parameters.Exists(new QueryParameter("definitions", "1,2,3")).ShouldBeTrue();
        }

        [Test]
        public void SetMaxBuildsPerDefinitionFilterTest()
        {
            var request = new RestRequest();

            var aspect = new GetAllBuildsParameterAspect();
            aspect.SetMaxBuildsPerDefinitionFilter(42);
            aspect.ApplyToRestRequest(request);

            request.Parameters.Count.ShouldBe(1);
            request.Parameters.Exists(new QueryParameter("maxBuildsPerDefinition", "42")).ShouldBeTrue();
        }

        [Test]
        public void SetMinTimeFilterTest()
        {
            var request = new RestRequest();

            var aspect = new GetAllBuildsParameterAspect();
            aspect.SetMinTimeFilter(new DateTime(2000, 1, 1, 12, 0, 0));
            aspect.ApplyToRestRequest(request);

            request.Parameters.Count.ShouldBe(1);
            request.Parameters.Exists(new QueryParameter("minTime", "2000-01-01T12:00:00")).ShouldBeTrue();
        }

        [Test]
        public void SetMaxTimeFilterTest()
        {
            var request = new RestRequest();

            var aspect = new GetAllBuildsParameterAspect();
            aspect.SetMaxTimeFilter(new DateTime(2000, 1, 1, 12, 0, 0));
            aspect.ApplyToRestRequest(request);

            request.Parameters.Count.ShouldBe(1);
            request.Parameters.Exists(new QueryParameter("maxTime", "2000-01-01T12:00:00")).ShouldBeTrue();
        }

        [Test]
        public void SetResultOrderTest()
        {
            var request = new RestRequest();

            var aspect = new GetAllBuildsParameterAspect();
            aspect.SetResultOrder(BuildResultOrder.OrderByFinishTimeDescending);
            aspect.ApplyToRestRequest(request);

            request.Parameters.Count.ShouldBe(1);
            request.Parameters.Exists(new QueryParameter("queryOrder", "finishTimeDescending")).ShouldBeTrue();
        }

        [Test]
        public void SetIncludeDeletedBuildsFilterTest()
        {
            var request = new RestRequest();

            var aspect = new GetAllBuildsParameterAspect();
            aspect.SetIncludeDeletedBuildsFilter(IncludeDeletedBuilds.OnlyDeleted);
            aspect.ApplyToRestRequest(request);

            request.Parameters.Count.ShouldBe(1);
            request.Parameters.Exists(new QueryParameter("deletedFilter", "onlyDeleted")).ShouldBeTrue();
        }

        [Test]
        public void SetBuildReasonFilterTest()
        {
            var request = new RestRequest();

            var aspect = new GetAllBuildsParameterAspect();
            aspect.SetBuildReasonFilter(BuildReason.Triggered);
            aspect.ApplyToRestRequest(request);

            request.Parameters.Count.ShouldBe(1);
            request.Parameters.Exists(new QueryParameter("reasonFilter", "triggered")).ShouldBeTrue();
        }

        [Test]
        public void SetBuildStatusFilterTest()
        {
            var request = new RestRequest();

            var aspect = new GetAllBuildsParameterAspect();
            aspect.SetBuildStatusFilter(BuildStatus.Postponed);
            aspect.ApplyToRestRequest(request);

            request.Parameters.Count.ShouldBe(1);
            request.Parameters.Exists(new QueryParameter("statusFilter", "postponed")).ShouldBeTrue();
        }

        [Test]
        public void SetBuildResultFilterTest()
        {
            var request = new RestRequest();

            var aspect = new GetAllBuildsParameterAspect();
            aspect.SetBuildResultFilter(BuildResult.Succeeded);
            aspect.ApplyToRestRequest(request);

            request.Parameters.Count.ShouldBe(1);
            request.Parameters.Exists(new QueryParameter("resultFilter", "succeeded")).ShouldBeTrue();
        }

        [Test]
        public void SetPropertiesFilterTest()
        {
            var request = new RestRequest();

            var aspect = new GetAllBuildsParameterAspect();
            aspect.SetPropertiesFilter(new[] { "Heinz", "Wurst" });
            aspect.ApplyToRestRequest(request);

            request.Parameters.Count.ShouldBe(1);
            request.Parameters.Exists(new QueryParameter("properties", "Heinz,Wurst")).ShouldBeTrue();
        }

        [Test]
        public void SetQueueIdsFilterTest()
        {
            var request = new RestRequest();

            var aspect = new GetAllBuildsParameterAspect();
            aspect.SetQueueIdsFilter(new[] { 1, 2, 3 });
            aspect.ApplyToRestRequest(request);

            request.Parameters.Count.ShouldBe(1);
            request.Parameters.Exists(new QueryParameter("queues", "1,2,3")).ShouldBeTrue();
        }

        [Test]
        public void SetRepositoryIdFilterTest()
        {
            var request = new RestRequest();

            var aspect = new GetAllBuildsParameterAspect();
            aspect.SetRepositoryIdFilter("repoId");
            aspect.ApplyToRestRequest(request);

            request.Parameters.Count.ShouldBe(1);
            request.Parameters.Exists(new QueryParameter("repositoryId", "repoId")).ShouldBeTrue();
        }

        [Test]
        public void SetRepositoryTypeFilterTest()
        {
            var request = new RestRequest();

            var aspect = new GetAllBuildsParameterAspect();
            aspect.SetRepositoryTypeFilter(RepositoryType.Github);
            aspect.ApplyToRestRequest(request);

            request.Parameters.Count.ShouldBe(1);
            request.Parameters.Exists(new QueryParameter("repositoryType", "Github")).ShouldBeTrue();
        }

        [Test]
        public void SetTagsFilterTest()
        {
            var request = new RestRequest();

            var aspect = new GetAllBuildsParameterAspect();
            aspect.SetTagsFilter(new[] { "tag1", "tag2" });
            aspect.ApplyToRestRequest(request);

            request.Parameters.Count.ShouldBe(1);
            request.Parameters.Exists(new QueryParameter("tagFilters", "tag1,tag2")).ShouldBeTrue();
        }

        [Test]
        public void SetRequesterFilterTest()
        {
            var request = new RestRequest();

            var aspect = new GetAllBuildsParameterAspect();
            aspect.SetRequesterFilter("Chuck Norris");
            aspect.ApplyToRestRequest(request);

            request.Parameters.Count.ShouldBe(1);
            request.Parameters.Exists(new QueryParameter("requestedFor", "Chuck Norris")).ShouldBeTrue();
        }

        [Test]
        public void DefaultParameterAspectTest()
        {
            var request = new RestRequest();

            var aspect = new GetAllBuildsParameterAspect();
            aspect.ApplyToRestRequest(request);

            request.Parameters.ShouldBeEmpty();
        }
    }
}
