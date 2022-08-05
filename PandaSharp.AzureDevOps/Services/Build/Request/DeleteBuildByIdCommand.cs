using PandaSharp.AzureDevOps.Context;
using PandaSharp.AzureDevOps.Services.Build.Contract;
using PandaSharp.AzureDevOps.Services.Build.Types;
using PandaSharp.Framework.Attributes;
using PandaSharp.Framework.Rest.Contract;
using PandaSharp.Framework.Services.Aspect;
using PandaSharp.Framework.Services.Request;
using RestSharp;

namespace PandaSharp.AzureDevOps.Services.Build.Request
{
    internal sealed class DeleteBuildByIdCommand : CommandBase, IDeleteBuildByIdCommand
    {
        private readonly IInstanceMetaInformation _instanceMetaInformation;

        [InjectedProperty(RequestPropertyNames.BuildId)]
        public int BuildId { get; set; }
        
        public DeleteBuildByIdCommand(IInstanceMetaInformation instanceMetaInformation, IRestFactory restClientFactory, IRequestParameterAspectFactory parameterAspectFactory) 
            : base(restClientFactory, parameterAspectFactory)
        {
            _instanceMetaInformation = instanceMetaInformation;
        }

        protected override string GetResourcePath()
        {
            return $"{_instanceMetaInformation.Organization}/{_instanceMetaInformation.Project}/_apis/build/builds/{BuildId}";
        }

        protected override Method GetRequestMethod()
        {
            return Method.DELETE;
        }
    }
}