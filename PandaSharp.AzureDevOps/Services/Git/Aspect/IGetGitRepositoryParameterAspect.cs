namespace PandaSharp.AzureDevOps.Services.Git.Aspect
{
    internal interface IGetGitRepositoryParameterAspect
    {
        void SetIncludeParentRepository(bool includeParentRepository);
    }
}