namespace GuildManager_WebApp.Helpers
{
    public interface INotificationHelper
    {
        Task ShowSuccessNotification(string message);
        Task ShowErrorNotification(string message);
    }
}