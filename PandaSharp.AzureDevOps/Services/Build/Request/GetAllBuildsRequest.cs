using System;
using PandaSharp.AzureDevOps.Context;
using PandaSharp.AzureDevOps.Services.Build.Aspect;
using PandaSharp.AzureDevOps.Services.Build.Contract;
using PandaSharp.AzureDevOps.Services.Build.Response;
using PandaSharp.AzureDevOps.Services.Build.Types;
using PandaSharp.AzureDevOps.Services.Common.Aspect;
using PandaSharp.AzureDevOps.Services.Common.Contract;
using PandaSharp.AzureDevOps.Services.Common.Rest;
using PandaSharp.AzureDevOps.Services.Common.Types;
using PandaSharp.Framework.Attributes;
using PandaSharp.Framework.Rest.Contract;
using PandaSharp.Framework.Services.Aspect;
using PandaSharp.Framework.Services.Request;
using RestSharp;

namespace PandaSharp.AzureDevOps.Services.Build.Request
{
    [SupportsParameterAspect(typeof(IGetAllBuildsParameterAspect))]
    [SupportsParameterAspect(typeof(IPaginationSupportParameterAspect))]
    [RestResponseConverter(typeof(RestResponseConverter))]
    internal sealed class GetAllBuildsRequest : RequestBase<BuildListResponse>, IGetAllBuildsRequest, IPaginationSupportedRequest
    {
        private readonly IInstanceMetaInformation _instanceMetaInformation;

        public GetAllBuildsRequest(IInstanceMetaInformation instanceMetaInformation, IRestFactory restClientFactory, IRequestParameterAspectFactory parameterAspectFactory, IRestResponseConverterFactory responseConverterFactory)
            : base(restClientFactory, parameterAspectFactory, responseConverterFactory)
        {
            _instanceMetaInformation = instanceMetaInformation;
        }

        public IGetAllBuildsRequest WithBranchName(string branchName)
        {
            GetAspect<IGetAllBuildsParameterAspect>().SetBranchNameFilter(branchName);
            return this;
        }

        public IGetAllBuildsRequest WithBuildIds(params int[] buildIds)
        {
            GetAspect<IGetAllBuildsParameterAspect>().SetBuildIdsFilter(buildIds);
            return this;
        }

        public IGetAllBuildsRequest WithBuildNumber(string buildNumber)
        {
            GetAspect<IGetAllBuildsParameterAspect>().SetBuildNumberFilter(buildNumber);
            return this;
        }

        public IGetAllBuildsRequest WithDefinitionIds(params int[] definitionIds)
        {
            GetAspect<IGetAllBuildsParameterAspect>().SetDefinitionIdsFilter(definitionIds);
            return this;
        }

        public IGetAllBuildsRequest WithMaxBuildsPerDefinition(int maxBuildsPerDefinition)
        {
            GetAspect<IGetAllBuildsParameterAspect>().SetMaxBuildsPerDefinitionFilter(maxBuildsPerDefinition);
            return this;
        }

        public IGetAllBuildsRequest WithMinTime(DateTime minTimeUtc)
        {
            GetAspect<IGetAllBuildsParameterAspect>().SetMinTimeFilter(minTimeUtc);
            return this;
        }

        public IGetAllBuildsRequest WithMaxTime(DateTime maxTimeUtc)
        {
            GetAspect<IGetAllBuildsParameterAspect>().SetMaxTimeFilter(maxTimeUtc);
            return this;
        }

        public IGetAllBuildsRequest WithResultOrder(BuildResultOrder resultOrder)
        {
            GetAspect<IGetAllBuildsParameterAspect>().SetResultOrder(resultOrder);
            return this;
        }

        public IGetAllBuildsRequest WithDeletedBuilds(IncludeDeletedBuilds includeDeletedBuilds)
        {
            GetAspect<IGetAllBuildsParameterAspect>().SetIncludeDeletedBuildsFilter(includeDeletedBuilds);
            return this;
        }

        public IGetAllBuildsRequest WithBuildReason(BuildReason buildReason)
        {
            GetAspect<IGetAllBuildsParameterAspect>().SetBuildReasonFilter(buildReason);
            return this;
        }

        public IGetAllBuildsRequest WithBuildStatus(BuildStatus buildStatus)
        {
            GetAspect<IGetAllBuildsParameterAspect>().SetBuildStatusFilter(buildStatus);
            return this;
        }

        public IGetAllBuildsRequest WithBuildResult(BuildResult buildResult)
        {
            GetAspect<IGetAllBuildsParameterAspect>().SetBuildResultFilter(buildResult);
            return this;
        }

        public IGetAllBuildsRequest WithProperties(params string[] properties)
        {
            GetAspect<IGetAllBuildsParameterAspect>().SetPropertiesFilter(properties);
            return this;
        }

        public IGetAllBuildsRequest WithQueueIds(params int[] queueIds)
        {
            GetAspect<IGetAllBuildsParameterAspect>().SetQueueIdsFilter(queueIds);
            return this;
        }

        public IGetAllBuildsRequest WithRepositoryId(string repositoryId)
        {
            GetAspect<IGetAllBuildsParameterAspect>().SetRepositoryIdFilter(repositoryId);
            return this;
        }

        public IGetAllBuildsRequest WithRepositoryType(RepositoryType repositoryType)
        {
            GetAspect<IGetAllBuildsParameterAspect>().SetRepositoryTypeFilter(repositoryType);
            return this;
        }

        public IGetAllBuildsRequest WithTags(params string[] tags)
        {
            GetAspect<IGetAllBuildsParameterAspect>().SetTagsFilter(tags);
            return this;
        }

        public IGetAllBuildsRequest WithRequester(string requester)
        {
            GetAspect<IGetAllBuildsParameterAspect>().SetRequesterFilter(requester);
            return this;
        }

        public void WithMaxResult(int maxResults)
        {
            GetAspect<IPaginationSupportParameterAspect>().SetMaxResults(maxResults);
        }

        public void WithContinuationToken(string continuationToken)
        {
            GetAspect<IPaginationSupportParameterAspect>().SetContinuationToken(continuationToken);
        }

        protected override string GetResourcePath()
        {
            return $"{_instanceMetaInformation.Organization}/{_instanceMetaInformation.Project}/_apis/build/builds";
        }

        protected override Method GetRequestMethod()
        {
            return Method.GET;
        }
    }
}