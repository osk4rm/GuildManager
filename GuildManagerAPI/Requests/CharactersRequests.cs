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
                .WithBodyValidator<CreateCharacterDto>()
                .RequireAuthorization();
            

            app.MapGet("/api/characters/getusercharacters", CharactersRequests.GetUserCharacters)
                .RequireAuthorization();

            app.MapPut("/api/characters/updatecharacter", CharactersRequests.UpdateCharacter)
                .Accepts<UpdateCharacterDto>("application/json")
                .WithBodyValidator<UpdateCharacterDto>()
                .RequireAuthorization();

            app.MapDelete("/api/characters/delete/{id}", CharactersRequests.DeleteCharacter)
                .RequireAuthorization();

            return app;
        }
        private static async Task<IResult> CreateCharacter(ICharacterService service, CreateCharacterDto dto, ClaimsPrincipal user)
        {
            var response = await service.CreateCharacter(dto);

            return Results.Ok(response);
        }

        private static async Task<IResult> GetUserCharacters(ICharacterService service)
        {
            var response = await service.GetUserCharacters();

            return Results.Ok(response);
        }

        private static async Task<IResult> UpdateCharacter(ICharacterService service, UpdateCharacterDto dto)
        {
            var response = await service.UpdateCharacter(dto);

            return Results.Ok(response);
        }

        private static async Task<IResult> DeleteCharacter(ICharacterService service, int id)
        {
            var response = await service.DeleteCharacter(id);

            return Results.Ok(response);
        }
    }
}
