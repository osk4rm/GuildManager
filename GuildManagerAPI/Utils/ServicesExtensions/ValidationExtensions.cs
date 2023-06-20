using GuildManagerAPI.Validation.CharactersOperations;
using GuildManagerAPI.Validation;
using FluentValidation;

namespace GuildManagerAPI.Utils.ServicesExtensions
{
    public static class ValidationExtensions
    {
        public static IServiceCollection RegisterValidators(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining(typeof(LoginValidator));
            services.AddValidatorsFromAssemblyContaining(typeof(RegisterUserValidator));
            services.AddValidatorsFromAssemblyContaining(typeof(CreateCharacterDtoValidator));
            services.AddValidatorsFromAssemblyContaining(typeof(UpdateCharacterDtoValidator));

            return services;
        }
    }
}
