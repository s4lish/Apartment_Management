using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace AM.Client.Services.LoginService
{
    public class LoginHttpService : ILoginHttpService
    {
        private readonly HttpClient _http;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly ILocalStorageService _localStorage;
        private readonly NavigationManager _nav;
        private readonly IToastService _toastService;

        public LoginHttpService(HttpClient http, AuthenticationStateProvider authenticationStateProvider, ILocalStorageService localStorageService, NavigationManager navigationManger, IToastService toastService)
        {
            _http = http;
            _authenticationStateProvider = authenticationStateProvider;
            _localStorage = localStorageService;
            _nav = navigationManger;
            _toastService = toastService;
        }

        public async Task<bool> LoginAsync(UserLoginDto user)
        {
            var res = await _http.PostAsJsonAsync("api/auth", user);
            if (res.IsSuccessStatusCode)
            {
                var token = await res.Content.ReadAsStringAsync();
                await _localStorage.SetItemAsync("token", token);
                await _authenticationStateProvider.GetAuthenticationStateAsync();
                _nav.NavigateTo("/");
                return true;
            }
            else
            {
                var ts = await res.Content.ReadFromJsonAsync<Toast>();
                _toastService.ShowToast(ToastLevel.Error, ts.Message, ts.Title);
                return false;

            }
        }
    }
}
