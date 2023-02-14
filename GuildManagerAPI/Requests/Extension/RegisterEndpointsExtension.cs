namespace GuildManagerAPI.Requests.Extension
{
    public static class RegisterEndpointsExtension
    {
        public static WebApplication RegisterEndpoints(this WebApplication app)
        {
            app.RegisterLoginEndpoints();
            app.RegisterClassesEndpoints();
            app.RegisterCharactersEndpoints();
            app.RegisterMembersEndpoints();
            app.RegisterRaidExpansionsEndpoints();
            app.RegisterRaidLocationsEndpoints();
            app.RegisterRaidEventsEndpoints();
            app.RegisterRaidEventsParticipationEndpoints();

            return app;
        }
    }
}
