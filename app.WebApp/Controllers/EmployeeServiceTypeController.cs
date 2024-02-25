using app.EntityModel.DataTablePaginationModels;
using app.Services.CompanyServices;
using app.Services.EmployeeGradeServices;
using app.Services.EmployeeServiceTypeServices;
using Microsoft.AspNetCore.Mvc;

namespace app.WebApp.Controllers
{
    public class EmployeeServiceTypeController : Controller
    {

        private readonly IEmployeeServiceTypeService _iService;
        public EmployeeServiceTypeController(IEmployeeServiceTypeService iService)
        {
            _iService = iService;
        }

        [HttpGet]
        public async Task<IActionResult> AddRecord()
        {
            EmployeeServiceTypeViewModel viewModel = new EmployeeServiceTypeViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddRecord(EmployeeServiceTypeViewModel viewModel)
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
        public async Task<IActionResult> UpdateRecord(EmployeeServiceTypeViewModel model)
        {
            var result = await _iService.UpdateRecord(model);
            if (result == true)
            {
                return RedirectToAction("Search");
            }
            ModelState.AddModelError(string.Empty, "Same Name already exists!");
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(long id)
        {
            var res = await _iService.DeleteRecord(id);
            return RedirectToAction("Search");
        }

        #region Search
        [HttpGet]
        public async Task<IActionResult> Search()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Search(DataTablePagination<EmployeeServiceTypeSearchDto> searchDto)
        {
            var dataTable = await _iService.SearchAsync(searchDto);
            return Json(dataTable);
        }
        #endregion
    }
}
