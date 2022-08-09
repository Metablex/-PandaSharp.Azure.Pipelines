using System;
using PandaSharp.AzureDevOps.Services.Build.Types;
using PandaSharp.AzureDevOps.Services.Common.Types;

namespace PandaSharp.AzureDevOps.Services.Build.Aspect
{
    internal interface IGetAllBuildsParameterAspect
    {
        void SetBranchNameFilter(string branchName);
        
        void SetBuildIdsFilter(int[] buildIds);
        
        void SetBuildNumberFilter(string buildNumber);
        
        void SetDefinitionIdsFilter(int[] definitionIds);
        
        void SetMaxBuildsPerDefinitionFilter(int maxBuildsPerDefinition);
        
        void SetMinTimeFilter(DateTime minTime);
        
        void SetMaxTimeFilter(DateTime maxTime);
        
        void SetResultOrder(BuildResultOrder resultOrder);
        
        void SetIncludeDeletedBuildsFilter(IncludeDeletedBuilds includeDeletedBuilds);
        
        void SetBuildReasonFilter(BuildReason buildReason);
        
        void SetBuildStatusFilter(BuildStatus buildStatus);
        
        void SetBuildResultFilter(BuildResult buildResult);
        
        void SetPropertiesFilter(string[] properties);
        
        void SetQueueIdsFilter(int[] queueIds);
        
        void SetRepositoryIdFilter(string repositoryId);
        
        void SetRepositoryTypeFilter(RepositoryType repositoryType);
        
        void SetTagsFilter(string[] tags);
        
        void SetRequesterFilter(string requester);
    }
}