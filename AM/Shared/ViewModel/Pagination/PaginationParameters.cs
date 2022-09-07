using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Shared.ViewModel.Pagination
{
    public class PaginationParameters
    {
        public int currentPageNumber { get; set; }
        public int pagesize { get; set; }

        public string? filter1 { get; set; } = string.Empty;

    }

}
