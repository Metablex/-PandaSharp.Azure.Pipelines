namespace PandaSharp.AzureDevOps.Services.Git.Aspect
{
    internal interface IGetAllGitRepositoriesParameterAspect
    {
        void SetIncludeAllRemoteUrls(bool includeAllRemoteUrls);
        
        void SetIncludeHidden(bool includeHidden);
        
        void SetIncludeReferenceLinks(bool includeReferenceLinks);
    }
}