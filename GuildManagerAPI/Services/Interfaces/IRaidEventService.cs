using GuildManager_Models;
using GuildManager_Models.RaidEvents;

namespace GuildManagerAPI.Services.Interfaces
{
    public interface IRaidEventService
    {
        Task<ServiceResponse<List<RaidEventDto>>> GetAll();
        Task<ServiceResponse<RaidEventDto>> GetById(int id);
        Task<ServiceResponse<List<RaidEventDto>>> GetUserRaidEvents();

    }
}
