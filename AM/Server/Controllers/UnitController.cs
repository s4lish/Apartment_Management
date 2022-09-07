using Microsoft.AspNetCore.Mvc;

namespace AM.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class UnitController : ControllerBase
    {
        private readonly IUnitService _unitService;
        private Toast ts = new Toast();

        public UnitController(IUnitService unitService)
        {
            _unitService = unitService;
        }

        [HttpGet]
        public async Task<Pagination<UnitInfoView>> Get([FromQuery] PaginationParameters parameters)
        {
            var infos = await _unitService.Get(parameters.currentPageNumber,parameters.pagesize,parameters.filter1);
            return infos;
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(int Id)
        {
          var check = await _unitService.ChangeActiveStatus(Id);


            if (check)
            {
                ts.Message = "تغییر وضعیت با موفقیت انجام شد.";
                ts.Type = ToastType.Success;

                return Ok(ts);
            }

            ts.Message = "خطا در تغییر وضعیت.";
            return NotFound(ts);

        }

        [HttpPost]
        public async Task<IActionResult> Post(UnitInfoView unit)
        {
          var check = await _unitService.SetUnit(unit);

            if (check)
            {
                ts.Message = $"واحد آقا/خانم {unit.NameFamilyMalek} با موفقیت ثبت گردید.";
                ts.Type = ToastType.Success;

                return Ok(ts);
            }

            ts.Message = "خطا در ثبت واحد جدید.";
            return NotFound(ts);


        }

        
    }
}
