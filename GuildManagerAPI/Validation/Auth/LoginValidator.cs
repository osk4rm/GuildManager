using FluentValidation;
using GuildManager_Models;

namespace GuildManagerAPI.Validation
{
    public class LoginValidator : AbstractValidator<LoginDto>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Email)
                .EmailAddress()
                .WithMessage("This field requires correct email format.")
                .NotEmpty()
                .WithMessage("Email cannot be empty.");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password cannot be empty.");

        }
    }
}
