using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace AM.Client.Services.UserService
{
    public class UserHttpService : IUserHttpService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _nav;
        private readonly IToastService _toastService;

        public UserHttpService(HttpClient http, NavigationManager nav, IToastService toastService)
        {
            _http = http;
            _nav = nav;
            _toastService = toastService;
        }

        public async Task<bool?> CheckUserIs()
        {
            var response = await _http.GetAsync("api/User/CheckUser");

            if (response.IsSuccessStatusCode)
            {
                var check = await response.Content.ReadFromJsonAsync<bool>();

                if (check == false)
                    _nav.NavigateTo("/User/NewAdmin");

                if(check == true){
                    _nav.NavigateTo("/");
                }
                return check;
            }

            return null;

        }

        public async Task<bool> CreateAdminUser(UserDto newUser)
        {
            var res = await _http.PostAsJsonAsync("api/User/Create", newUser);

            var ts = await res.Content.ReadFromJsonAsync<Toast>();
            if (res.IsSuccessStatusCode)
            {
                _toastService.ShowToast(ToastLevel.Success, ts.Message, ts.Title);
                _nav.NavigateTo("/");
                return true;
            }
            else
            {
                _toastService.ShowToast(ToastLevel.Error, ts.Message, ts.Title);
                return false;
            }
        }
    }
}
