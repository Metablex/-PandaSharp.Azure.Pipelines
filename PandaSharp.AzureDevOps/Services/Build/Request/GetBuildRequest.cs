using PandaSharp.AzureDevOps.Context;
using PandaSharp.AzureDevOps.Services.Build.Aspect;
using PandaSharp.AzureDevOps.Services.Build.Contract;
using PandaSharp.AzureDevOps.Services.Build.Response;
using PandaSharp.AzureDevOps.Services.Build.Types;
using PandaSharp.AzureDevOps.Services.Common.Rest;
using PandaSharp.Framework.Attributes;
using PandaSharp.Framework.Rest.Contract;
using PandaSharp.Framework.Services.Aspect;
using PandaSharp.Framework.Services.Request;
using RestSharp;

namespace PandaSharp.AzureDevOps.Services.Build.Request
{
    [SupportsParameterAspect(typeof(IGetBuildByIdParameterAspect))]
    [RestResponseConverter(typeof(RestResponseConverter))]
    internal sealed class GetBuildRequest : RequestBase<BuildResponse>, IGetBuildRequest
    {
        private readonly IInstanceMetaInformation _instanceMetaInformation;

        [InjectedProperty(RequestPropertyNames.BuildId)]
        public int BuildId { get; set; }

        public GetBuildRequest(IInstanceMetaInformation instanceMetaInformation, IRestFactory restClientFactory, IRequestParameterAspectFactory parameterAspectFactory, IRestResponseConverterFactory responseConverterFactory)
            : base(restClientFactory, parameterAspectFactory, responseConverterFactory)
        {
            _instanceMetaInformation = instanceMetaInformation;
        }

        public IGetBuildRequest WithPropertiesFilter(string propertiesFilter)
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