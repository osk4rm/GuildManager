using GuildManager_DataAccess.Entities.Raids;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace GuildManagerAPI.Authorization
{
    public class ResourceOperationRequirementHandler : AuthorizationHandler<ResourceOperationRequirement, RaidEvent>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ResourceOperationRequirement requirement, RaidEvent resource)
        {
            if(requirement.ResourceOperationType == ResourceOperationType.Create || requirement.ResourceOperationType == ResourceOperationType.Read)
            {
                context.Succeed(requirement);
            }

            var userId = int.Parse(context.User.FindFirstValue(ClaimTypes.NameIdentifier));

            if(resource.CreatedById == userId)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
