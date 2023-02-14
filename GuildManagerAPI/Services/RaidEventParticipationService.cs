using AutoMapper;
using GuildManager_DataAccess;
using GuildManager_DataAccess.Enum;
using GuildManager_Models;
using GuildManager_Models.RaidEventParticipantsOperations;
using GuildManager_Models.RaidEvents;
using GuildManagerAPI.Authentication.UserContext;
using GuildManagerAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Sieve.Models;
using Sieve.Services;

namespace GuildManagerAPI.Services
{
    public class RaidEventParticipationService : IRaidEventParticipationService
    {
        private readonly GuildManagerDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IUserContextService _userContextService;
        private readonly IAuthorizationService _authService;
        private readonly ISieveProcessor _sieveProcessor;

        public RaidEventParticipationService(GuildManagerDbContext dbContext, IMapper mapper, IUserContextService userContextService,
            IAuthorizationService authService, ISieveProcessor sieveProcessor)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _userContextService = userContextService;
            _authService = authService;
            _sieveProcessor = sieveProcessor;
        }
        public async Task<PagedServiceResponse<List<RaidInviteDto>>> GetUserRaidInvites(SieveModel sieveModel)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == _userContextService.Id);

            if (user == null)
            {
                throw new UnauthorizedAccessException("Unauthorized.");
            }

            var query = _dbContext
                .RaidEventCharacter
                .Include(r=>r.Character)
                .ThenInclude(c=>c.User)
                .Include(r=>r.RaidEvent)
                .ThenInclude(re=>re.RaidLocation)
                .Include(r => r.RaidEvent)
                .ThenInclude(re => re.CreatedBy)
                .Where(r => r.Character.UserId == _userContextService.Id && r.AcceptanceStatus == AcceptanceStatus.Invited)
                .AsQueryable();

            var result = await _sieveProcessor.Apply(sieveModel, query).ToListAsync();
            var total = await query.CountAsync();

            var dtos = _mapper.Map<List<RaidInviteDto>>(result);

            return new PagedServiceResponse<List<RaidInviteDto>>(dtos, total, sieveModel.PageSize.GetValueOrDefault(), sieveModel.Page.GetValueOrDefault());
        }
    }
}
