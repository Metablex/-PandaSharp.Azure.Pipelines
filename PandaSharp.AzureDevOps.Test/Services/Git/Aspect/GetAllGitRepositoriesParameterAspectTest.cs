using Moq;
using NUnit.Framework;
using PandaSharp.AzureDevOps.Services.Git.Aspect;
using RestSharp;

namespace PandaSharp.AzureDevOps.Test.Services.Git.Aspect
{
    [TestFixture]
    public sealed class GetAllGitRepositoriesParameterAspectTest
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
        public void SetIncludeAllRemoteUrlsTest()
        {
            var aspect = new GetAllGitRepositoriesParameterAspect();
            aspect.SetIncludeAllRemoteUrls(true);
            aspect.ApplyToRestRequest(_restRequestMock.Object);

            _restRequestMock.Verify(i => i.AddQueryParameter("includeAllUrls", "True"), Times.Once);
            _restRequestMock.VerifyNoOtherCalls();
        }

        [Test]
        public void SetIncludeHiddenTest()
        {
            var aspect = new GetAllGitRepositoriesParameterAspect();
            aspect.SetIncludeHidden(true);
            aspect.ApplyToRestRequest(_restRequestMock.Object);

            _restRequestMock.Verify(i => i.AddQueryParameter("includeHidden", "True"), Times.Once);
            _restRequestMock.VerifyNoOtherCalls();
        }

        [Test]
        public void SetIncludeReferenceLinksTest()
        {
            var aspect = new GetAllGitRepositoriesParameterAspect();
            aspect.SetIncludeReferenceLinks(true);
            aspect.ApplyToRestRequest(_restRequestMock.Object);

            _restRequestMock.Verify(i => i.AddQueryParameter("includeLinks", "True"), Times.Once);
            _restRequestMock.VerifyNoOtherCalls();
        }
    }
}