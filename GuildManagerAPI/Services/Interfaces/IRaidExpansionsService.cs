using GuildManager_Models;
using GuildManager_Models.RaidExpansionsAndLocations;

namespace GuildManagerAPI.Services.Interfaces
{
    public interface IRaidExpansionsService
    {
        Task<ServiceResponse<List<RaidExpansionDto>>> GetAll();
    }
}
