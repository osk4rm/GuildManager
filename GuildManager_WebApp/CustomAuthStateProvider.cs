using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;

namespace GuildManager_WebApp
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorageService;

        public CustomAuthStateProvider(HttpClient httpClient, ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            string authToken = await _localStorageService.GetItemAsStringAsync("authToken");

            return null;
        }
    }
}
