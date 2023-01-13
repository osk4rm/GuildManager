using GuildManager_Models;
using GuildManager_Models.CharacterClassesAndSpecs;
using GuildManagerAPI.Services.Interfaces;

namespace GuildManagerAPI.Requests
{
    public static class ClassesRequests
    {
        public static WebApplication RegisterClassesEndpoints(this WebApplication app)
        {
            app.MapGet("/api/classes", ClassesRequests.GetAllClasses);

            return app;
        }

        private static async Task<IResult> GetAllClasses(IClassesService service)
        {
            var response = await service.GetClasses();

            return Results.Ok(response);
        }
    }
}
