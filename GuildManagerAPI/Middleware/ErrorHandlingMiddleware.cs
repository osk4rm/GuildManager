﻿using GuildManager_Models;
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
        }
    }
}
