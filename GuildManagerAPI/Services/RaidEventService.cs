using AutoMapper;
using GuildManager_DataAccess;
using GuildManager_Models;
using GuildManager_Models.RaidEvents;
using GuildManagerAPI.Authentication.UserContext;
using GuildManagerAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GuildManagerAPI.Services
{
    public class RaidEventService : IRaidEventService
    {
        private readonly GuildManagerDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IUserContextService _userContextService;

        public RaidEventService(GuildManagerDbContext dbContext, IMapper mapper, IUserContextService userContextService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _userContextService = userContextService;
        }
        public async Task<ServiceResponse<List<RaidEventDto>>> GetAll()
        {
            var raidEvents = await _dbContext.RaidEvents
                .Include(r => r.RaidLocation)
                .ToListAsync();

            var dtos = _mapper.Map<List<RaidEventDto>>(raidEvents);

            return new ServiceResponse<List<RaidEventDto>>
            {
                Data = dtos,
                Success = true
            };
        }

        public async Task<ServiceResponse<RaidEventDto>> GetById(int id)
        {
            var raidEvent = await _dbContext
                .RaidEvents
                .Include(r => r.RaidLocation)
                .FirstOrDefaultAsync();

            var dto = _mapper.Map<RaidEventDto>(raidEvent);

            return new ServiceResponse<RaidEventDto> { Data = dto };
        }

        public async Task<ServiceResponse<List<RaidEventDto>>> GetUserRaidEvents()
        {
            var userId = _userContextService.Id;
            if(userId == null)
            {
                throw new UnauthorizedAccessException();
            }

            var userEvents = await _dbContext
                .RaidEventCharacter
                .Where(e => e.Character.UserId == userId)
                .Select(r => r.RaidEvent)
                .ToListAsync();

            var dtos = _mapper.Map<List<RaidEventDto>>(userEvents);

            return new ServiceResponse<List<RaidEventDto>>
            {
                Data = dtos,
                Success = true
            };
        }
    }
}
