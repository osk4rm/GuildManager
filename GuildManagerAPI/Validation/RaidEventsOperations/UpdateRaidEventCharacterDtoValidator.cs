using FluentValidation;
using GuildManager_DataAccess;
using GuildManager_Models.RaidEvents;

namespace GuildManagerAPI.Validation.RaidEventsOperations
{
    public class UpdateRaidEventCharacterDtoValidator : AbstractValidator<UpdateRaidEventCharacterDto>
    {
        public UpdateRaidEventCharacterDtoValidator(GuildManagerDbContext dbContext)
        {
            RuleFor(x => x.CharacterId).NotEmpty();
            RuleFor(x=>x.RaidEventId)
                .NotEmpty().WithMessage("Raid event id cannot be empty");

            RuleFor(r => r.AcceptanceStatus)
                .NotNull().WithMessage("Acceptance status cannot be empty")
                .IsInEnum().WithMessage("Incorrect acceptance status");

            RuleFor(x => new { x.CharacterId, x.RaidEventId })
                .Custom((value, context) =>
                {
                    bool raidEventCharacterExists =
                         dbContext
                        .RaidEventCharacter
                        .Any(rec => rec.RaidEventId == value.RaidEventId && rec.CharacterId == value.CharacterId);

                    if (!raidEventCharacterExists)
                    {
                        context.AddFailure("Character not found for given event");
                    }
                });
        }
    }
}
