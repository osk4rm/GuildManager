using GuildManager_DataAccess.Entities;
using GuildManager_Models;
using GuildManager_Models.CharacterClassesAndSpecs;

namespace GuildManagerAPI.Services.Interfaces
{
    public interface IClassesService
    {
        Task<ServiceResponse<List<CharacterClassDto>>> GetClasses();
        Task<ServiceResponse<List<ClassCountDto>>> GetClassCount();
        Task<ServiceResponse<List<RoleCountDto>>> GetRoleCount();
    }
}
