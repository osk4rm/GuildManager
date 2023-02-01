using GuildManager_DataAccess.Entities.Raids;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace GuildManagerAPI.Authorization
{
    public class CommentOperationRequirementHandler : AuthorizationHandler<ResourceOperationRequirement, Comment>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ResourceOperationRequirement requirement, Comment comment)
        {
            if (requirement.ResourceOperationType == ResourceOperationType.Create || requirement.ResourceOperationType == ResourceOperationType.Read)
            {
                context.Succeed(requirement);
            }

            var userId = int.Parse(context.User.FindFirstValue(ClaimTypes.NameIdentifier));

            if (comment.AuthorId == userId)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
