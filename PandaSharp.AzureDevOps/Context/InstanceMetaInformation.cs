namespace PandaSharp.AzureDevOps.Context
{
    internal sealed class InstanceMetaInformation : IInstanceMetaInformation
    {
        public string Organization { get; }
        
        public string Project { get; }

        public InstanceMetaInformation(string organization, string project)
        {
            Organization = organization;
            Project = project;
        }
    }
}