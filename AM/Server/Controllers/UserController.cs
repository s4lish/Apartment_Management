using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AM.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private Toast ts = new Toast();


        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("CheckUser")]
        public async Task<IActionResult> CheckUser()
        {
            var check = await _userService.CheckUserIs();
            return Ok(check);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(UserDto user)
        {
            try
            {
                var check = await _userService.CreateAdmin(user);

                if (check)
                {
                    ts.Message = "کاربر جدید با موفقیت ثبت شد";
                    ts.Type = ToastType.Success;

                    return Ok(ts);
                }

                ts.Message = "خطا در افزودن کاربر جدید";
                return NotFound(ts);

            }
            catch(Exception ex)
            {
                ts.Message = ex.Message;
                return BadRequest(ts);
            }

        }

    }
}
