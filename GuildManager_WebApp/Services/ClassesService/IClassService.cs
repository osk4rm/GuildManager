using GuildManager_Models.CharacterClassesAndSpecs;
using GuildManager_Models;

namespace GuildManager_WebApp.Services.ClassesService
{
    public interface IClassService
    {
        Task<ServiceResponse<List<CharacterClassDto>>> GetClasses();
    }
}
