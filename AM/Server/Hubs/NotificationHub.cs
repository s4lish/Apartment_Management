using Microsoft.AspNetCore.SignalR;

namespace AM.Server.Hubs
{
    public class NotificationHub : Hub
    {
        public async Task SendNotifiToAll(Notifications data) => await Clients.All.SendAsync("NotificationServer", data);



    }
}
