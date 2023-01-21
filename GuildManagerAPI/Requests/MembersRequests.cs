using GuildManagerAPI.Services.Interfaces;

namespace GuildManagerAPI.Requests
{
    internal static class MembersRequests
    {
        public static WebApplication RegisterMembersEndpoints(this WebApplication app)
        {
            app.MapGet("/api/members/getmembers", MembersRequests.GetMembers)
                .RequireAuthorization();

            return app;
        }

        private static async Task<IResult> GetMembers(IMembersService service)
        {
            var response = await service.GetMembers();

            return Results.Ok(response);
        }
    }
}
