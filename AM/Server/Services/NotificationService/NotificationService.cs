using AM.Server.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace AM.Server.Services.NotificationService
{
    public class NotificationService : INotificationService
    {
        private readonly IHubContext<NotificationHub> _hub;

        public NotificationService(IHubContext<NotificationHub> hub)
        {
            _hub = hub;
        }

        public async Task SentAll(Notifications notifi)
        {
             await _hub.Clients.All.SendAsync("NotificationServer", notifi); 
        }
    }
}
