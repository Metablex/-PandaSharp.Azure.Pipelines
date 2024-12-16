using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using Moq;
using PandaSharp.Framework.Rest.Contract;
using PandaSharp.Framework.Services.Aspect;
using PandaSharp.Framework.Services.Contract;
using RestSharp;
using RestSharp.Serializers;

namespace PandaSharp.AzureDevOps.Test.Framework.Services.Request
{
    internal static class RequestTestMockBuilder
    {
        internal static TRequest CreateRequest<TRequest, TResponse>(
            IRestCommunicationContext restCommunicationContext,
            IRestFactory restFactory,
            params Mock[] parameterAspects)
            where TRequest : IRequestBase<TResponse>
        {
            var requestParameterAspectFactoryMock = CreateRequestParameterAspectFactoryMock(parameterAspects);
            var restResponseConverterFactory = CreateRestResponseConverterFactoryMock<TResponse>();

            return (TRequest)Activator.CreateInstance(
                typeof(TRequest),
                restCommunicationContext,
                restFactory,
                requestParameterAspectFactoryMock.Object,
                restResponseConverterFactory.Object);
        }

        internal static TRequest CreateCommand<TRequest>(
            IRestCommunicationContext restCommunicationContext,
            IRestFactory restFactory,
            params Mock[] parameterAspects)
            where TRequest : ICommandBase
        {
            var requestParameterAspectFactoryMock = CreateRequestParameterAspectFactoryMock(parameterAspects);

            return (TRequest)Activator.CreateInstance(
                typeof(TRequest),
                restCommunicationContext,
                restFactory,
                requestParameterAspectFactoryMock.Object);
        }

        internal static Mock<IRestFactory> CreateRestFactoryMock<TResponse>(HttpStatusCode responseCode = HttpStatusCode.OK, RestRequest restRequest = null)
            where TResponse : class, new()
        {
            var deserializerMock = new Mock<IDeserializer>();
            deserializerMock
                .Setup(i => i.Deserialize<TResponse>(It.IsAny<RestResponse>()))
                .Returns(() => new TResponse());

            var serializerMock = new Mock<IRestSerializer>();
            serializerMock
                .SetupGet(i => i.AcceptedContentTypes)
                .Returns(["*"]);

            serializerMock
                .SetupGet(i => i.Deserializer)
                .Returns(deserializerMock.Object);

            var serializerConfig = new SerializerConfig();
            serializerConfig.UseSerializer(() => serializerMock.Object);

            var client = new Mock<IRestClient>(MockBehavior.Strict);
            client
                .Setup(i => i.ExecuteAsync(It.IsAny<RestRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(
                    (RestRequest request, CancellationToken _) =>
                    {
                        var response = new RestResponse(request)
                        {
                            IsSuccessStatusCode = responseCode == HttpStatusCode.OK,
                            ResponseStatus = ResponseStatus.Completed,
                            StatusCode = responseCode,
                            Content = "Test"
                        };

                        return response;
                    });

            client
                .SetupGet(i => i.Serializers)
                .Returns(new RestSerializers(serializerConfig));

            client
                .Setup(i => i.Options)
                .Returns(new ReadOnlyRestClientOptions(new RestClientOptions()));

            var mock = restRequest ?? new RestRequest();

            var restFactoryMock = new Mock<IRestFactory>(MockBehavior.Strict);
            restFactoryMock
                .Setup(i => i.CreateClient())
                .Returns(client.Object);

            restFactoryMock
                .Setup(i => i.CreateRequest(It.IsAny<string>(), It.IsAny<Method>()))
                .Returns(() => mock);

            return restFactoryMock;
        }

        internal static Mock<IRestFactory> CreateRestFactoryMock(HttpStatusCode responseCode = HttpStatusCode.OK, RestRequest restRequest = null)
        {
            var client = new Mock<IRestClient>(MockBehavior.Strict);
            client
                .Setup(i => i.ExecuteAsync(It.IsAny<RestRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(
                    (RestRequest request, CancellationToken _) =>
                    {
                        var response = new RestResponse(request)
                        {
                            IsSuccessStatusCode = responseCode == HttpStatusCode.OK,
                            ResponseStatus = ResponseStatus.Completed,
                            StatusCode = responseCode
                        };

                        return response;
                    });

            var mock = restRequest ?? new RestRequest();

            var restFactoryMock = new Mock<IRestFactory>(MockBehavior.Strict);
            restFactoryMock
                .Setup(i => i.CreateClient())
                .Returns(client.Object);

            restFactoryMock
                .Setup(i => i.CreateRequest(It.IsAny<string>(), It.IsAny<Method>()))
                .Returns(mock);

            return restFactoryMock;
        }

        internal static Mock<TAspect> CreateParameterAspectMock<TAspect>()
            where TAspect : class
        {
            var mock = new Mock<TAspect>();

            mock.As<IRequestParameterAspect>().Setup(i => i.ApplyToRestRequest(It.IsAny<RestRequest>()));

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

        private static Mock<IRestResponseConverterFactory> CreateRestResponseConverterFactoryMock<TResponse>()
        {
            var restResponseConverterFactoryMock = new Mock<IRestResponseConverterFactory>();
            var restResponseConverterMock = new Mock<IRestResponseConverter>();

            restResponseConverterFactoryMock
                .Setup(i => i.CreateResponseConverter(It.IsAny<Type>()))
                .Returns(restResponseConverterMock.Object);

            restResponseConverterMock
                .Setup(i => i.ConvertRestResponse(It.IsAny<RestResponse<TResponse>>()))
                .Returns<RestResponse<TResponse>>(response => response.Data);

            return restResponseConverterFactoryMock;
        }
    }
}
