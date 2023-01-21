using GuildManager_Models;
using GuildManager_Models.Members;

namespace GuildManager_WebApp.Services.MembersService
{
    public interface IMembersService
    {
        Task<ServiceResponse<List<MemberDto>>> GetMembers();
    }
}
