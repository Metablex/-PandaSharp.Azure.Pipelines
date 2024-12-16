using PandaSharp.AzureDevOps.Services.Build.Contract;
using PandaSharp.AzureDevOps.Services.Build.Types;
using PandaSharp.Framework.Rest.Contract;
using PandaSharp.Framework.Services.Aspect;
using PandaSharp.Framework.Services.Contract;
using PandaSharp.Framework.Services.Request;
using RestSharp;

namespace PandaSharp.AzureDevOps.Services.Build.Request
{
    internal sealed class DeleteBuildCommand : CommandBase, IDeleteBuildCommand
    {
        private readonly IRestCommunicationContext _restCommunicationContext;

        public DeleteBuildCommand(IRestCommunicationContext restCommunicationContext, IRestFactory restClientFactory, IRequestParameterAspectFactory parameterAspectFactory)
            : base(restClientFactory, parameterAspectFactory)
        {
            _restCommunicationContext = restCommunicationContext;
        }

        protected override string GetResourcePath()
        {
            var organization = _restCommunicationContext.GetContextParameter<string>(RequestPropertyNames.Organization);
            var project = _restCommunicationContext.GetContextParameter<string>(RequestPropertyNames.Project);
            var buildId = _restCommunicationContext.GetContextParameter<int>(RequestPropertyNames.BuildId);

            return $"{organization}/{project}/_apis/build/builds/{buildId}";
        }

        protected override Method GetRequestMethod()
        {
            return Method.Delete;
        }
    }
}
