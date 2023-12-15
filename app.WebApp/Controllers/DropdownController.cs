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

        [HttpGet]
        public async Task<IEnumerable<DropdownViewModel>> GetCountrySelectionList()
        {

            var res = await _iService.CountrySelectionList();
            return res;
        }

        [HttpGet]
        public async Task<IEnumerable<DropdownViewModel>> GetDivisionSelectionList()
        {
            var res = await _iService.DivisionSelectionList();
            return res;
        }

        [HttpGet]
        public async Task<IEnumerable<DropdownViewModel>> GetDistrictSelectionList(int divisionId = 0)
        {
            var res = await _iService.DistrictSelectionList(divisionId);
            return res;
        }

        [HttpGet]
        public async Task<IEnumerable<DropdownViewModel>> GetUpazilaSelectionList(int divisionId = 0, int districtId = 0)
        {
            var res = await _iService.UpazilaSelectionList(divisionId, districtId);
            return res;
        }

    }
}
