using AutoMapper;
using GuildManager_DataAccess;
using GuildManager_Models;
using GuildManager_Models.RaidExpansionsAndLocations;
using GuildManagerAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GuildManagerAPI.Services
{
    public class RaidLocationService : IRaidLocationService
    {
        private readonly GuildManagerDbContext _dbContext;
        private readonly IMapper _mapper;

        public RaidLocationService(GuildManagerDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<List<RaidLocationDto>>> GetAll()
        {
            var raidLocations = await _dbContext.RaidLocations
                .Include(r=>r.Expansion)
                .ToListAsync();

            var dtos = _mapper.Map<List<RaidLocationDto>>(raidLocations);

            return new ServiceResponse<List<RaidLocationDto>>
            {
                Data = dtos,
                Success = true
            };
        }
    }
}
