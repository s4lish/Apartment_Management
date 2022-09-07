using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace AM.Client.Services
{
    public class PagedPageDetails<T> : ComponentBase
    {
        protected PaginationParameters paging = new PaginationParameters();

        protected MudTable<T> table;

        protected int[] _pageSizeOptions = new int[] {2, 10, 20, 50, 100 };

        protected bool _loading;

        protected string _rowsPerPageString = "ردیف در هر صفحه";

        protected bool _hover = true;

        protected bool _dense = true;

        protected string _filterSearch = string.Empty;

        protected async Task OnSearch(string search)
        {
            _loading = true;
            paging.filter1 = search;
            await table.ReloadServerData();
        }
    }
}
