using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AM.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApartmentController : ControllerBase
    {
        private readonly IApartmentService _service;
        private Toast ts = new Toast();

        public ApartmentController(IApartmentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var info =await _service.GetInfo();
                return Ok(info);

            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(ApartmentInfoView apartment)
        {

          var check =  await _service.SetInfo(apartment);

            if (check)
            {
                ts.Message = "اطلاعات مجتمع با موفقیت ثبت گردید.";
                ts.Type = ToastType.Success;

                return Ok(ts);
            }

            ts.Message = "خطا در افزودن اطلاعات مجتمع";
            return NotFound(ts);

        }
    }
}
