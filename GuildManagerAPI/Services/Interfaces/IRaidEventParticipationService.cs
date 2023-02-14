using GuildManager_Models;
using GuildManager_Models.RaidEventParticipantsOperations;
using Sieve.Models;

namespace GuildManagerAPI.Services.Interfaces
{
    public interface IRaidEventParticipationService
    {
        Task<PagedServiceResponse<List<RaidInviteDto>>> GetUserRaidInvites(SieveModel sieveModel);
    }
}
