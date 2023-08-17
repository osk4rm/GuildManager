using GuildManager_Models.CharacterClassesAndSpecs;
using GuildManager_Models;
using MediatR;

namespace GuildManagerAPI.Queries.CharacterClasses
{
    public class GetClassCountQuery : IRequest<ServiceResponse<List<ClassCountDto>>>
    {
    }
}
