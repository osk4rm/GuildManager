using GuildManagerAPI.Services.Interfaces;

namespace GuildManagerAPI.Requests
{
    public static class RaidExpansionsRequests
    {
        public static WebApplication RegisterRaidExpansionsEndpoints(this WebApplication app)
        {
            app.MapGet("/api/expansions", RaidExpansionsRequests.GetAllExpansions);

            return app;
        }

        private static async Task<IResult> GetAllExpansions(IRaidExpansionsService service)
        {
            var response = await service.GetAll();

            return Results.Ok(response);
        }
    }
}
