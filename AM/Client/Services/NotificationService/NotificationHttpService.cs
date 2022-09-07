using Append.Blazor.Notifications;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Json;

namespace AM.Client.Services.NotificationService
{
    public class NotificationHttpService : INotificationHttpService
    {
        private readonly HttpClient _http;
        private readonly IToastService _toastService;
        private readonly INotificationService _notificationService;
        private readonly ILocalStorageService _localStorage;
        public NotificationHttpService(HttpClient http, IToastService toastService, INotificationService notificationService, ILocalStorageService localStorage)
        {
            _http = http;
            _toastService = toastService;
            _notificationService = notificationService;
            _localStorage = localStorage;
        }
        public async Task SendNotification(Notifications not)
        {
            var response = await _http.PostAsJsonAsync("api/notification", not);

            if (response.IsSuccessStatusCode)
            {
                _toastService.ShowToast(ToastLevel.Success, "اطلاعیه با موفقیت ارسال شد.", "موفقیت");
                return;
            }

            _toastService.ShowToast(ToastLevel.Error, "خطا در ارسال اطلاعیه", "خطا");
            return;

        }

        public async Task ShowNotification(Notifications not)
        {
           var _notPermision = await _localStorage.GetItemAsync<bool>("permisionNoti");

            _toastService.ShowToast(ToastLevel.Info, not.Message, not.Title);
            if (_notPermision)
            {
                await _notificationService.CreateAsync(not.Title, not.Message, "apartment.png");
            }
        }
    }
}
