using GuildManager_Models;
using GuildManager_Models.Characters;
using GuildManagerAPI.Services.Interfaces;
using System.Security.Claims;

namespace GuildManagerAPI.Requests
{
    public static class CharactersRequests
    {
        public static WebApplication RegisterCharactersEndpoints(this WebApplication app)
        {
            app.MapPost("/api/characters/create", CharactersRequests.CreateCharacter)
                .Accepts<CreateCharacterDto>("application/json");
            //.WithBodyValidator<CharacterDto>();

            app.MapGet("/api/characters/getusercharacters", CharactersRequests.GetUserCharacters);
            return app;
        }
        private static async Task<IResult> CreateCharacter(ICharacterService service, CreateCharacterDto dto, ClaimsPrincipal user)
        {
            string userId = user.FindFirstValue(ClaimTypes.NameIdentifier);
            var response = await service.CreateCharacter(int.Parse(userId), dto);

            return Results.Ok(response);
        }

        private static async Task<IResult> GetUserCharacters(ICharacterService service, ClaimsPrincipal user)
        {
            string userId = user.FindFirstValue(ClaimTypes.NameIdentifier);
            var response = await service.GetUserCharacters(int.Parse(userId));

            return Results.Ok(response);
        }
    }
}
