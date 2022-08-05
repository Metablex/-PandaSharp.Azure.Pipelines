using PandaSharp.AzureDevOps.Context;
using PandaSharp.AzureDevOps.Services.Build.Aspect;
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
    [SupportsParameterAspect(typeof(IGetBuildByIdParameterAspect))]
    internal sealed class GetBuildByIdRequest : RequestBase<BuildResponse>, IGetBuildByIdRequest
    {
        private readonly IInstanceMetaInformation _instanceMetaInformation;

        [InjectedProperty(RequestPropertyNames.BuildId)]
        public int BuildId { get; set; } 

        public GetBuildByIdRequest(IInstanceMetaInformation instanceMetaInformation, IRestFactory restClientFactory, IRequestParameterAspectFactory parameterAspectFactory, IRestResponseConverter responseConverter) 
            : base(restClientFactory, parameterAspectFactory, responseConverter)
        {
            _instanceMetaInformation = instanceMetaInformation;
        }

        public IGetBuildByIdRequest WithPropertiesFilter(string propertiesFilter)
        {
            GetAspect<IGetBuildByIdParameterAspect>().SetPropertiesFilter(propertiesFilter);
            return this;
        }

        protected override string GetResourcePath()
        {
            return $"{_instanceMetaInformation.Organization}/{_instanceMetaInformation.Project}/_apis/build/builds/{BuildId}";
        }

        protected override Method GetRequestMethod()
        {
            return Method.GET;
        }
    }
}