using System;
using PandaSharp.AzureDevOps.Services.Build.Response;
using PandaSharp.AzureDevOps.Services.Build.Types;
using PandaSharp.AzureDevOps.Services.Common.Types;
using PandaSharp.Framework.Services.Contract;

namespace PandaSharp.AzureDevOps.Services.Build.Contract
{
    public interface IGetAllBuildsRequest : IRequestBase<BuildListResponse>
    {
        IGetAllBuildsRequest WithBranchName(string branchName);
        
        IGetAllBuildsRequest WithBuildIds(params int[] buildIds);
        
        IGetAllBuildsRequest WithBuildNumber(string buildNumber);
        
        IGetAllBuildsRequest WithDefinitionIds(params int[] definitionIds);
        
        IGetAllBuildsRequest WithMaxBuildsPerDefinition(int maxBuildsPerDefinition);

        IGetAllBuildsRequest WithMinTime(DateTime minTimeUtc);
        
        IGetAllBuildsRequest WithMaxTime(DateTime maxTimeUtc);
        
        IGetAllBuildsRequest WithResultOrder(BuildResultOrder resultOrder);
        
        IGetAllBuildsRequest WithDeletedBuilds(IncludeDeletedBuilds includeDeletedBuilds);
        
        IGetAllBuildsRequest WithBuildReason(BuildReason buildReason);
        
        IGetAllBuildsRequest WithBuildStatus(BuildStatus buildStatus);
        
        IGetAllBuildsRequest WithBuildResult(BuildResult buildResult);
        
        IGetAllBuildsRequest WithProperties(params string[] properties);
        
        IGetAllBuildsRequest WithQueueIds(params int[] queueIds);
        
        IGetAllBuildsRequest WithRepositoryId(string repositoryId);
        
        IGetAllBuildsRequest WithRepositoryType(RepositoryType repositoryType);
        
        IGetAllBuildsRequest WithTags(params string[] tags);
        
        IGetAllBuildsRequest WithRequester(string requester);
    }
}