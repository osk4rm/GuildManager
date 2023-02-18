using GuildManager_Models;
using GuildManager_Models.RaidEvents;

namespace GuildManager_WebApp.Services.DashboardStatsService
{
    public interface IStatsService
    {
        Task<ServiceResponse<int?>> GetGuildMembersCount();
        Task<ServiceResponse<int?>> GetRaidsThisWeekCount();
        Task<ServiceResponse<int?>> GetPendingInvitesCount();
        Task<ServiceResponse<RaidEventDto>> GetUpcomingEvent();
    }
}
