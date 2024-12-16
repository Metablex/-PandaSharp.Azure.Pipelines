using Moq;
using PandaSharp.Framework.Services.Contract;

namespace PandaSharp.AzureDevOps.Test.Framework.Services.Request
{
    public sealed class RestCommunicationContextMockBuilder
    {
        private readonly Mock<IRestCommunicationContext> _mock;

        public RestCommunicationContextMockBuilder()
        {
            _mock = new Mock<IRestCommunicationContext>();
        }

        public RestCommunicationContextMockBuilder WithContextValue<T>(string key, T value)
        {
            _mock
                .Setup(i => i.GetContextParameter<T>(key))
                .Returns(value);

            return this;
        }

        public Mock<IRestCommunicationContext> Build()
        {
            return _mock;
        }
    }
}
