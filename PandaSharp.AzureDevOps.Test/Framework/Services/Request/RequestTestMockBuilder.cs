using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using PandaSharp.AzureDevOps.Context;
using PandaSharp.Framework.Rest.Contract;
using PandaSharp.Framework.Services.Aspect;
using PandaSharp.Framework.Services.Contract;
using RestSharp;

namespace PandaSharp.AzureDevOps.Test.Framework.Services.Request
{
    internal static class RequestTestMockBuilder
    {
        internal static TRequest CreateRequest<TRequest, TResponse>(
            string organization,
            string project,
            Mock<IRestFactory> restFactoryMock,
            params Mock[] parameterAspects)
            where TRequest : IRequestBase<TResponse>
        {
            var instanceMetaInformationMock = CreateInstanceMetaInformationMock(organization, project);
            var requestParameterAspectFactoryMock = CreateRequestParameterAspectFactoryMock(parameterAspects);
            var restResponseConverter = CreateRestResponseConverterMock<TResponse>();
            
            return (TRequest)Activator.CreateInstance(
                typeof(TRequest),
                instanceMetaInformationMock.Object,
                restFactoryMock.Object,
                requestParameterAspectFactoryMock.Object,
                restResponseConverter.Object);
        }
        
        internal static TRequest CreateCommand<TRequest>(
            string organization,
            string project,
            Mock<IRestFactory> restFactoryMock,
            params Mock[] parameterAspects)
            where TRequest : ICommandBase
        {
            var instanceMetaInformationMock = CreateInstanceMetaInformationMock(organization, project);
            var requestParameterAspectFactoryMock = CreateRequestParameterAspectFactoryMock(parameterAspects);
            
            return (TRequest)Activator.CreateInstance(
                typeof(TRequest),
                instanceMetaInformationMock.Object,
                restFactoryMock.Object,
                requestParameterAspectFactoryMock.Object);
        }
        
        internal static Mock<IRestFactory> CreateRestFactoryMock<TResponse>(HttpStatusCode responseCode = HttpStatusCode.OK, Mock<IRestRequest> restRequestMock = null)
            where TResponse : class, new()
        {
            var response = new Mock<IRestResponse<TResponse>>();
            response
                .SetupGet(i => i.IsSuccessful)
                .Returns(responseCode == HttpStatusCode.OK);

            response
                .SetupGet(i => i.StatusCode)
                .Returns(responseCode);

            response
                .SetupGet(i => i.Data)
                .Returns(new TResponse());

            var client = new Mock<IRestClient>(MockBehavior.Strict);
            client
                .Setup(i => i.ExecuteAsync<TResponse>(It.IsAny<IRestRequest>(), It.IsAny<CancellationToken>()))
                .Returns(Task.Run(() => response.Object));
            
            var mock = restRequestMock ?? new Mock<IRestRequest>();
            
            var restFactoryMock = new Mock<IRestFactory>(MockBehavior.Strict);
            restFactoryMock
                .Setup(i => i.CreateClient())
                .Returns(client.Object);

            restFactoryMock
                .Setup(i => i.CreateRequest(It.IsAny<string>(), It.IsAny<Method>()))
                .Returns(() => mock.Object);

            return restFactoryMock;
        }
        
        internal static Mock<IRestFactory> CreateRestFactoryMock(HttpStatusCode responseCode = HttpStatusCode.OK, Mock<IRestRequest> restRequestMock = null)
        {
            var response = new Mock<IRestResponse>();
            response
                .SetupGet(i => i.IsSuccessful)
                .Returns(responseCode == HttpStatusCode.OK);

            response
                .SetupGet(i => i.StatusCode)
                .Returns(responseCode);

            var client = new Mock<IRestClient>(MockBehavior.Strict);
            client
                .Setup(i => i.ExecuteAsync(It.IsAny<IRestRequest>(), It.IsAny<CancellationToken>()))
                .Returns(Task.Run(() => response.Object));

            var mock = restRequestMock ?? new Mock<IRestRequest>();
            
            var restFactoryMock = new Mock<IRestFactory>(MockBehavior.Strict);
            restFactoryMock
                .Setup(i => i.CreateClient())
                .Returns(client.Object);

            restFactoryMock
                .Setup(i => i.CreateRequest(It.IsAny<string>(), It.IsAny<Method>()))
                .Returns(mock.Object);

            return restFactoryMock;
        }

        internal static Mock<TAspect> CreateParameterAspectMock<TAspect>()
            where TAspect : class
        {
            var mock = new Mock<TAspect>();

            mock.As<IRequestParameterAspect>().Setup(i => i.ApplyToRestRequest(It.IsAny<IRestRequest>()));

            return mock;
        }

        private static Mock<IRequestParameterAspectFactory> CreateRequestParameterAspectFactoryMock(IList<Mock> parameterAspects)
        {
            var parameterAspectFactoryMock = new Mock<IRequestParameterAspectFactory>(MockBehavior.Strict);
            parameterAspectFactoryMock
                .Setup(i => i.GetParameterAspects(It.IsAny<Type>()))
                .Returns(parameterAspects.Select(i => i.As<IRequestParameterAspect>().Object).ToArray());

            return parameterAspectFactoryMock;
        }

        private static Mock<IInstanceMetaInformation> CreateInstanceMetaInformationMock(string organization, string project)
        {
            var instanceMetaInformationMock = new Mock<IInstanceMetaInformation>();
            instanceMetaInformationMock.SetupGet(i => i.Organization).Returns(organization);
            instanceMetaInformationMock.SetupGet(i => i.Project).Returns(project);

            return instanceMetaInformationMock;
        }
        
        private static Mock<IRestResponseConverter> CreateRestResponseConverterMock<TResponse>()
        {
            var restResponseConverterMock = new Mock<IRestResponseConverter>();

            restResponseConverterMock
                .Setup(i => i.ConvertRestResponse(It.IsAny<IRestResponse<TResponse>>()))
                .Returns<IRestResponse<TResponse>>(response => response.Data);

            return restResponseConverterMock;
        }
    }
}