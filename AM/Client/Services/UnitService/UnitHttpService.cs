using Microsoft.AspNetCore.WebUtilities;
using MudBlazor;
using System.Net.Http.Json;

namespace AM.Client.Services.UnitService
{
    public class UnitHttpService : IUnitHttpService
    {
        private readonly HttpClient _http;
        private readonly IToastService _toastService;

        public UnitHttpService(HttpClient http, IToastService toastService)
        {
            _http = http;
            _toastService = toastService;
        }

        public async Task<bool> ChangeActiveStatus(int Id)
        {
            var response = await _http.GetAsync($"api/Unit/{Id}");

            var ts = await response.Content.ReadFromJsonAsync<Toast>();

            if (response.IsSuccessStatusCode)
            {
                _toastService.ShowToast(ToastLevel.Success, ts.Message, ts.Title);
                return true;
            }

            _toastService.ShowToast(ToastLevel.Error, ts.Message, ts.Title);
            return false;
        }

        public async Task<TableData<UnitInfoView>> GetInfo(PaginationParameters parameters)
        {
            var queryStringParam = new Dictionary<string, string>
            {
                ["currentPageNumber"] = parameters.currentPageNumber.ToString(),
                ["pagesize"] = parameters.pagesize.ToString(),
                ["filter1"] = parameters.filter1
            };

            var query = QueryHelpers.AddQueryString("api/Unit", queryStringParam);
            var response = await _http.GetFromJsonAsync<Pagination<UnitInfoView>>(query);


            return new TableData<UnitInfoView>() { Items = response.Data, TotalItems = response.TotalCount };
        }

        public async Task<bool> SetInfo(UnitInfoView unit)
        {
            var response = await _http.PostAsJsonAsync("api/Unit", unit);

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
