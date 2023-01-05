using FluentValidation;
using GuildManager_Models;

namespace GuildManagerAPI.Validation
{
    public static class ValidationExtension
    {
        public static RouteHandlerBuilder WithBodyValidator<T>(this RouteHandlerBuilder builder)
        where T : class
        {
            builder.Add(endpointBuilder =>
            {
                var orginalDelegate = endpointBuilder.RequestDelegate;
                endpointBuilder.RequestDelegate = async httpContext =>
                {
                    var validator = httpContext.RequestServices.GetRequiredService<IValidator<T>>();

                    httpContext.Request.EnableBuffering();
                    var body = await httpContext.Request.ReadFromJsonAsync<T>();

                    if (body == null)
                    {
                        httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                        await httpContext.Response.WriteAsync("Couldn't map body to request model");
                        return;
                    }

                    var validationResult = validator.Validate(body);
                    if (!validationResult.IsValid)
                    {
                        ServiceResponse<T> serviceResponse = new()
                        {
                            Success = false,
                            Message = String.Join(",", 
                            validationResult.Errors.Select(e=>e.ErrorMessage).ToList()),
                            Data = null
                        };
                        
                        httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                        //await httpContext.Response.WriteAsJsonAsync(validationResult.Errors);
                        await httpContext.Response.WriteAsJsonAsync(serviceResponse);
                        return;
                    }

                    httpContext.Request.Body.Position = 0;

                    await orginalDelegate(httpContext);
                };
            });

            return builder;
        }
    }
}
