using GuildManager_Models;
using GuildManager_Models.Characters;
using GuildManagerAPI.Services.Interfaces;
using GuildManagerAPI.Validation;
using System.Security.Claims;

namespace GuildManagerAPI.Requests
{
    public static class CharactersRequests
    {
        public static WebApplication RegisterCharactersEndpoints(this WebApplication app)
        {
            app.MapPost("/api/characters/create", CharactersRequests.CreateCharacter)
                .Accepts<CreateCharacterDto>("application/json")
                .WithBodyValidator<CreateCharacterDto>();

            app.MapGet("/api/characters/getusercharacters", CharactersRequests.GetUserCharacters);

            app.MapPut("/api/characters/updatecharacter", CharactersRequests.UpdateCharacter)
                .Accepts<UpdateCharacterDto>("application/json")
                .WithBodyValidator<UpdateCharacterDto>();
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

        private static async Task<IResult> UpdateCharacter(ICharacterService service, UpdateCharacterDto dto)
        {
            var response = await service.UpdateCharacter(dto);

            return Results.Ok(response);
        }
    }
}
