using GuildManager_Models.RaidEventParticipantsOperations;
using GuildManager_Models;
using Sieve.Models;
using GuildManager_Models.RaidEvents;

namespace GuildManager_WebApp.Services.RaidEventsParticipationService
{
    public interface IRaidEventParticipationService
    {
        Task<PagedServiceResponse<List<RaidInviteDto>>> GetUserRaidInvites(SieveModel sieveModel);
        Task<ServiceResponse<bool?>> InviteForRaidEvent(int eventId, int characterId);
        Task<ServiceResponse<bool?>> CancelApplicationForRaidEvent(int eventId, int characterId);
        Task<ServiceResponse<RaidEventCharacterDto>> UpdateCharacterAcceptanceStatus(UpdateRaidEventCharacterDto dto);
    }
}
