using System;
using PandaSharp.AzureDevOps.Services.Build.Types;
using PandaSharp.AzureDevOps.Services.Common.Types;
using PandaSharp.Framework.Services.Aspect;
using PandaSharp.Framework.Utils;
using RestSharp;

namespace PandaSharp.AzureDevOps.Services.Build.Aspect
{
    internal sealed class GetAllBuildsParameterAspect : RequestParameterAspectBase, IGetAllBuildsParameterAspect
    {
        private string _branchName;
        private int[] _buildIds;
        private string _buildNumber;
        private int[] _definitionIds;
        private int? _maxBuildsPerDefinition;
        private DateTime? _minTimeUtc;
        private DateTime? _maxTimeUtc;
        private BuildResultOrder? _resultOrder;
        private IncludeDeletedBuilds? _includeDeletedBuilds;
        private BuildReason? _buildReason;
        private BuildStatus? _buildStatus;
        private BuildResult? _buildResult;
        private string[] _properties;
        private int[] _queueIds;
        private string _repositoryId;
        private RepositoryType? _repositoryType;
        private string[] _tags;
        private string _requester;

        public void SetBranchNameFilter(string branchName)
        {
            _branchName = branchName;
        }

        public void SetBuildIdsFilter(int[] buildIds)
        {
            _buildIds = buildIds;
        }

        public void SetBuildNumberFilter(string buildNumber)
        {
            _buildNumber = buildNumber;
        }

        public void SetDefinitionIdsFilter(int[] definitionIds)
        {
            _definitionIds = definitionIds;
        }

        public void SetMaxBuildsPerDefinitionFilter(int maxBuildsPerDefinition)
        {
            _maxBuildsPerDefinition = maxBuildsPerDefinition;
        }

        public void SetMinTimeFilter(DateTime minTime)
        {
            _minTimeUtc = minTime;
        }

        public void SetMaxTimeFilter(DateTime maxTime)
        {
            _maxTimeUtc = maxTime;
        }

        public void SetResultOrder(BuildResultOrder resultOrder)
        {
            _resultOrder = resultOrder;
        }

        public void SetIncludeDeletedBuildsFilter(IncludeDeletedBuilds includeDeletedBuilds)
        {
            _includeDeletedBuilds = includeDeletedBuilds;
        }

        public void SetBuildReasonFilter(BuildReason buildReason)
        {
            _buildReason = buildReason;
        }

        public void SetBuildStatusFilter(BuildStatus buildStatus)
        {
            _buildStatus = buildStatus;
        }

        public void SetBuildResultFilter(BuildResult buildResult)
        {
            _buildResult = buildResult;
        }

        public void SetPropertiesFilter(string[] properties)
        {
            _properties = properties;
        }

        public void SetQueueIdsFilter(int[] queueIds)
        {
            _queueIds = queueIds;
        }

        public void SetRepositoryIdFilter(string repositoryId)
        {
            _repositoryId = repositoryId;
        }

        public void SetRepositoryTypeFilter(RepositoryType repositoryType)
        {
            _repositoryType = repositoryType;
        }

        public void SetTagsFilter(string[] tags)
        {
            _tags = tags;
        }

        public void SetRequesterFilter(string requester)
        {
            _requester = requester;
        }

        public override void ApplyToRestRequest(IRestRequest restRequest)
        {
            restRequest
                .AddParameterIfSet("branchName", _branchName)
                .AddParameterValues("buildIds", _buildIds)
                .AddParameterIfSet("buildNumber", _buildNumber)
                .AddParameterValues("definitions", _definitionIds)
                .AddParameterIfSet("maxBuildsPerDefinition", _maxBuildsPerDefinition)
                .AddParameterIfSet("minTime", _minTimeUtc)
                .AddParameterIfSet("maxTime", _maxTimeUtc)
                .AddParameterIfSet("queryOrder", _resultOrder)
                .AddParameterIfSet("deletedFilter", _includeDeletedBuilds)
                .AddParameterIfSet("reasonFilter", _buildReason)
                .AddParameterIfSet("statusFilter", _buildStatus)
                .AddParameterIfSet("resultFilter", _buildResult)
                .AddParameterValues("properties", _properties)
                .AddParameterValues("queues", _queueIds)
                .AddParameterIfSet("repositoryId", _repositoryId)
                .AddParameterIfSet("repositoryType", _repositoryType)
                .AddParameterValues("tagFilters", _tags)
                .AddParameterIfSet("requestedFor", _requester);
        }
    }
}