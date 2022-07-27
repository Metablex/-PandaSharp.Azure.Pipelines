using System;
using Moq;
using PandaSharp.Framework.IoC.Contract;
using PandaSharp.Framework.IoC.Injections;

namespace PandaSharp.AzureDevOps.Test.Framework.Services.Factory
{
    internal static class RequestBuilderFactoryMockBuilder
    {
        internal static Mock<IPandaContainer> CreateRequestRegistrationMock<T>(Action<InjectProperty[]> validateInjectedParts)
            where T : class
        {
            var container = new Mock<IPandaContainer>();
            container
                .Setup(i => i.Resolve<T>(It.IsAny<InjectProperty[]>()))
                .Callback(validateInjectedParts)
                .Returns(new Mock<T>().Object)
                .Verifiable();

            return container;
        }
    }
}