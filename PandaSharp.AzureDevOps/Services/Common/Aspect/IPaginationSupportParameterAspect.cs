namespace PandaSharp.AzureDevOps.Services.Common.Aspect
{
    internal interface IPaginationSupportParameterAspect
    {
        void SetMaxResults(int maxResults);
        
        void SetContinuationToken(string continuationToken);
    }
}