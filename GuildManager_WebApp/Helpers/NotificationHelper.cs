using Microsoft.JSInterop;

namespace GuildManager_WebApp.Helpers
{
    public class NotificationHelper : INotificationHelper
    {
        private readonly IJSRuntime _jsRuntime;

        public NotificationHelper(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task ShowNotification(string message)
        {
            await _jsRuntime.InvokeVoidAsync("ShowNotification", "success", message);
        }
    }
}
