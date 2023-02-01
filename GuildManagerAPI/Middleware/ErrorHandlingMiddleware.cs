using GuildManager_Models;
using GuildManagerAPI.Exceptions;
using Microsoft.AspNetCore.Http;

namespace GuildManagerAPI.Middleware
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (AlreadyJoinedException alreadyJoinedException)
            {
                ServiceResponse<string> response = new ServiceResponse<string>()
                {
                    Success = false,
                    Message = alreadyJoinedException.Message
                };

                context.Response.StatusCode = 400;
                await context.Response.WriteAsJsonAsync(response);
            }
            catch (UnauthorizedAccessException unauthorizedAccessException)
            {
                ServiceResponse<string> response = new ServiceResponse<string>()
                {
                    Success = false,
                    Message = unauthorizedAccessException.Message
                };

                context.Response.StatusCode = 401;
                await context.Response.WriteAsJsonAsync(response);
            }
            catch (BadRequestException badRequestException)
            {
                ServiceResponse<string> response = new ServiceResponse<string>()
                {
                    Success = false,
                    Message = badRequestException.Message
                };
                context.Response.StatusCode = 400;
                await context.Response.WriteAsJsonAsync(response);
            }
            catch(NotFoundException notFoundException)
            {
                ServiceResponse<string> response = new ServiceResponse<string>()
                {
                    Success = false,
                    Message = notFoundException.Message
                };
                context.Response.StatusCode = 404;
                await context.Response.WriteAsJsonAsync(response);
            }
        }
    }
}
