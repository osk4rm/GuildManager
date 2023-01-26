using AutoMapper;
using GuildManager_DataAccess;
using GuildManager_DataAccess.Entities.Raids;
using GuildManager_Models;
using GuildManager_Models.RaidEvents;
using GuildManagerAPI.Authentication.UserContext;
using GuildManagerAPI.Exceptions;
using GuildManagerAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.Xml;

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

        public async Task<ServiceResponse<int>> CreateRaidEvent(UpsertRaidEventDto dto)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Id == _userContextService.Id);

            if(user == null)
            {
                throw new UnauthorizedAccessException("Unauthorized.");
            }

            var raidEvent = _mapper.Map<RaidEvent>(dto);
            raidEvent.CreatedBy = user;

            await _dbContext.RaidEvents.AddAsync(raidEvent);
            await _dbContext.SaveChangesAsync();

            return new ServiceResponse<int>
            {
                Data = raidEvent.Id,
                Success = true,
                Message = "Raid event created."
            };
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

            return new ServiceResponse<RaidEventDto> { Data = dto, Success = true };
        }

        public async Task<ServiceResponse<List<RaidEventDto>>> GetUserRaidEvents()
        {
            var userId = _userContextService.Id;
            if(userId == null)
            {
                throw new UnauthorizedAccessException("Unauthorized.");
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

        public async Task<ServiceResponse<RaidEventDto>> UpdateRaidEvent(UpsertRaidEventDto dto, int id)
        {
            var raidEvent = await _dbContext
                .RaidEvents
                .FirstOrDefaultAsync(r => r.Id == id);

            if(raidEvent == null)
            {
                throw new NotFoundException($"Raid event {id} not found.");
            }

            raidEvent = _mapper.Map<RaidEvent>(dto);
            _dbContext.Update(raidEvent);
            await _dbContext.SaveChangesAsync();

            var responseDto = _mapper.Map<RaidEventDto>(raidEvent);

            return new ServiceResponse<RaidEventDto> { Data = responseDto, Success = true, Message = "Raid event updated." };
        }
}
