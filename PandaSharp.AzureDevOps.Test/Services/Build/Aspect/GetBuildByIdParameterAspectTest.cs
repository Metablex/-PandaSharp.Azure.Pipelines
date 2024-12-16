using NUnit.Framework;
using PandaSharp.AzureDevOps.Services.Build.Aspect;
using RestSharp;
using Shouldly;

namespace PandaSharp.AzureDevOps.Test.Services.Build.Aspect
{
    [TestFixture]
    public sealed class GetBuildByIdParameterAspectTest
    {
        [Test]
        public void SetPropertiesFilterTest()
        {
            var request = new RestRequest();

            var aspect = new GetBuildByIdParameterAspect();
            aspect.SetPropertiesFilter("propertiesFilter");
            aspect.ApplyToRestRequest(request);

            request.Parameters.Count.ShouldBe(1);
            request.Parameters.Exists(new QueryParameter("propertyFilters", "propertiesFilter")).ShouldBeTrue();
        }

        [Test]
        public void DefaultParameterAspectTest()
        {
            var request = new RestRequest();

            var aspect = new GetBuildByIdParameterAspect();
            aspect.ApplyToRestRequest(request);

            request.Parameters.ShouldBeEmpty();
        }
    }
}
