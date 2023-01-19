using FluentValidation;
using GuildManager_DataAccess;
using GuildManager_Models.Characters;

namespace GuildManagerAPI.Validation.CharactersOperations
{
    public class UpdateCharacterDtoValidator : AbstractValidator<UpdateCharacterDto>
    {
        public UpdateCharacterDtoValidator(GuildManagerDbContext dbContext)
        {
            RuleFor(x => x.Id)
                .Custom((value, context) =>
                {
                    var character = dbContext.Characters.FirstOrDefault(c => c.Id == value);
                    if (character == null)
                    {
                        context.AddFailure($"Character with ID {value} does not exist");
                    }
                });


            When(x => x.ItemLevel != null, () =>
            {
                RuleFor(x => x.ItemLevel)
                .GreaterThan(0).WithMessage("Come on...you can't be below 0 item level.");
            });

            When(x => x.MainSpecId != null, () =>
            {
                RuleFor(x => new { x.MainSpecId, x.Id })
                .Custom((value, context) =>
                {
                    var characterToUpdate = dbContext.Characters.FirstOrDefault(c => c.Id == value.Id);
                    var givenSpec = dbContext.ClassSpecializations
                    .FirstOrDefault(s => s.Id == value.MainSpecId);
                    if (characterToUpdate == null)
                    {
                        return;
                    }
                    else if (givenSpec is null)
                    {
                        context.AddFailure($"Class specialization with id {value.MainSpecId} does not exist in database.");
                    }
                    else if (givenSpec.CharacterClassId != characterToUpdate.ClassId)
                    {
                        context.AddFailure($"You can only change spec to one of your current class' specs.");
                    }
                });
            });  
            
                
        }
    }
}
