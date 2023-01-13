using AutoMapper;
using GuildManager_DataAccess;
using GuildManager_DataAccess.Entities;
using GuildManager_Models;
using GuildManager_Models.Characters;
using GuildManagerAPI.Services.Interfaces;

namespace GuildManagerAPI.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly GuildManagerDbContext _dbContext;
        private readonly IMapper _mapper;

        public CharacterService(GuildManagerDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<int>> CreateCharacter(int userId, CharacterDto characterDto)
        {
            var character = _mapper.Map<Character>(characterDto);

            await _dbContext.Characters.AddAsync(character);
            await _dbContext.SaveChangesAsync();

            return new ServiceResponse<int>
            {
                Data = character.Id,
                Success = true,
                Message = $"Character {character.Name} created!"
            };
        }

        public Task<ServiceResponse<List<CharacterDto>>> GetUserCharacters(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
