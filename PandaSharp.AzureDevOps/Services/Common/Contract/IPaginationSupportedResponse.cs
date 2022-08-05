namespace PandaSharp.AzureDevOps.Services.Common.Contract
{
    internal interface IPaginationSupportedResponse
    {
        string ContinuationToken { get; set; }
    }
}