using GuildManagerAPI.Models.Auth;
using GuildManagerAPI.Services;
using GuildManagerAPI.Validation;
using Microsoft.AspNetCore.Mvc;

namespace GuildManagerAPI.Requests
{
    public static class LoginRequests
    {
        public static WebApplication RegisterLoginEndpoints(this WebApplication app)
        {
            app.MapGet("/api/login", LoginRequests.Login)
                .Accepts<LoginDto>("application/json")
                .WithBodyValidator<LoginDto>();

            return app;
        }
        public static IResult Login(ILoginService service, LoginDto dto)
        {
            string token = service.GenerateJwt(dto);

            return Results.Ok(token);
        }
    }
}
