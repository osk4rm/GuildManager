using AutoMapper;
using GuildManager_DataAccess.Entities;
using GuildManager_Models.CharacterClassesAndSpecs;
using GuildManager_Models.Characters;

namespace GuildManagerAPI.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CharacterClass, CharacterClassDto>().ReverseMap();
            CreateMap<ClassSpecialization, ClassSpecDto>().ReverseMap();

            CreateMap<Character, CharacterDto>().ReverseMap();
            CreateMap<Character, CreateCharacterDto>().ReverseMap();
            CreateMap<Character, UpdateCharacterDto>().ReverseMap();
        }
    }
}
