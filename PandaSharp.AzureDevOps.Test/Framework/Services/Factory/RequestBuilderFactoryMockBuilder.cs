using System;
using Moq;
using PandaSharp.AzureDevOps.Context;
using PandaSharp.Framework.IoC.Contract;
using PandaSharp.Framework.IoC.Injections;
using PandaSharp.Framework.Rest.Contract;
using PandaSharp.Framework.Services.Aspect;

namespace PandaSharp.AzureDevOps.Test.Framework.Services.Factory
{
    internal static class RequestBuilderFactoryMockBuilder
    {
        internal static Mock<IPandaContainer> CreateRequestRegistrationMock<T>(Action<InjectProperty[]> validateInjectedParts)
            where T : class
        {
            var containerMock = new Mock<IPandaContainer>();
            /*containerMock
                .Setup(i => i.Resolve<T>(It.IsAny<InjectProperty[]>()))
                .Callback(validateInjectedParts)
                .Returns(new Mock<T>().Object)
                .Verifiable();*/

            containerMock
                .Setup(i => i.Resolve<IInstanceMetaInformation>())
                .Returns(Mock.Of<IInstanceMetaInformation>());

            containerMock
                .Setup(i => i.Resolve<IRequestParameterAspectFactory>())
                .Returns(Mock.Of<IRequestParameterAspectFactory>());

            containerMock
                .Setup(i => i.Resolve<IRestResponseConverterFactory>())
                .Returns(Mock.Of<IRestResponseConverterFactory>());

            return containerMock;
        }
    }
}
