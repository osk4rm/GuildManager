using GuildManager_Models.Characters;
using GuildManager_Models.RaidEvents;
using GuildManagerAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

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

            app.MapPost("/api/raid-events/create", RaidEventsRequests.CreateRaidEvent)
                .RequireAuthorization();

            app.MapPut("/api/raid-events/update", RaidEventsRequests.UpdateRaidEvent)

            return app;
        }

        private static async Task<IResult> UpdateRaidEvent(IRaidEventService service, [FromBody] UpsertRaidEventDto dto, [FromRoute] int eventId)
        {
            var response = await service.UpdateRaidEvent(dto, eventId);

            return Results.Ok(response);
        }

        private static async Task<IResult> CreateRaidEvent(IRaidEventService service, [FromBody] UpsertRaidEventDto dto)
        {
            var response = await service.CreateRaidEvent(dto);

            return Results.Ok(response);
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
