using FluentValidation;
using GuildManager_DataAccess;
using GuildManager_Models.Characters;

namespace GuildManagerAPI.Validation.CharactersOperations
{
    public class CreateCharacterDtoValidator : AbstractValidator<CreateCharacterDto>
    {
        public CreateCharacterDtoValidator(GuildManagerDbContext dbContext)
        {
            RuleFor(x=>x.Name)
                .Custom((value, context) =>
                {
                    var nameInUse = dbContext.Characters.Any(u => u.Name == value);
                    if (nameInUse)
                    {
                        context.AddFailure("Name", "Character with this name already exists.");
                    }
                })
                .NotEmpty().WithMessage("Character name cannot be empty");
        }
    }
}
