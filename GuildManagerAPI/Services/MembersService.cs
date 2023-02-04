using AutoMapper;
using GuildManager_DataAccess;
using GuildManager_Models;
using GuildManager_Models.Members;
using GuildManager_Models.RaidEvents;
using GuildManagerAPI.Authentication.UserContext;
using GuildManagerAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GuildManagerAPI.Services
{
    public class MembersService : IMembersService
    {
        private readonly GuildManagerDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IUserContextService _userContextService;

        public MembersService(GuildManagerDbContext dbContext, IMapper mapper,
            IUserContextService userContextService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _userContextService = userContextService;
        }

        public async Task<ServiceResponse<List<MemberDto>>> GetMembers()
        {
            var users = await _dbContext
                .Users
                .Include(u => u.Characters).ThenInclude(c=>c.Class)
                .Include(u => u.Characters).ThenInclude(c=>c.MainSpec)
                .Include(u=>u.Role)
                .ToListAsync();

            var members = _mapper.Map<List<MemberDto>>(users);
            foreach(var member in members)
            {
                member.RaidEvents = await GetMemberRaidEvents(member.Id);
            }

            return new ServiceResponse<List<MemberDto>>
            {
                Data = members,
                Success= true,
                Message = "Success."
            };
        }

        private async Task<List<RaidEventDto>> GetMemberRaidEvents(int id)
        {
            var memberRaidEvents = await _dbContext
                .RaidEvents
                .Include(r => r.Participants)
                .Include(r=>r.RaidLocation)
                .Where(r => r.Participants.Any(p => p.UserId == id))
                .ToListAsync();

            var mappedResult = _mapper.Map<List<RaidEventDto>>(memberRaidEvents);

            return mappedResult;
        }
    }
}
