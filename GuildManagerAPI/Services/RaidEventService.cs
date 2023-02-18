using AutoMapper;
using GuildManager_DataAccess;
using GuildManager_DataAccess.Entities.Raids;
using GuildManager_Models;
using GuildManager_Models.Characters;
using GuildManager_Models.RaidEvents;
using GuildManagerAPI.Authentication.UserContext;
using GuildManagerAPI.Authorization;
using GuildManagerAPI.Exceptions;
using GuildManagerAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Sieve.Models;
using Sieve.Services;

namespace GuildManagerAPI.Services
{
    public class RaidEventService : IRaidEventService
    {
        private readonly GuildManagerDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IUserContextService _userContextService;
        private readonly IAuthorizationService _authService;
        private readonly ISieveProcessor _sieveProcessor;

        public RaidEventService(GuildManagerDbContext dbContext, IMapper mapper, IUserContextService userContextService, 
            IAuthorizationService authService, ISieveProcessor sieveProcessor)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _userContextService = userContextService;
            _authService = authService;
            _sieveProcessor = sieveProcessor;
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
                .ThenInclude(l => l.Expansion)
                .Include(r => r.CreatedBy)
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
                .Include(r => r.CreatedBy)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (raidEvent == null)
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
            raidEvent.StartDate = dto.StartDate;
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

            if (raidEvent == null)
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

        public async Task<ServiceResponse<bool>> JoinRaidEvent(int eventId, int characterId)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == _userContextService.Id);

            if (user == null)
            {
                throw new UnauthorizedAccessException("Unauthorized.");
            }

            var raidEvent = await _dbContext.RaidEvents.FirstOrDefaultAsync(r => r.Id == eventId);
            var character = await _dbContext.Characters.FirstOrDefaultAsync(u => u.Id == characterId);
            if (character == null || raidEvent == null)
            {
                throw new NotFoundException("Character or raid event not found.");
            }

            var raidEventCharacter = await _dbContext
                .RaidEventCharacter
                .FirstOrDefaultAsync(rec => rec.CharacterId == characterId && rec.RaidEventId == eventId);

            if(raidEventCharacter != null)
            {
                throw new AlreadyJoinedException(raidEventCharacter.AcceptanceStatus);
                
            }

            raidEventCharacter = new()
            {
                RaidEventId = eventId,
                CharacterId = characterId,
                AcceptanceStatus = raidEvent.AutoAccept ? GuildManager_DataAccess.Enum.AcceptanceStatus.Accepted : GuildManager_DataAccess.Enum.AcceptanceStatus.Waiting
            };

            _dbContext.RaidEventCharacter.Add(raidEventCharacter);
            await _dbContext.SaveChangesAsync();
            

            return new ServiceResponse<bool>
            {
                Data = true,
                Success = true,
                Message = "Your request has been sent."
            };
        }

        public async Task<ServiceResponse<List<RaidEventCharacterDto>>> GetParticipants(int eventId)
        {
            var raidEvent = await _dbContext.RaidEvents
                .FirstOrDefaultAsync(r => r.Id == eventId);

            if(raidEvent == null)
            {
                throw new NotFoundException($"Raid event {eventId} not found.");
            }
            var participants = await _dbContext
                .RaidEventCharacter
                .Include(rec => rec.Character)
                .ThenInclude(c => c.Class)
                .Include(rec => rec.Character)
                .ThenInclude(c => c.MainSpec)
                .Where(rec => rec.RaidEventId == eventId)
                .ToListAsync();

            var participantsDto = _mapper.Map<List<RaidEventCharacterDto>>(participants);

            return new ServiceResponse<List<RaidEventCharacterDto>>
            {
                Data = participantsDto,
                Success = true
            };
        }

        public async Task<ServiceResponse<RaidEventCharacterDto>> UpdateCharacterStatusForEvent(UpdateRaidEventCharacterDto dto)
        {
            var raidEventCharacter = await _dbContext
                .RaidEventCharacter
                .FirstOrDefaultAsync(rec => rec.CharacterId == dto.CharacterId && rec.RaidEventId == dto.RaidEventId);

            if(raidEventCharacter == null)
            {
                throw new NotFoundException($"Character not found for given event.");
            }

            raidEventCharacter.AcceptanceStatus = dto.AcceptanceStatus;
            _dbContext.Update(raidEventCharacter);
            await _dbContext.SaveChangesAsync();

            var responseDto = _mapper.Map<RaidEventCharacterDto>(raidEventCharacter);

            return new ServiceResponse<RaidEventCharacterDto>
            {
                Data = responseDto,
                Success = true,
                Message = "Status changed."
            };
        }

        public async Task<ServiceResponse<List<CommentDto>>> GetCommentsForRaidEvent(int eventId)
        {
            var raidEvent = await _dbContext
                .RaidEvents
                .FirstOrDefaultAsync(r => r.Id == eventId);

            if(raidEvent is null)
            {
                throw new NotFoundException($"Raid event {eventId} not found.");
            }

            var comments = await _dbContext
                .Comments
                .Include(c => c.Author)
                .Where(c=>c.RaidEventId == eventId)
                .ToListAsync();

            var dtos = _mapper.Map<List<CommentDto>>(comments);

            return new ServiceResponse<List<CommentDto>>
            {
                Data = dtos,
                Success = true
            };
        }

        public async Task<ServiceResponse<int>> CreateCommentForRaidEvent(int eventId, string message)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == _userContextService.Id);

            if (user == null)
            {
                throw new UnauthorizedAccessException("Unauthorized.");
            }

            var raidEvent = await _dbContext
                .RaidEvents
                .FirstOrDefaultAsync(r => r.Id == eventId);

            if (raidEvent == null)
            {
                throw new NotFoundException($"Raid event {eventId} not found.");
            }

            var comment = new Comment
            {
                RaidEvent = raidEvent,
                Author = user,
                Message = message
            };

            await _dbContext.Comments.AddAsync(comment);
            await _dbContext.SaveChangesAsync();

            return new ServiceResponse<int>
            {
                Data = comment.Id,
                Success = true,
                Message = "Comment has been posted."
            };
        }

        public async Task<ServiceResponse<CommentDto>> UpdateCommentForRaidEvent(int commentId, string message)
        {
            var comment = await _dbContext
                .Comments
                .FirstOrDefaultAsync(r => r.Id == commentId);

            if (comment == null)
            {
                throw new NotFoundException($"Comment not found.");
            }

            var authResult = await _authService.AuthorizeAsync(_userContextService.User, comment, new ResourceOperationRequirement(ResourceOperationType.Update));

            if (!authResult.Succeeded)
            {
                throw new UnauthorizedAccessException("You are only allowed to update your own comments.");
            }

            comment.Message = message;
            comment.ModifiedDate = DateTime.UtcNow;
            

            _dbContext.Update(comment);
            await _dbContext.SaveChangesAsync();

            var responseDto = _mapper.Map<CommentDto>(comment);

            return new ServiceResponse<CommentDto> { Data = responseDto, Success = true, Message = "Comment updated." };
        }
    

        public async Task<ServiceResponse<bool>> DeleteCommentForRaidEvent(int commentId)
        {
            var comment = await _dbContext.Comments
                .FirstOrDefaultAsync(r => r.Id == commentId);

            if (comment == null)
            {
                throw new NotFoundException("Comment not found.");
            }

            var authResult = await _authService.AuthorizeAsync(_userContextService.User, comment, new ResourceOperationRequirement(ResourceOperationType.Delete));

            if (!authResult.Succeeded)
            {
                throw new UnauthorizedAccessException("You are only allowed to delete your own comments.");
            }

            _dbContext.Comments.Remove(comment);
            await _dbContext.SaveChangesAsync();

            return new ServiceResponse<bool>
            {
                Data = true,
                Success = true,
                Message = $"Raid event {comment.Id} deleted."
            };
        }

        public async Task<ServiceResponse<bool>> CancelApplicationForRaidEvent(int eventId, int characterId)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == _userContextService.Id);

            if (user == null)
            {
                throw new UnauthorizedAccessException("Unauthorized.");
            }

            var raidEvent = await _dbContext.RaidEvents.FirstOrDefaultAsync(r => r.Id == eventId);
            var character = await _dbContext.Characters.FirstOrDefaultAsync(u => u.Id == characterId);
            if (character == null || raidEvent == null)
            {
                throw new NotFoundException("Character or raid event not found.");
            }

            var raidEventCharacter = await _dbContext
                .RaidEventCharacter
                .FirstOrDefaultAsync(rec => rec.CharacterId == characterId && rec.RaidEventId == eventId);

            if (raidEventCharacter == null)
            {
                throw new NotFoundException("You have not applied for this event.");
            }

            _dbContext.RaidEventCharacter.Remove(raidEventCharacter);
            await _dbContext.SaveChangesAsync();

            return new ServiceResponse<bool>
            {
                Success = true,
                Data = true,
                Message = "Application removed."
            };
        }

        public async Task<PagedServiceResponse<List<RaidEventDto>>> GetPagedRaidEvents(SieveModel sieveModel)
        {
            var query = _dbContext.RaidEvents
                .Include(r => r.RaidLocation)
                .ThenInclude(l=>l.Expansion)
                .Include(r=>r.CreatedBy)
                .AsQueryable();

            var result = await _sieveProcessor.Apply(sieveModel, query).ToListAsync();
            var total = await _sieveProcessor.Apply(sieveModel, query, applyPagination: false, applySorting: false)
                .CountAsync();
            var dtos = _mapper.Map<List<RaidEventDto>>(result);

            return new PagedServiceResponse<List<RaidEventDto>>(dtos, total, sieveModel.PageSize.GetValueOrDefault(), sieveModel.Page.GetValueOrDefault());
        }

        public async Task<ServiceResponse<bool>> InviteForRaidEvent(int eventId, int characterId)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == _userContextService.Id);

            if (user == null)
            {
                throw new UnauthorizedAccessException("Unauthorized.");
            }

            var raidEvent = await _dbContext.RaidEvents.FirstOrDefaultAsync(r => r.Id == eventId);
            var character = await _dbContext.Characters.FirstOrDefaultAsync(u => u.Id == characterId);
            if (character == null || raidEvent == null)
            {
                throw new NotFoundException("Character or raid event not found.");
            }

            //todo: maybe requirementhandler would be a better idea, but this is shorter
            if(user != raidEvent.CreatedBy)
            {
                throw new UnauthorizedAccessException($"You are only allowed to invite people for your own raid events.");
            }

            var raidEventCharacter = await _dbContext
                .RaidEventCharacter
                .FirstOrDefaultAsync(rec => rec.CharacterId == characterId && rec.RaidEventId == eventId);

            if (raidEventCharacter != null)
            {
                throw new AlreadyJoinedException(raidEventCharacter.AcceptanceStatus);

            }

            raidEventCharacter = new()
            {
                RaidEventId = eventId,
                CharacterId = characterId,
                AcceptanceStatus = GuildManager_DataAccess.Enum.AcceptanceStatus.Invited
            };

            _dbContext.RaidEventCharacter.Add(raidEventCharacter);
            await _dbContext.SaveChangesAsync();


            return new ServiceResponse<bool>
            {
                Data = true,
                Success = true,
                Message = $"Character {character.Name} has been invited."
            };
        }

        public async Task<ServiceResponse<RaidEventDto>> GetUserNextEvent()
        {
            var user = await _dbContext.Users
                .Include(u=>u.Characters)
                .FirstOrDefaultAsync(u => u.Id == _userContextService.Id);

            if (user == null)
            {
                throw new UnauthorizedAccessException("Unauthorized.");
            }
            var characterIds = user.Characters.Select(c => c.Id).ToList();

            var nextRaidEvent = await _dbContext.RaidEventCharacter
                .Include(rec => rec.RaidEvent)
                .ThenInclude(r=>r.RaidLocation)
                .Where(rec => rec.AcceptanceStatus == GuildManager_DataAccess.Enum.AcceptanceStatus.Accepted)
                .Where(rec => characterIds.Contains(rec.CharacterId))
                .Select(rec => rec.RaidEvent)
                .AsNoTracking()
                .OrderBy(r=>r.StartDate)
                .FirstOrDefaultAsync(r=>r.StartDate > DateTime.Now);

            if(nextRaidEvent == null)
            {
                return new ServiceResponse<RaidEventDto>
                {
                    Data = null,
                    Success = true,
                    Message = "You have not been accepted for any raid events :("
                };
            }

            var dto = _mapper.Map<RaidEventDto>(nextRaidEvent);

            return new ServiceResponse<RaidEventDto> { Data = dto, Success = true };
        }
    }
}
