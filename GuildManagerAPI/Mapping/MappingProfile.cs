using AutoMapper;
using GuildManager_DataAccess.Entities;
using GuildManager_DataAccess.Entities.Raids;
using GuildManager_Models.CharacterClassesAndSpecs;
using GuildManager_Models.Characters;
using GuildManager_Models.Members;
using GuildManager_Models.RaidEvents;
using GuildManager_Models.RaidExpansionsAndLocations;

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
            CreateMap<User, MemberDto>();

            CreateMap<RaidLocation, RaidLocationDto>()
                .ForMember(d => d.ExpansionId, a => a.MapFrom(e => e.Expansion.Id))
                .ForMember(d => d.ExpansionName, a => a.MapFrom(e => e.Expansion.Name));
            CreateMap<RaidExpansion, RaidExpansionDto>();

            CreateMap<RaidEvent, RaidEventDto>()
                .ForMember(d => d.LeaderId, a => a.MapFrom(e => e.CreatedBy.Id))
                .ForMember(d => d.LeaderName, a => a.MapFrom(e => e.CreatedBy.Nickname));

            CreateMap<UpsertRaidEventDto, RaidEvent>();

        }
    }
}
