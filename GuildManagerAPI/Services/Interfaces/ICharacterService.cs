using GuildManager_Models;
using GuildManager_Models.Characters;

namespace GuildManagerAPI.Services.Interfaces
{
    public interface ICharacterService
    {
        Task<ServiceResponse<List<CharacterDto>>> GetUserCharacters(int userId);
        Task<ServiceResponse<int>> CreateCharacter(int userId,CreateCharacterDto characterDto);
        
    }
}
