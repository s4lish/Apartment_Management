using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Shared.ViewModel
{
    public class Notifications
    {
        [Required(ErrorMessage = "عنوان الزامی می باشد.")]
        public string Title { get; set; } = string.Empty;
        [Required(ErrorMessage = "متن اطلاعیه الزامی می باشد.")]
        public string Message { get; set; } = string.Empty;
    }
}
