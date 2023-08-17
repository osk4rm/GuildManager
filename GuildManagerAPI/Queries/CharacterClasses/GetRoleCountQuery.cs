using GuildManager_Models.CharacterClassesAndSpecs;
using GuildManager_Models;
using MediatR;

namespace GuildManagerAPI.Queries.CharacterClasses
{
    public class GetRoleCountQuery : IRequest<ServiceResponse<List<RoleCountDto>>>
    {
    }
}
