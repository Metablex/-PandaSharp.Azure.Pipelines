namespace PandaSharp.AzureDevOps.Context
{
    internal interface IInstanceMetaInformation
    {
        string Organization { get; }
        
        string Project { get; }
    }
}