using Moq;
using NUnit.Framework;
using PandaSharp.AzureDevOps.Services.Git.Aspect;
using RestSharp;

namespace PandaSharp.AzureDevOps.Test.Services.Git.Aspect
{
    [TestFixture]
    public sealed class GetGitRepositoryParameterAspectTest
    {
        private Mock<IRestRequest> _restRequestMock;

        [SetUp]
        public void SetUp()
        {
            _restRequestMock = new Mock<IRestRequest>();
            _restRequestMock
                .Setup(i => i.AddQueryParameter(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(_restRequestMock.Object);
        }

        [Test]
        public void SetIncludeParentRepositoryTest()
        {
            var aspect = new GetGitRepositoryParameterAspect();
            aspect.SetIncludeParentRepository(true);
            aspect.ApplyToRestRequest(_restRequestMock.Object);

            _restRequestMock.Verify(i => i.AddQueryParameter("includeParent", "True"), Times.Once);
            _restRequestMock.VerifyNoOtherCalls();
        }
    }
}