using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace AM.Client.Services.ApartmentService
{
    public class ApartmentHttpService : IApartmentHttpService
    {
        private readonly HttpClient _http;
        private readonly IToastService _toastService;

        public ApartmentHttpService(HttpClient http, IToastService toastService)
        {
            _http = http;
            _toastService = toastService;
        }
            
        public async Task<ApartmentInfoView> Get()
        {
            var response = await _http.GetAsync("api/Apartment");

            if (response.IsSuccessStatusCode)
            {
                var info = await response.Content.ReadFromJsonAsync<ApartmentInfoView>();

                return info ?? new ApartmentInfoView();
            }

            return new ApartmentInfoView();
        }

        public async Task<bool> SetInfo(ApartmentInfoView info)
        {
            var response = await _http.PostAsJsonAsync("api/Apartment", info);

            var ts = await response.Content.ReadFromJsonAsync<Toast>();

            if (response.IsSuccessStatusCode)
            {
                _toastService.ShowToast(ToastLevel.Success, ts.Message, ts.Title);
                return true;
            }

            _toastService.ShowToast(ToastLevel.Error, ts.Message, ts.Title);
            return false;



        }
    }
}
