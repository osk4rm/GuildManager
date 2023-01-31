using GuildManager_Models;
using GuildManager_Models.RaidEvents;

namespace GuildManagerAPI.Services.Interfaces
{
    public interface IRaidEventService
    {
        Task<ServiceResponse<List<RaidEventDto>>> GetAll();
        Task<ServiceResponse<RaidEventDto>> GetById(int id);
        Task<ServiceResponse<List<RaidEventDto>>> GetUserRaidEvents();
        Task<ServiceResponse<int>> CreateRaidEvent(UpsertRaidEventDto dto);
        Task<ServiceResponse<RaidEventDto>> UpdateRaidEvent(UpsertRaidEventDto dto, int id);
        Task<ServiceResponse<bool>> DeleteRaidEvent(int id);
        Task<ServiceResponse<bool>> JoinRaidEvent(int eventId, int characterId);

    }
}
