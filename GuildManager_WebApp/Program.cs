using GuildManager_WebApp;
using GuildManager_WebApp.Services.AuthService;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri(
    builder.Configuration.GetValue<string>("BaseAPIUrl"))
});
builder.Services.AddScoped<IAuthService, AuthService>();
await builder.Build().RunAsync();
