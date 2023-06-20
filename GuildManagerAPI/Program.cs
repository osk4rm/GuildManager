using FluentValidation;
using GuildManager_DataAccess;
using GuildManager_DataAccess.Entities;
using GuildManagerAPI.Authentication;
using GuildManagerAPI.Authentication.UserContext;
using GuildManagerAPI.Authorization;
using GuildManagerAPI.Middleware;
using GuildManagerAPI.Requests;
using GuildManagerAPI.Requests.Extension;
using GuildManagerAPI.Services;
using GuildManagerAPI.Services.Interfaces;
using GuildManagerAPI.Sieve;
using GuildManagerAPI.Utils.ServicesExtensions;
using GuildManagerAPI.Validation;
using GuildManagerAPI.Validation.CharactersOperations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Sieve.Services;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

var authenticationSettings = new AuthenticationSettings();
builder.Configuration.GetSection("Authentication").Bind(authenticationSettings);
builder.Services.AddSingleton(authenticationSettings);
builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = "Bearer";
    option.DefaultScheme = "Bearer";
    option.DefaultChallengeScheme = "Bearer";
}).AddJwtBearer(cfg =>
{
    cfg.RequireHttpsMetadata = false;
    cfg.SaveToken = true;
    cfg.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = authenticationSettings.JwtIssuer,
        ValidAudience = authenticationSettings.JwtIssuer,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationSettings.JwtKey))
    };
});
builder.Services.AddAuthorization();
builder.Services.AddScoped<IAuthorizationHandler, ResourceOperationRequirementHandler>();
builder.Services.AddScoped<IAuthorizationHandler, CommentOperationRequirementHandler>();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
{
    Name = "Authorization",
    Type = SecuritySchemeType.ApiKey,
    Scheme = "Bearer",
    BearerFormat = "JWT",
    In = ParameterLocation.Header,
    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
}));
builder.Services.AddDbContext<GuildManagerDbContext>(
    option =>
    {
        option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString"));

    });
builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

builder.Services.AddApplicationServices();

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ErrorHandlingMiddleware>();
builder.Services.RegisterValidators();
builder.Services.AddCors(options =>
{
    options.AddPolicy("FrontEndClient", corsBuilder =>

        corsBuilder.AllowAnyMethod()
            .AllowAnyHeader()
            .WithOrigins(builder.Configuration["AllowedOrigins"])
        );
});

var app = builder.Build();

var scope = app.Services.CreateScope();
Seeder seeder = scope.ServiceProvider.GetRequiredService<Seeder>();
seeder.Seed();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();
app.RegisterEndpoints();
app.UseCors("FrontEndClient");



app.Run();

public partial class Program { }