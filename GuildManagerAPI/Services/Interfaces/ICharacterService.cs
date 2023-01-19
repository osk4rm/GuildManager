using GuildManager_Models;
using GuildManager_Models.Characters;

namespace GuildManagerAPI.Services.Interfaces
{
    public interface ICharacterService
    {
        Task<ServiceResponse<List<CharacterDto>>> GetUserCharacters(int userId);
        Task<ServiceResponse<int>> CreateCharacter(int userId,CreateCharacterDto characterDto);
        Task<ServiceResponse<bool>> DeleteCharacter(int id);
        Task<ServiceResponse<CharacterDto>> UpdateCharacter(UpdateCharacterDto characterDto);
        
    }
}
