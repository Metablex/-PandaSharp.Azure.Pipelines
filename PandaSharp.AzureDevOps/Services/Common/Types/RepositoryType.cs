using Newtonsoft.Json;
using PandaSharp.Framework.Attributes;
using PandaSharp.Framework.Services.Converter;

namespace PandaSharp.AzureDevOps.Services.Common.Types
{
    [JsonConverter(typeof(EnumToStringRepresentationConverter))]
    public enum RepositoryType
    {
        [StringRepresentation("TfsGit")]
        AzureReposGit,
        
        [StringRepresentation("TfsVersionControl")]
        AzureReposTfvc,
        
        [StringRepresentation("Github")]
        Github,
        
        [StringRepresentation("GitHubEnterprise")]
        GithubEnterprise,
        
        [StringRepresentation("Bitbucket")]
        Bitbucket,
        
        [StringRepresentation("svn")]
        Subversion,
        
        [StringRepresentation("Git")]
        ExternalGit
    }
}