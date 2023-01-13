using AutoMapper;
using GuildManager_DataAccess;
using GuildManager_DataAccess.Entities;
using GuildManager_Models;
using GuildManager_Models.Characters;
using GuildManagerAPI.Exceptions;
using GuildManagerAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

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
        public async Task<ServiceResponse<int>> CreateCharacter(int userId, CreateCharacterDto characterDto)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Id == userId);
            if (user == null)
            {
                throw new NotFoundException("User not found.");
            }
            var character = _mapper.Map<Character>(characterDto);
            character.User = user;
            await _dbContext.Characters.AddAsync(character);
            await _dbContext.SaveChangesAsync();

            return new ServiceResponse<int>
            {
                Data = character.Id,
                Success = true,
                Message = $"Character {character.Name} created!"
            };
        }

        public async Task<ServiceResponse<List<CharacterDto>>> GetUserCharacters(int userId)
        {
            var characters = await _dbContext.Characters
                .Where(u=>u.UserId == userId)
                .ToListAsync();

            var charDtos = _mapper.Map<List<CharacterDto>>(characters);

            return new ServiceResponse<List<CharacterDto>>
            {
                Data = charDtos,
                Success = true
            };
        }
    }
}
