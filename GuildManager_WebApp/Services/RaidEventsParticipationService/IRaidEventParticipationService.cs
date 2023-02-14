using GuildManager_Models.RaidEventParticipantsOperations;
using GuildManager_Models;
using Sieve.Models;

namespace GuildManager_WebApp.Services.RaidEventsParticipationService
{
    public interface IRaidEventParticipationService
    {
        Task<PagedServiceResponse<List<RaidInviteDto>>> GetUserRaidInvites(SieveModel sieveModel);
    }
}
