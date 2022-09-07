using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Shared.ViewModel
{
    public class UserLoginDto
    {
        [Required(ErrorMessage = "نام کاربری الزامی می باشد.")]
        public string UserName { get; set; } = string.Empty;
        [Required(ErrorMessage = "رمزعبور الزامی می باشد.")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "نوع کاربر الزامی می باشد.")]
        public int Type { get; set; }
    }
}
