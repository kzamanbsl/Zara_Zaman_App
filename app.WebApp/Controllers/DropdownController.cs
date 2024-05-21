using app.EntityModel.AppModels;
using app.Services.DropdownServices;
using Microsoft.AspNetCore.Mvc;

namespace app.WebApp.Controllers
{
    public class DropdownController : Controller
    {
        private readonly IDropdownService _iService;
        public DropdownController(IDropdownService iService)
        {
            _iService = iService;
        }

        [HttpPost]
        public async Task<IEnumerable<DropdownViewModel>> GetCountrySelectionList()
        {

            var res = await _iService.CountrySelectionList();
            return res;
        }

        [HttpPost]
        public async Task<IActionResult> GetDistrictSelectionList(int divisionId = 0)
        {
            var res = await _iService.DistrictSelectionList(divisionId);
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> GetDivisionSelectionList()
        {
            var res = await _iService.DivisionSelectionList();
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> GetUpazilaSelectionList(int divisionId = 0, int districtId = 0)
        {
            var res = await _iService.UpazilaSelectionList(divisionId, districtId);
            return Ok(res);
        }
        [HttpGet]
        public async Task<JsonResult> GetBankBranchListByBankId(long bankId)
        {
            var res = await _iService.BankBranchSelectionList(bankId);
            return Json(res);
        }
    }
}
