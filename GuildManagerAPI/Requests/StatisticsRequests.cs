using GuildManagerAPI.Services.Interfaces;

namespace GuildManagerAPI.Requests
{
    public static class StatisticsRequests
    {
        public static WebApplication RegisterStatisticsEndpoint(this WebApplication app)
        {
            app.MapGet("/api/stats/members-count", StatisticsRequests.GetGuildMembersCount)
                .RequireAuthorization();

            app.MapGet("/api/stats/pending-invites", StatisticsRequests.GetPendingInvitesCount)
                .RequireAuthorization();

            app.MapGet("/api/stats/raids-this-week", StatisticsRequests.GetRaidsThisWeekCount)
                .RequireAuthorization();

            return app;
        }

        private static async Task<IResult> GetRaidsThisWeekCount(IStatisticsService service)
        {
            var response = await service.GetRaidsThisWeekCount();

            return Results.Ok(response);
        }

        private static async Task<IResult> GetPendingInvitesCount(IStatisticsService service)
        {
            var response = await service.GetPendingInvitesCount();

            return Results.Ok(response);
        }

        private static async Task<IResult> GetGuildMembersCount(IStatisticsService service)
        {
            var response = await service.GetGuildMembersCount();

            return Results.Ok(response);
        }
    }
}
