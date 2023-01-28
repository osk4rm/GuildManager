using GuildManager_Models.RaidEvents;
using GuildManager_Models;
using GuildManager_Models.RaidExpansionsAndLocations;

namespace GuildManager_WebApp.Services.ExpansionsAndLocationsService
{
    public interface IExpansionsLocationsService
    {
        Task<ServiceResponse<List<RaidExpansionDto>>> GetAllExpansions();
        Task<ServiceResponse<List<RaidLocationDto>>> GetAllLocations();
    }
}
