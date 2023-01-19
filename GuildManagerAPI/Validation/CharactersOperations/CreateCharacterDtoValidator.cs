using FluentValidation;
using GuildManager_DataAccess;
using GuildManager_Models.Characters;

namespace GuildManagerAPI.Validation.CharactersOperations
{
    public class CreateCharacterDtoValidator : AbstractValidator<CreateCharacterDto>
    {
        public CreateCharacterDtoValidator(GuildManagerDbContext dbContext)
        {
            RuleFor(x => x.Name)
                .Custom((value, context) =>
                {
                    var nameInUse = dbContext.Characters.Any(u => u.Name == value);
                    if (nameInUse)
                    {
                        context.AddFailure("Name", "Character with this name already exists.");
                    }
                })
                .NotEmpty().WithMessage("Character name cannot be empty")
                .NotNull().WithMessage("Character name cannot be empty");

            RuleFor(x => x.ClassId)
                .NotNull().WithMessage("Class cannot be empty")
                .Custom((value, context) =>
                {
                    var classExists = dbContext.CharacterClasses.Any(c => c.Id == value);
                    if (!classExists)
                    {
                        context.AddFailure($"Class with id {value} does not exist in database.");
                        
                    }
                });

            RuleFor(x => new { x.ClassId, x.ClassSpecializationId })
                .Custom((value, context) =>
                {
                    var givenSpec = dbContext.ClassSpecializations.FirstOrDefault(s => s.Id == value.ClassSpecializationId);
                    if(givenSpec is null)
                    {
                        context.AddFailure($"Class specialization with id {value.ClassSpecializationId} does not exist in database.");
                    }
                    else if (givenSpec.CharacterClassId != value.ClassId)
                    {
                        context.AddFailure($"Class specialization is not the specialization of class with id {value.ClassId}");
                    }
                });
                



        }
    }
}
