using app.EntityModel.DataTablePaginationModels;
using app.Services.EmployeeCategoryServices;
using app.Services.OfficeTypeServices;
using Microsoft.AspNetCore.Mvc;

namespace app.WebApp.Controllers
{
    public class OfficeTypeController : Controller
    {
        private readonly IOfficeTypeService _iService;
        public OfficeTypeController(IOfficeTypeService iService)
        {
            _iService = iService;
        }

        [HttpGet]
        public async Task<IActionResult> AddRecord()
        {
            OfficeTypeViewModel viewModel = new OfficeTypeViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddRecord(OfficeTypeViewModel viewModel)
        {
            var result = await _iService.AddRecord(viewModel);
            if (result ==true)
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
        public async Task<IActionResult> UpdateRecord(OfficeTypeViewModel model)
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
        public async Task<IActionResult> Search(DataTablePagination<OfficeTypeSearchDto> searchDto)
        {
            var dataTable = await _iService.SearchAsync(searchDto);
            return Json(dataTable);
        }
        #endregion
    }
}
