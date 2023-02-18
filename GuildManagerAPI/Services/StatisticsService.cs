using AutoMapper;
using GuildManager_DataAccess;
using GuildManager_Models;
using GuildManagerAPI.Authentication.UserContext;
using GuildManagerAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GuildManagerAPI.Services
{
    public class StatisticsService : IStatisticsService
    {
        private readonly GuildManagerDbContext _dbContext;
        private readonly IUserContextService _userContextService;

        public StatisticsService(GuildManagerDbContext dbContext, IUserContextService userContextService)
        {
            _dbContext = dbContext;
            _userContextService = userContextService;
        }
        public async Task<ServiceResponse<int>> GetGuildMembersCount()
        {
            int membersCount = _dbContext.Users.Count();

            return new ServiceResponse<int> { Data = membersCount, Success = true };
        }

        public Task<ServiceResponse<int>> GetPendingInvitesCount()
        {
            var userId = _userContextService.Id;
            var user = _dbContext.Users
                .Include(u => u.Characters)
                .FirstOrDefault(u => u.Id == userId);

            if (user == null)
            {
                throw new UnauthorizedAccessException("Unauthorized");
            }

            // Get list of character ids for the user
            var characterIds = user.Characters.Select(c => c.Id).ToList();

            // Count the number of records in the RaidEventCharacter table where the CharacterId is in the list of character ids for the user
            var pendingInvitesCount = _dbContext.RaidEventCharacter
                .Where(rec=>rec.AcceptanceStatus == GuildManager_DataAccess.Enum.AcceptanceStatus.Invited)
                .Count(rec => characterIds.Contains(rec.CharacterId));

            return Task.FromResult(new ServiceResponse<int>
            {
                Data = pendingInvitesCount,
                Success = true
            });
        }

        public Task<ServiceResponse<int>> GetRaidsThisWeekCount()
        {
            var now = DateTime.Now;
            var daysUntilWednesday = ((int)DayOfWeek.Wednesday - (int)now.DayOfWeek + 7) % 7;
            var startOfWeek = now.AddDays(daysUntilWednesday-7).Date;
            var endOfWeek = startOfWeek.AddDays(7).Date;

            // Count the number of RaidEvents that start within the current week
            var raidsThisWeekCount = _dbContext.RaidEvents
                .Where(re => re.StartDate >= startOfWeek && re.StartDate < endOfWeek && re.StartDate > now)
                .Count();

            return Task.FromResult(new ServiceResponse<int>
            {
                Data = raidsThisWeekCount,
                Success = true
            });

        }
    }
}
