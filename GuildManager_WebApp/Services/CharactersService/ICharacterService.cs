using GuildManager_Models;
using GuildManager_Models.Characters;

namespace GuildManager_WebApp.Services.CharactersService
{
    public interface ICharacterService
    {
        Task<ServiceResponse<int?>> CreateCharacter(CreateCharacterDto characterDto);
        Task<ServiceResponse<List<CharacterDto>>> GetUserCharacters();
    }
}
