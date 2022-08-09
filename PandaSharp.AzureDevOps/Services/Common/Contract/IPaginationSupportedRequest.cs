namespace PandaSharp.AzureDevOps.Services.Common.Contract
{
    internal interface IPaginationSupportedRequest
    {
        void WithMaxResult(int maxResults);
        
        void WithContinuationToken(string continuationToken);
    }
}