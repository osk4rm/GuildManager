using AutoMapper;
using GuildManager_DataAccess;
using GuildManager_DataAccess.Entities.Raids;
using GuildManager_Models;
using GuildManager_Models.RaidEvents;
using GuildManagerAPI.Authentication.UserContext;
using GuildManagerAPI.Authorization;
using GuildManagerAPI.Exceptions;
using GuildManagerAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace GuildManagerAPI.Services
{
    public class RaidEventService : IRaidEventService
    {
        private readonly GuildManagerDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IUserContextService _userContextService;
        private readonly IAuthorizationService _authService;

        public RaidEventService(GuildManagerDbContext dbContext, IMapper mapper, IUserContextService userContextService, IAuthorizationService authService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _userContextService = userContextService;
            _authService = authService;
        }

        public async Task<ServiceResponse<int>> CreateRaidEvent(UpsertRaidEventDto dto)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Id == _userContextService.Id);

            if (user == null)
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
                .ThenInclude(l=>l.Expansion)
                .Include(r=>r.CreatedBy)
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
                .Include(r=>r.CreatedBy)
                .FirstOrDefaultAsync(r=>r.Id == id);

            if(raidEvent == null)
            {
                throw new NotFoundException($"Raid {id} not found.");
            }

            var dto = _mapper.Map<RaidEventDto>(raidEvent);

            return new ServiceResponse<RaidEventDto> { Data = dto, Success = true };
        }

        public async Task<ServiceResponse<List<RaidEventDto>>> GetUserRaidEvents()
        {
            var userId = _userContextService.Id;
            if (userId == null)
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

            if (raidEvent == null)
            {
                throw new NotFoundException($"Raid event {id} not found.");
            }

            var authResult = await _authService.AuthorizeAsync(_userContextService.User, raidEvent, new ResourceOperationRequirement(ResourceOperationType.Update));

            if (!authResult.Succeeded)
            {
                throw new UnauthorizedAccessException("You are only allowed to update your own events.");
            }

            raidEvent.EndDate = dto.EndDate;
            raidEvent.StartDate= dto.StartDate;
            raidEvent.AutoAccept = dto.AutoAccept;
            raidEvent.RaidDifficulty = dto.RaidDifficulty;
            raidEvent.RaidLocationId = dto.RaidLocationId;
            raidEvent.Description = dto.Description;
            raidEvent.Status = dto.Status;

            _dbContext.Update(raidEvent);
            await _dbContext.SaveChangesAsync();

            var responseDto = _mapper.Map<RaidEventDto>(raidEvent);

            return new ServiceResponse<RaidEventDto> { Data = responseDto, Success = true, Message = "Raid event updated." };
        }

        public async Task<ServiceResponse<bool>> DeleteRaidEvent(int id)
        {
            var raidEvent = await _dbContext.RaidEvents
                .FirstOrDefaultAsync(r => r.Id == id);

            if(raidEvent == null)
            {
                throw new NotFoundException("Raid event not found.");
            }

            var authResult = await _authService.AuthorizeAsync(_userContextService.User, raidEvent, new ResourceOperationRequirement(ResourceOperationType.Delete));

            if (!authResult.Succeeded)
            {
                throw new UnauthorizedAccessException("You are only allowed to delete your own events.");
            }

            _dbContext.RaidEvents.Remove(raidEvent);
            await _dbContext.SaveChangesAsync();

            return new ServiceResponse<bool>
            {
                Data = true,
                Success = true,
                Message = $"Raid event {raidEvent.Id} deleted."
            };
        }
    }
}
