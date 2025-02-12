﻿using PandaSharp.AzureDevOps.Services.Build.Aspect;
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
    [SupportsParameterAspect(typeof(IGetBuildByIdParameterAspect))]
    [RestResponseConverter(typeof(RestResponseConverter))]
    internal sealed class GetBuildRequest : RequestBase<BuildResponse>, IGetBuildRequest
    {
        private readonly IRestCommunicationContext _restCommunicationContext;

        public GetBuildRequest(IRestCommunicationContext restCommunicationContext, IRestFactory restClientFactory, IRequestParameterAspectFactory parameterAspectFactory, IRestResponseConverterFactory responseConverterFactory)
            : base(restClientFactory, parameterAspectFactory, responseConverterFactory)
        {
            _restCommunicationContext = restCommunicationContext;
        }

        public IGetBuildRequest WithPropertiesFilter(string propertiesFilter)
        {
            GetAspect<IGetBuildByIdParameterAspect>().SetPropertiesFilter(propertiesFilter);
            return this;
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
            return Method.Get;
        }
    }
}
