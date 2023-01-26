using GuildManager_Models.Characters;
using GuildManagerAPI.Services.Interfaces;

namespace GuildManagerAPI.Requests
{
    public static class RaidEventsRequests
    {
        public static WebApplication RegisterRaidEventsEndpoints(this WebApplication app)
        {

            app.MapGet("/api/raid-events/getall", RaidEventsRequests.GetAll)
                .RequireAuthorization();

            app.MapGet("/api/raid-events/getbyid", RaidEventsRequests.GetById)
                .RequireAuthorization();

            app.MapGet("/api/raid-events/getmyevents", RaidEventsRequests.GetUserEvents)
                .RequireAuthorization();

            return app;
        }

        private static async Task<IResult> GetUserEvents(IRaidEventService service)
        {
            var response = await service.GetUserRaidEvents();

            return Results.Ok(response);
        }

        private static async Task<IResult> GetById(IRaidEventService service, int id)
        {
            var response = await service.GetById(id);

            return Results.Ok(response);
        }

        private static async Task<IResult> GetAll(IRaidEventService service)
        {
            var response = await service.GetAll();

            return Results.Ok(response);
        }
    }
}
