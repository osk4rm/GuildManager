using FluentValidation;
using GuildManager_DataAccess;
using GuildManager_DataAccess.Enum;
using GuildManager_Models.RaidEvents;
using Microsoft.EntityFrameworkCore;

namespace GuildManagerAPI.Validation.RaidEventsOperations
{
    public class UpsertRaidEventDtoValidator : AbstractValidator<UpsertRaidEventDto>
    {
        public UpsertRaidEventDtoValidator(GuildManagerDbContext dbContext)
        {
            RuleFor(r=>r.RaidLocationId)
                .NotNull().WithMessage("Raid location cannot be empty")
                .Custom((value, context) =>
                {
                    var locationExists = dbContext.RaidLocations.Any(c => c.Id == value);
                    if (!locationExists)
                    {
                        context.AddFailure($"Raid location with id {value} does not exist in database.");

                    }
                });

            RuleFor(r => r.EndDate)
                .GreaterThan(r => r.StartDate).WithMessage("End date must be later than start date.");

            RuleFor(r => r.RaidDifficulty)
                .NotNull().WithMessage("Raid difficulty cannot be empty")
                .IsInEnum().WithMessage("Incorrect raid difficulty");
        }
    }
}
