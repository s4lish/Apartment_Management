using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Shared.ViewModel
{
    public class UserDto
    {
        public int Id { get; set; } = 0;

        [Required(ErrorMessage = "نام الزامی می باشد.")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "نام خانوادگی الزامی می باشد.")]
        public string Family { get; set; } = string.Empty;
        [Required(ErrorMessage = "نام کاربری الزامی می باشد.")]
        public string Username { get; set; } = string.Empty;
        [MinLength(8, ErrorMessage = "حداقل رمزعبور 8 کاراکتر می باشد.")]
        [Required(ErrorMessage = "رمز عبور اجباری می باشد.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$", ErrorMessage = "رمزعبور 8 رقم و شامل حروف کوچک و بزرگ انگلیسی و رقم و کاراکتر های وِیژه باشد.")]
        public string Password { get; set; } = string.Empty;

        [Compare("Password", ErrorMessage = "رمزعبور و تکرار آن اشتباه می باشد.")]
        public string ConfirmPassword { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        [RegularExpression("(^09[0-9]{9})$", ErrorMessage = "فرمت شماره همراه اشتباه می باشد.")]
        public string Mobile { get; set; } = string.Empty;
        public bool IsLocked { get; set; } = false;
    }
}
