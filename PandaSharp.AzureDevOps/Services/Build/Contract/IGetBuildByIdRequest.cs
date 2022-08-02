using PandaSharp.AzureDevOps.Services.Build.Response;
using PandaSharp.Framework.Services.Contract;

namespace PandaSharp.AzureDevOps.Services.Build.Contract
{
    public interface IGetBuildByIdRequest : IRequestBase<BuildResponse>
    {
        IGetBuildByIdRequest WithPropertiesFilter(string propertiesFilter);
    }
}