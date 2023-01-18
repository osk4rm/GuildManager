using FluentValidation;
using GuildManager_DataAccess;
using GuildManager_Models.Characters;

namespace GuildManagerAPI.Validation.CharactersOperations
{
    public class UpdateCharacterDtoValidator : AbstractValidator<UpdateCharacterDto>
    {
        public UpdateCharacterDtoValidator(GuildManagerDbContext dbContext)
        {
            //add rules
        }
    }
}
