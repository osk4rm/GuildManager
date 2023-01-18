using GuildManager_Models;
using GuildManager_Models.Characters;

namespace GuildManagerAPI.Services.Interfaces
{
    public interface ICharacterService
    {
        Task<ServiceResponse<List<CharacterDto>>> GetUserCharacters(int userId);
        Task<ServiceResponse<int>> CreateCharacter(int userId,CreateCharacterDto characterDto);
        Task<ServiceResponse<bool>> DeleteCharacter(int userId, string characterName);
        Task<ServiceResponse<CharacterDto>> UpdateCharacter(int characterId, UpdateCharacterDto characterDto);
        
    }
}
