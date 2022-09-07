namespace AM.Server.Services.NotificationService
{
    public interface INotificationService
    {
        Task SentAll(Notifications notifi);
    }
}
