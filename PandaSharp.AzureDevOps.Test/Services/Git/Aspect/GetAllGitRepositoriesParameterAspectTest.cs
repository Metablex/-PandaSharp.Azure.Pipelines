using NUnit.Framework;
using PandaSharp.AzureDevOps.Services.Git.Aspect;
using RestSharp;
using Shouldly;

namespace PandaSharp.AzureDevOps.Test.Services.Git.Aspect
{
    [TestFixture]
    public sealed class GetAllGitRepositoriesParameterAspectTest
    {
        [Test]
        public void SetIncludeAllRemoteUrlsTest()
        {
            var request = new RestRequest();

            var aspect = new GetAllGitRepositoriesParameterAspect();
            aspect.SetIncludeAllRemoteUrls(true);
            aspect.ApplyToRestRequest(request);

            request.Parameters.Count.ShouldBe(1);
            request.Parameters.Exists(new QueryParameter("includeAllUrls", "True")).ShouldBeTrue();
        }

        [Test]
        public void SetIncludeHiddenTest()
        {
            var request = new RestRequest();

            var aspect = new GetAllGitRepositoriesParameterAspect();
            aspect.SetIncludeHidden(true);
            aspect.ApplyToRestRequest(request);

            request.Parameters.Count.ShouldBe(1);
            request.Parameters.Exists(new QueryParameter("includeHidden", "True")).ShouldBeTrue();
        }

        [Test]
        public void SetIncludeReferenceLinksTest()
        {
            var request = new RestRequest();

            var aspect = new GetAllGitRepositoriesParameterAspect();
            aspect.SetIncludeReferenceLinks(true);
            aspect.ApplyToRestRequest(request);

            request.Parameters.Count.ShouldBe(1);
            request.Parameters.Exists(new QueryParameter("includeLinks", "True")).ShouldBeTrue();
        }
    }
}
