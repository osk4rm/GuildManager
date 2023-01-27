using Microsoft.AspNetCore.Authorization;

namespace GuildManagerAPI.Authorization
{
    public class ResourceOperationRequirement : IAuthorizationRequirement
    {
        public ResourceOperationType ResourceOperationType { get; set; }
        public ResourceOperationRequirement(ResourceOperationType resourceOperationType)
        {
            ResourceOperationType = resourceOperationType;
        }
        
    }

    public enum ResourceOperationType
    {
        Create,
        Read,
        Update,
        Delete
    }
}
