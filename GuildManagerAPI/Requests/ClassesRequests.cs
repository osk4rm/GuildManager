using GuildManager_Models;
using GuildManager_Models.CharacterClassesAndSpecs;
using GuildManagerAPI.Services.Interfaces;
using System.Net;

namespace GuildManagerAPI.Requests
{
    public static class ClassesRequests
    {
        public static WebApplication RegisterClassesEndpoints(this WebApplication app)
        {
            app.MapGet("/api/classes", ClassesRequests.GetAllClasses);
            app.MapGet("/api/classes/classcount", ClassesRequests.GetClassCount);
            app.MapGet("/api/classes/rolecount", ClassesRequests.GetRoleCount);
            app.MapGet("/", Hello);
            return app;
        }

        private static string Hello()
        {
            return "Hello World!";
        }

        private static async Task<IResult> GetRoleCount(IClassesService service)
        {
            var response = await service.GetRoleCount();

            return Results.Ok(response);
        }

        private static async Task<IResult> GetClassCount(IClassesService service)
        {
            var response = await service.GetClassCount();

            return Results.Ok(response);
        }

        private static async Task<IResult> GetAllClasses(IClassesService service)
        {
            var response = await service.GetClasses();

            return Results.Ok(response);
        }
    }
}
