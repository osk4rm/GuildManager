using AutoMapper;
using GuildManager_DataAccess;
using GuildManager_Models;
using GuildManager_Models.RaidExpansionsAndLocations;
using GuildManagerAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GuildManagerAPI.Services
{
    public class RaidExpansionsService : IRaidExpansionsService
    {
        private readonly GuildManagerDbContext _dbContext;
        private readonly IMapper _mapper;

        public RaidExpansionsService(GuildManagerDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<List<RaidExpansionDto>>> GetAll()
        {
            var expansions = await _dbContext.RaidExpansions
                .Include(e => e.RaidLocations)
                .ToListAsync();

            var dtos = _mapper.Map<List<RaidExpansionDto>>(expansions);

            return new ServiceResponse<List<RaidExpansionDto>>
            {
                Data = dtos,
                Success = true
            };
        }
    }
}
