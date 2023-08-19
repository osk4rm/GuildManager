using GuildManager_Models.Characters;
using GuildManager_Models;
using MediatR;

namespace GuildManagerAPI.Queries.Characters
{
    public class GetUserCharactersQuery :IRequest<ServiceResponse<List<CharacterDto>>>
    {

    }
}
