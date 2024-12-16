using PandaSharp.Framework.Services.Aspect;
using PandaSharp.Framework.Utils;
using RestSharp;

namespace PandaSharp.AzureDevOps.Services.Build.Aspect
{
    internal sealed class GetBuildByIdParameterAspect : RequestParameterAspectBase, IGetBuildByIdParameterAspect
    {
        private string _propertiesFilter;

        public void SetPropertiesFilter(string propertiesFilter)
        {
            _propertiesFilter = propertiesFilter;
        }

        public override void ApplyToRestRequest(RestRequest restRequest)
        {
            restRequest.AddParameterIfSet("propertyFilters", _propertiesFilter);
        }
    }
}
