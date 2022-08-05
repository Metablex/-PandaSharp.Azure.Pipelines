using PandaSharp.AzureDevOps.Services.Build.Response;
using PandaSharp.Framework.Services.Contract;

namespace PandaSharp.AzureDevOps.Services.Build.Contract
{
    public interface IGetBuildRequest : IRequestBase<BuildResponse>
    {
        IGetBuildRequest WithPropertiesFilter(string propertiesFilter);
    }
}