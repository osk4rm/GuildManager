using GuildManager_Models;
using GuildManagerAPI.Services;
using GuildManagerAPI.Services.Interfaces;
using GuildManagerAPI.Validation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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

            app.MapPost("/api/change-password", LoginRequests.ChangePassword) 
                .Accepts<ChangePasswordDto>("application/json")
                .WithBodyValidator<ChangePasswordDto>();

            app.MapGet("/api/getuserinfo", LoginRequests.GetUserInfo)
                .RequireAuthorization();
            return app;
        }

        private static async Task<IResult> GetUserInfo(ILoginService service)
        {
            var result = await service.GetUserInfo();

            return Results.Ok(result);
        }

        private static IResult Login(ILoginService service, LoginDto dto)
        {
            var token = service.GenerateJwt(dto);
            
            return Results.Ok(token);
        }

        private static IResult Register(ILoginService service, RegisterUserDto dto)
        {
            var register = service.RegisterUser(dto);

            return Results.Ok(register);
        }

        private static async Task<IResult> ChangePassword(ILoginService service, ChangePasswordDto dto, ClaimsPrincipal user)
        {
            string userId = user.FindFirstValue(ClaimTypes.NameIdentifier);
            var response = await service.ChangePassword(int.Parse(userId), dto);

            return Results.Ok(response);
        }
    }
}
