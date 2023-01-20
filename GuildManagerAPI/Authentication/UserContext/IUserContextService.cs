using System.Security.Claims;

namespace GuildManagerAPI.Authentication.UserContext
{
    public interface IUserContextService
    {
        int? Id { get; }
        ClaimsPrincipal? User { get; }
    }
}