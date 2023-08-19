using GuildManager_Models.Characters;
using GuildManager_Models;
using GuildManagerAPI.Queries.Characters;
using MediatR;
using Azure;
using GuildManagerAPI.Services.Interfaces;

namespace GuildManagerAPI.Handlers.Characters
{
    public class GetUserCharactersQueryHandler : IRequestHandler<GetUserCharactersQuery, ServiceResponse<List<CharacterDto>>>
    {
        private readonly ICharacterService _characterService;

        public GetUserCharactersQueryHandler(ICharacterService characterService)
        {
            _characterService = characterService;
        }
        public async Task<ServiceResponse<List<CharacterDto>>> Handle(GetUserCharactersQuery request, CancellationToken cancellationToken)
        {
            return await _characterService.GetUserCharacters();
        }
    }
}
