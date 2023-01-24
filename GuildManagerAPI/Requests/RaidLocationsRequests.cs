using GuildManagerAPI.Services.Interfaces;

namespace GuildManagerAPI.Requests
{
    public static class RaidLocationsRequests
    {
        public static WebApplication RegisterRaidLocationsEndpoints(this WebApplication app)
        {
            app.MapGet("/api/raid-locations", RaidLocationsRequests.GetAllLocations);

            return app;
        }

        private static async Task<IResult> GetAllLocations(IRaidLocationService service)
        {
            var response = await service.GetAll();

            return Results.Ok(response);
        }
    }
}
