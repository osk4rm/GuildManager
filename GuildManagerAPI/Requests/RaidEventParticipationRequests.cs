using GuildManagerAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;

namespace GuildManagerAPI.Requests
{
    public static class RaidEventParticipationRequests
    {
        public static WebApplication RegisterRaidEventsParticipationEndpoints(this WebApplication app)
        {
            app.MapPost("/api/raid-events/invites/get-user-invites", RaidEventParticipationRequests.GetUserInvites)
                .RequireAuthorization();

            return app;
        }

        private static async Task<IResult> GetUserInvites(IRaidEventParticipationService service, [FromBody]SieveModel sieveModel)
        {
            var response = await service.GetUserRaidInvites(sieveModel);

            return Results.Ok(response);
        }
    }
}
