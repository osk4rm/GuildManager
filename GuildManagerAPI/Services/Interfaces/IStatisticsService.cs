using GuildManager_Models;
using GuildManager_Models.RaidEvents;

namespace GuildManagerAPI.Services.Interfaces
{
    public interface IStatisticsService
    {
        Task<ServiceResponse<int>> GetGuildMembersCount();
        Task<ServiceResponse<int>> GetRaidsThisWeekCount();
        Task<ServiceResponse<int>> GetPendingInvitesCount();
        
    }
}
