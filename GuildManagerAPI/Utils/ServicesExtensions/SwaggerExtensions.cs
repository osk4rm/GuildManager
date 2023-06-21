﻿using Microsoft.OpenApi.Models;

namespace GuildManagerAPI.Utils.ServicesExtensions
{
    public static class SwaggerExtensions
    {
        public static void AddSwaggerServices(this WebApplicationBuilder builder)
        {
            var securityScheme = new OpenApiSecurityScheme()
            {
                Name = "Authorization",
                Description = "JWT Authorization header info using bearer tokens",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                BearerFormat = "JWT"
            };

            var securityRequirement = new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "bearerAuth"
                    }
                },
                new string[] { }
            }
        };

            builder.Services.AddSwaggerGen(opts =>
            {
                opts.AddSecurityDefinition("bearerAuth", securityScheme);
                opts.AddSecurityRequirement(securityRequirement);
            });
        }
    }
}
