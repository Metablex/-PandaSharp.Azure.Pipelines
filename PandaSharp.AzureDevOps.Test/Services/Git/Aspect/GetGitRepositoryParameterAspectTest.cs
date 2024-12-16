using NUnit.Framework;
using PandaSharp.AzureDevOps.Services.Git.Aspect;
using RestSharp;
using Shouldly;

namespace PandaSharp.AzureDevOps.Test.Services.Git.Aspect
{
    [TestFixture]
    public sealed class GetGitRepositoryParameterAspectTest
    {
        [Test]
        public void SetIncludeParentRepositoryTest()
        {
            var request = new RestRequest();

            var aspect = new GetGitRepositoryParameterAspect();
            aspect.SetIncludeParentRepository(true);
            aspect.ApplyToRestRequest(request);

            request.Parameters.Count.ShouldBe(1);
            request.Parameters.Exists(new QueryParameter("includeParent", "True")).ShouldBeTrue();
        }
    }
}
