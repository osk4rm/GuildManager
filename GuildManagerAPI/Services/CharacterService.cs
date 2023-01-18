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
            var charClass = _dbContext.CharacterClasses.FirstOrDefault(c => c.Id == characterDto.ClassId);
            var classSpec = _dbContext.ClassSpecializations.FirstOrDefault(s => s.Id == characterDto.ClassSpecializationId);
            if (user == null)
            {
                throw new NotFoundException("User not found.");
            }
            if (charClass == null)
            {
                throw new NotFoundException("Class not found.");
            }
            if (classSpec == null)
            {
                throw new NotFoundException("Class specialization not found.");
            }
            var character = _mapper.Map<Character>(characterDto);
            character.User = user;
            character.Class = charClass;
            character.MainSpec = classSpec;
            await _dbContext.Characters.AddAsync(character);
            await _dbContext.SaveChangesAsync();

            return new ServiceResponse<int>
            {
                Data = character.Id,
                Success = true,
                Message = $"Character {character.Name} created!"
            };
        }

        public Task<ServiceResponse<bool>> DeleteCharacter(int userId, string characterName)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<CharacterDto>>> GetUserCharacters(int userId)
        {
            var characters = await _dbContext.Characters
                .Where(u => u.UserId == userId)
                .Include(c => c.Class)
                .Include(s => s.MainSpec)
                .ToListAsync();

            var charDtos = _mapper.Map<List<CharacterDto>>(characters);

            return new ServiceResponse<List<CharacterDto>>
            {
                Data = charDtos,
                Success = true
            };
        }

        public async Task<ServiceResponse<CharacterDto>> UpdateCharacter(int charId, UpdateCharacterDto characterDto)
        {
            var character = await _dbContext.Characters
                .FirstOrDefaultAsync(c => c.Id == charId);


            if (character is null)
            {
                throw new NotFoundException("Character not found.");
            }

            character.ItemLevel = characterDto.ItemLevel;
            character.MainSpec = characterDto.MainSpec;
            var charDto = _mapper.Map<CharacterDto>(character);
            _dbContext.Update(character);
            await _dbContext.SaveChangesAsync();

            return new ServiceResponse<CharacterDto>
            {
                Success = true,
                Data = charDto
            };
        }
    }
}
