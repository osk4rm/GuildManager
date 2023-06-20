
using GuildManager_DataAccess.Entities;
using GuildManager_DataAccess;
using GuildManagerAPI.Authentication.UserContext;
using GuildManagerAPI.Services;
using GuildManagerAPI.Services.Interfaces;
using GuildManagerAPI.Sieve;
using Microsoft.AspNetCore.Identity;
using Sieve.Services;
using System.Reflection;

namespace GuildManagerAPI.Utils.ServicesExtensions
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ISieveProcessor, ApplicationSieveProcessor>();
            services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<ICharacterService, CharacterService>();
            services.AddScoped<IClassesService, ClassesService>();
            services.AddScoped<IUserContextService, UserContextService>();
            services.AddScoped<IMembersService, MembersService>();
            services.AddScoped<IRaidExpansionsService, RaidExpansionsService>();
            services.AddScoped<IRaidLocationService, RaidLocationService>();
            services.AddScoped<IRaidEventService, RaidEventService>();
            services.AddScoped<IRaidEventParticipationService, RaidEventParticipationService>();
            services.AddScoped<IStatisticsService, StatisticsService>();
            services.AddScoped<Seeder>();

            return services;
        }
    }
}
