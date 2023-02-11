using GuildManager_Models.Characters;
using GuildManager_Models.RaidEvents;
using GuildManagerAPI.Services.Interfaces;
using GuildManagerAPI.Validation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sieve.Models;

namespace GuildManagerAPI.Requests
{
    public static class RaidEventsRequests
    {
        public static WebApplication RegisterRaidEventsEndpoints(this WebApplication app)
        {

            app.MapGet("/api/raid-events/getall", RaidEventsRequests.GetAll)
                .RequireAuthorization();

            app.MapGet("/api/raid-events/get/{id}", RaidEventsRequests.GetById)
                .RequireAuthorization();

            app.MapGet("/api/raid-events/getmyevents", RaidEventsRequests.GetUserEvents)
                .RequireAuthorization();

            app.MapPost("/api/raid-events/create", RaidEventsRequests.CreateRaidEvent)
                .Accepts<UpsertRaidEventDto>("application/json")
                .RequireAuthorization()
                .WithBodyValidator<UpsertRaidEventDto>();

            app.MapPut("/api/raid-events/update/{eventId}", RaidEventsRequests.UpdateRaidEvent)
                .Accepts<UpsertRaidEventDto>("application/json")
                .RequireAuthorization()
                .WithBodyValidator<UpsertRaidEventDto>();

            app.MapDelete("/api/raid-events/delete/{eventId}", RaidEventsRequests.DeleteRaidEvent)
                .RequireAuthorization();

            app.MapPost("/api/raid-events/join/{eventId}", RaidEventsRequests.JoinRaidEvent)
                .RequireAuthorization();

            app.MapDelete("/api/raid-events/{eventId}/remove-application", RaidEventsRequests.CancelApplicationForRaidEvent)
                .RequireAuthorization();

            app.MapGet("/api/raid-events/participants/{eventId}", RaidEventsRequests.GetParticipants)
                .RequireAuthorization();

            app.MapPut("/api/raid-events/participants/update-status", RaidEventsRequests.UpdateAcceptanceStatusForEvent)
                .Accepts<UpdateRaidEventCharacterDto>("application/json")
                .RequireAuthorization()
                .WithBodyValidator<UpdateRaidEventCharacterDto>();

            app.MapGet("/api/raid-events/{eventId}/comments", RaidEventsRequests.GetCommentsForRaidEvent)
                .RequireAuthorization();

            app.MapPost("/api/raid-events/{eventId}/comments/create", RaidEventsRequests.CreateCommentForRaidEvent)
                .RequireAuthorization();

            app.MapPut("/api/raid-events/comments/update/{commentId}", RaidEventsRequests.UpdateComment)
                .RequireAuthorization();

            app.MapDelete("/api/raid-events/comments/delete/{commentId}", RaidEventsRequests.DeleteComment)
                .RequireAuthorization();

            app.MapPost("/api/raid-events/get-paged", RaidEventsRequests.GetPagedRaidEvents)
                .RequireAuthorization();

            return app;
        }

        private static async Task<IResult> GetPagedRaidEvents(IRaidEventService service, [FromBody]SieveModel sieveModel)
        {
            var response = await service.GetPagedRaidEvents(sieveModel);

            return Results.Ok(response);
        }

        private static async Task<IResult> DeleteComment(IRaidEventService service, [FromRoute] int commentId)
        {
            var response = await service.DeleteCommentForRaidEvent(commentId);

            return Results.Ok(response);
        }

        private static async Task<IResult> UpdateComment(IRaidEventService service, [FromRoute] int commentId, [FromBody] string message)
        {
            var response = await service.UpdateCommentForRaidEvent(commentId, message);

            return Results.Ok(response);
        }

        private static async Task<IResult> CreateCommentForRaidEvent(IRaidEventService service, [FromRoute] int eventId, [FromBody]string message)
        {
            var response = await service.CreateCommentForRaidEvent(eventId, message);

            return Results.Ok(response);
        }

        private static async Task<IResult> GetCommentsForRaidEvent(IRaidEventService service, [FromRoute]int eventId)
        {
            var response = await service.GetCommentsForRaidEvent(eventId);

            return Results.Ok(response);
        }

        private static async Task<IResult> UpdateAcceptanceStatusForEvent(IRaidEventService service, UpdateRaidEventCharacterDto dto)
        {
            var response = await service.UpdateCharacterStatusForEvent(dto);

            return Results.Ok(response);
        }

        private static async Task<IResult> GetParticipants(IRaidEventService service, [FromRoute] int eventId)
        {
            var response = await service.GetParticipants(eventId);

            return Results.Ok(response);
        }

        private static async Task<IResult> DeleteRaidEvent(IRaidEventService service, [FromRoute]int eventId)
        {
            var response = await service.DeleteRaidEvent(eventId);

            return Results.Ok(response);
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

        private static async Task<IResult> GetById(IRaidEventService service, [FromRoute]int id)
        {
            var response = await service.GetById(id);

            return Results.Ok(response);
        }

        private static async Task<IResult> GetAll(IRaidEventService service)
        {
            var response = await service.GetAll();

            return Results.Ok(response);
        }

        private static async Task<IResult> JoinRaidEvent(IRaidEventService service, [FromRoute]int eventId, [FromQuery]int characterId)
        {
            var response = await service.JoinRaidEvent(eventId, characterId);

            return Results.Ok(response);
        }

        private static async Task<IResult> CancelApplicationForRaidEvent(IRaidEventService service, [FromRoute] int eventId, [FromQuery] int characterId)
        {
            var result = await service.CancelApplicationForRaidEvent(eventId, characterId);

            return Results.Ok(result);
        }
    }
}
