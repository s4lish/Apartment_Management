namespace AM.Client.Services.NotificationService
{
    public interface INotificationHttpService
    {
        Task SendNotification(Notifications not);

        Task ShowNotification(Notifications not);
    }
}
