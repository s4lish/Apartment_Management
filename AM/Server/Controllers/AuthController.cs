using Microsoft.AspNetCore.Mvc;

namespace AM.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private Toast ts = new Toast();
        private IAuthService _auth;

        public AuthController(IAuthService auth)
        {
            _auth = auth;
        }

        [HttpPost]
        public async Task<IActionResult> Post(UserLoginDto request)
        {
            string info = "";

            if (request.Type == 1)
                info = await _auth.GetLoginAdmin(request);
            else
                info = await _auth.GetLoginUnit(request);
            

            if (info == "201")
            {
                ts.Message = "کاربر مورد نظر یافت نشد.";
                return BadRequest(ts);
            }

            if (info == "202")
            {
                ts.Message = "کاربری شما غیرفعال شده است.لطفا با ادمین سامانه تماس بگیرید.";
                return BadRequest(ts);

            }

            if (info == "203")
            {

                ts.Message = "نام کاربری و یا رمزعبور اشتباه است.";
                return BadRequest(ts);

            }

            return Ok(info);
        }


    }
}
