using GuildManager_Models.CharacterClassesAndSpecs;
using GuildManager_Models;
using GuildManager_DataAccess.Entities;

namespace GuildManager_WebApp.Services.ClassesService
{
    public interface IClassService
    {
        Task<ServiceResponse<List<CharacterClassDto>>> GetClasses();
    }
}
