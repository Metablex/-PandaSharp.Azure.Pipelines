using PandaSharp.AzureDevOps.Services.Build.Contract;
using PandaSharp.AzureDevOps.Services.Build.Response;
using PandaSharp.AzureDevOps.Services.Build.Types;
using PandaSharp.AzureDevOps.Services.Common.Rest;
using PandaSharp.Framework.Attributes;
using PandaSharp.Framework.Rest.Contract;
using PandaSharp.Framework.Services.Aspect;
using PandaSharp.Framework.Services.Contract;
using PandaSharp.Framework.Services.Request;
using RestSharp;

namespace PandaSharp.AzureDevOps.Services.Build.Request
{
    [RestResponseConverter(typeof(RestResponseConverter))]
    internal sealed class GetArtifactOfBuildRequest : RequestBase<ArtifactResponse>, IGetArtifactOfBuildRequest
    {
        private readonly IRestCommunicationContext _restCommunicationContext;

        public GetArtifactOfBuildRequest(IRestCommunicationContext restCommunicationContext, IRestFactory restClientFactory, IRequestParameterAspectFactory parameterAspectFactory, IRestResponseConverterFactory responseConverterFactory)
            : base(restClientFactory, parameterAspectFactory, responseConverterFactory)
        {
            _restCommunicationContext = restCommunicationContext;
        }

        protected override void ApplyToRestRequest(RestRequest restRequest)
        {
            var artifactName = _restCommunicationContext.GetContextParameter<string>(RequestPropertyNames.ArtifactName);
            restRequest.AddQueryParameter("artifactName", artifactName);
        }

        protected override string GetResourcePath()
        {
            var organization = _restCommunicationContext.GetContextParameter<string>(RequestPropertyNames.Organization);
            var project = _restCommunicationContext.GetContextParameter<string>(RequestPropertyNames.Project);
            var buildId = _restCommunicationContext.GetContextParameter<int>(RequestPropertyNames.BuildId);

            return $"{organization}/{project}/_apis/build/builds/{buildId}/artifacts";
        }

        protected override Method GetRequestMethod()
        {
            return Method.Get;
        }
    }
}
