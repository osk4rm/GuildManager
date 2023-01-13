using AutoMapper;
using GuildManager_DataAccess.Entities;
using GuildManager_Models.CharacterClassesAndSpecs;

namespace GuildManagerAPI.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CharacterClass, CharacterClassDto>();
            CreateMap<ClassSpecialization, ClassSpecDto>();
        }
    }
}
