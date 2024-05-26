using app.EntityModel.DataTablePaginationModels;
using app.Services.CompanyServices;
using app.Services.DesignationServices;
using app.Services.StorehouseServices;
using Microsoft.AspNetCore.Mvc;

namespace app.WebApp.AdminControllers
{
    public class CompanyController : Controller
    {
        private readonly ICompanyService _iService;
        public CompanyController(ICompanyService iService)
        {
            _iService = iService;
        }

        [HttpGet]
        public async Task<IActionResult> AddRecord()
        {
            CompanyViewModel viewModel = new CompanyViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddRecord(CompanyViewModel viewModel)
        {
            var result = await _iService.AddRecord(viewModel);
            if (result == true)
            {
                return RedirectToAction("Search");
            }
            ModelState.AddModelError(string.Empty, "Same Name already exists!");
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateRecord(long id)
        {
            var result = await _iService.GetRecordById(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRecord(CompanyViewModel model)
        {
            var result= await _iService.UpdateRecord(model);
            if (result == true)
            {
                return RedirectToAction("Search");
            }
            ModelState.AddModelError(string.Empty, "Same Name already exists!");
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(CompanySearchDto model)
        {
            var res = await _iService.DeleteRecord(model.Id ?? 0);
            return RedirectToAction("Search");
        }

        #region Search
        [HttpGet]
        public async Task<IActionResult> Search()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Search(DataTablePagination<CompanySearchDto> searchDto)
        {
            var dataTable = await _iService.SearchAsync(searchDto);
            return Json(dataTable);
        }
        #endregion
    }
}
