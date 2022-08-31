using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Shared.ViewModel
{
    public class ApartmentInfoView
    {
        [Required(ErrorMessage = "عنوان  مجتمع الزامی می باشد.")]
        public string Title { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        [Range(1,10000,ErrorMessage = "ثبت تعداد واحد الزامی می باشد")]
        public int UnitNumber { get; set; }
    }
}
