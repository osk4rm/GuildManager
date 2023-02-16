using AutoMapper;
using GuildManager_DataAccess.Entities;
using GuildManager_DataAccess.Entities.Raids;
using GuildManager_Models.Auth;
using GuildManager_Models.CharacterClassesAndSpecs;
using GuildManager_Models.Characters;
using GuildManager_Models.Members;
using GuildManager_Models.RaidEventParticipantsOperations;
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
            CreateMap<User, MemberDto>()
                .ForMember(m => m.Rank, a => a.MapFrom(u => u.Role.Name));

            CreateMap<User, UserInfoDto>()
                .ForMember(ui => ui.Role, a => a.MapFrom(u => u.Role.Name));

            CreateMap<RaidLocation, RaidLocationDto>()
                .ForMember(d => d.ExpansionId, a => a.MapFrom(e => e.Expansion.Id))
                .ForMember(d => d.ExpansionName, a => a.MapFrom(e => e.Expansion.Name));
            CreateMap<RaidExpansion, RaidExpansionDto>();

            CreateMap<RaidEvent, RaidEventDto>()
                .ForMember(d => d.LeaderId, a => a.MapFrom(e => e.CreatedBy.Id))
                .ForMember(d => d.LeaderName, a => a.MapFrom(e => e.CreatedBy.Nickname));

            CreateMap<UpsertRaidEventDto, RaidEvent>();

            CreateMap<RaidEventCharacter, RaidEventCharacterDto>();
            CreateMap<UpdateRaidEventCharacterDto, RaidEventCharacter>();

            CreateMap<Comment, CommentDto>();

            CreateMap<RaidEventCharacter, RaidInviteDto>()
                .ForMember(d => d.RaidEventId, a => a.MapFrom(rec => rec.RaidEvent.Id))
                .ForMember(d => d.RaidLocation, a => a.MapFrom(rec => rec.RaidEvent.RaidLocation.Name))
                .ForMember(d => d.RaidLocationImg, a => a.MapFrom(rec => rec.RaidEvent.RaidLocation.ImageUrl))
                .ForMember(d => d.RaidDifficulty, a => a.MapFrom(rec => rec.RaidEvent.RaidDifficulty))
                .ForMember(d => d.RaidStartDate, a => a.MapFrom(rec => rec.RaidEvent.StartDate))
                .ForMember(d => d.InvitedCharacterName, a => a.MapFrom(rec => rec.Character.Name))
                .ForMember(d => d.InvitedCharacterId, a => a.MapFrom(rec => rec.Character.Id))
                .ForMember(d => d.HostName, a => a.MapFrom(rec => rec.RaidEvent.CreatedBy.Nickname))
                .ForMember(d => d.HostAvatar, a => a.MapFrom(rec => rec.RaidEvent.CreatedBy.Avatar));
        }
    }
}
