global using Microsoft.AspNetCore.Components.Authorization;
using Blazored.LocalStorage;
using GuildManager_WebApp;
using GuildManager_WebApp.Services.AuthService;
using GuildManager_WebApp.Services.CharactersService;
using GuildManager_WebApp.Services.ClassesService;
using GuildManager_WebApp.Services.MembersService;
using GuildManager_WebApp.Services.RaidEventsService;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Syncfusion.Blazor;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(
    builder.Configuration.GetValue<string>("SyncfusionLicence"));
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri(
    builder.Configuration.GetValue<string>("BaseAPIUrl"))
});
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IClassService, ClassService>();
builder.Services.AddScoped<ICharacterService, CharacterService>();
builder.Services.AddScoped<IMembersService, MembersService>();
builder.Services.AddScoped<IRaidEventService, RaidEventService>();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
builder.Services.AddSyncfusionBlazor();

await builder.Build().RunAsync();
