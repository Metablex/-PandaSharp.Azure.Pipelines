using PandaSharp.AzureDevOps.Context;
using PandaSharp.AzureDevOps.Services.Build.Contract;
using PandaSharp.AzureDevOps.Services.Build.Response;
using PandaSharp.AzureDevOps.Services.Build.Types;
using PandaSharp.Framework.Attributes;
using PandaSharp.Framework.Rest.Contract;
using PandaSharp.Framework.Services.Aspect;
using PandaSharp.Framework.Services.Request;
using RestSharp;

namespace PandaSharp.AzureDevOps.Services.Build.Request
{
    internal sealed class GetArtifactOfBuildRequest : RequestBase<ArtifactResponse>, IGetArtifactOfBuildRequest
    {
        private readonly IInstanceMetaInformation _instanceMetaInformation;
        
        [InjectedProperty(RequestPropertyNames.BuildId)]
        public int BuildId { get; set; }
        
        [InjectedProperty(RequestPropertyNames.ArtifactName)]
        public string ArtifactName { get; set; }

        public GetArtifactOfBuildRequest(IInstanceMetaInformation instanceMetaInformation, IRestFactory restClientFactory, IRequestParameterAspectFactory parameterAspectFactory, IRestResponseConverter responseConverter) 
            : base(restClientFactory, parameterAspectFactory, responseConverter)
        {
            _instanceMetaInformation = instanceMetaInformation;
        }

        protected override void ApplyToRestRequest(IRestRequest restRequest)
        {
            restRequest.AddQueryParameter("artifactName", ArtifactName);
        }

        protected override string GetResourcePath()
        {
            return $"{_instanceMetaInformation.Organization}/{_instanceMetaInformation.Project}/_apis/build/builds/{BuildId}/artifacts";
        }

        protected override Method GetRequestMethod()
        {
            return Method.GET;
        }
    }
}