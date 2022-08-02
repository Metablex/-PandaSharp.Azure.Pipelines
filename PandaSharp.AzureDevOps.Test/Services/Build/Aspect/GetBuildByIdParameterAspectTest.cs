using Moq;
using NUnit.Framework;
using PandaSharp.AzureDevOps.Services.Build.Aspect;
using RestSharp;

namespace PandaSharp.AzureDevOps.Test.Services.Build.Aspect
{
    [TestFixture]
    public sealed class GetBuildByIdParameterAspectTest
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
        public void SetPropertiesFilterTest()
        {
            var aspect = new GetBuildByIdParameterAspect();
            aspect.SetPropertiesFilter("propertiesFilter");
            aspect.ApplyToRestRequest(_restRequestMock.Object);
            
            _restRequestMock.Verify(i => i.AddQueryParameter("propertyFilters", "propertiesFilter"), Times.Once);
            _restRequestMock.VerifyNoOtherCalls();
        }

        [Test]
        public void DefaultParameterAspectTest()
        {
            var aspect = new GetBuildByIdParameterAspect();
            aspect.ApplyToRestRequest(_restRequestMock.Object);

            _restRequestMock.VerifyNoOtherCalls();
        }
    }
}