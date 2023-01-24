using GuildManager_Models.RaidExpansionsAndLocations;
using GuildManager_Models;

namespace GuildManagerAPI.Services.Interfaces
{
    public interface IRaidLocationService
    {
        Task<ServiceResponse<List<RaidLocationDto>>> GetAll();
    }
}
