using AutoMapper;
using GuildManager_DataAccess;
using GuildManager_DataAccess.Entities;
using GuildManager_Models;
using GuildManager_Models.CharacterClassesAndSpecs;
using GuildManagerAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GuildManagerAPI.Services
{
    public class ClassesService : IClassesService
    {
        private readonly GuildManagerDbContext _dbContext;
        private readonly IMapper _mapper;

        public ClassesService(GuildManagerDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<List<CharacterClassDto>>> GetClasses()
        {
            var classes = await _dbContext.CharacterClasses
                .Include(c => c.ClassSpecializations)
                .ToListAsync();

            var dtos = _mapper.Map<List<CharacterClassDto>>(classes);

            return new ServiceResponse<List<CharacterClassDto>>
            {
                Data = dtos,
                Success = true,
                Message = "Success"
            };
        }
    }
}
