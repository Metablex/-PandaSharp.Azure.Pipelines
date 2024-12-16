using PandaSharp.AzureDevOps.Context;
using PandaSharp.AzureDevOps.Services.Git.Contract;
using PandaSharp.AzureDevOps.Services.Git.Request;
using PandaSharp.AzureDevOps.Services.Git.Types;
using PandaSharp.Framework.IoC.Contract;
using PandaSharp.Framework.Rest.Common;
using PandaSharp.Framework.Rest.Contract;
using PandaSharp.Framework.Services.Aspect;
using PandaSharp.Framework.Services.Request;

namespace PandaSharp.AzureDevOps.Services.Git.Factory
{
    internal sealed class GitRequestBuilderFactory : IGitRequestBuilderFactory
    {
        private readonly IPandaContainer _container;

        public GitRequestBuilderFactory(IPandaContainer container)
        {
            _container = container;
        }

        public IGetAllGitRepositoriesRequest GetAllGitRepositories()
        {
            var context = CreateContext();
            var restFactory = CreateRestFactory();

            return new GetAllGitRepositoriesRequest(
                context,
                restFactory,
                _container.Resolve<IRequestParameterAspectFactory>(),
                _container.Resolve<IRestResponseConverterFactory>());
        }

        public IGetGitRepositoryRequest GetGitRepository(string repositoryId)
        {
            var context = CreateContext();
            context.AddContextParameter(RequestPropertyNames.RepositoryId, repositoryId);

            var restFactory = CreateRestFactory();

            return new GetGitRepositoryRequest(
                context,
                restFactory,
                _container.Resolve<IRequestParameterAspectFactory>(),
                _container.Resolve<IRestResponseConverterFactory>());
        }

        private IRestFactory CreateRestFactory()
        {
            return new RestFactory(_container.Resolve<IRestOptions>(), JsonRestSerializer.Default);
        }

        private RestCommunicationContext CreateContext()
        {
            var instanceMetaInformation = _container.Resolve<IInstanceMetaInformation>();

            var context = new RestCommunicationContext();
            context.AddContextParameter(RequestPropertyNames.Organization, instanceMetaInformation.Organization);
            context.AddContextParameter(RequestPropertyNames.Project, instanceMetaInformation.Project);

            return context;
        }
    }
}
