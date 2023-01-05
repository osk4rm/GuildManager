using GuildManager_Models;
using GuildManagerAPI.Services;
using GuildManagerAPI.Validation;
using Microsoft.AspNetCore.Mvc;

namespace GuildManagerAPI.Requests
{
    public static class LoginRequests
    {
        public static WebApplication RegisterLoginEndpoints(this WebApplication app)
        {
            app.MapPost("/api/login", LoginRequests.Login)
                .Accepts<LoginDto>("application/json")
                .WithBodyValidator<LoginDto>();

            app.MapPost("/api/register", LoginRequests.Register)
                .Accepts<RegisterUserDto>("application/json")
                .WithBodyValidator<RegisterUserDto>();

            return app;
        }
        public static IResult Login(ILoginService service, LoginDto dto)
        {
            var token = service.GenerateJwt(dto);
            
            return Results.Ok(token);
        }

        public static IResult Register(ILoginService service, RegisterUserDto dto)
        {
            var register = service.RegisterUser(dto);

            return Results.Ok(register);
        }
    }
}
