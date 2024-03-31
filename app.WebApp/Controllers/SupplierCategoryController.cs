using app.EntityModel.DataTablePaginationModels;
using app.Services.DropdownServices;
using app.Services.SupplierCategoryServices;
using app.Services.SupplierServices;
using app.Services.UnitServices;
using Microsoft.AspNetCore.Mvc;

namespace app.WebApp.Controllers
{
    public class SupplierCategoryController : Controller
    {

        private readonly ISupplierCategoryService _iService;
        private readonly IDropdownService _dropdownService;
        public SupplierCategoryController(ISupplierCategoryService iService, IDropdownService dropdownService)
        {
            _iService = iService;
            _dropdownService = dropdownService;
        }

        [HttpGet]
        public async Task<IActionResult> AddRecord()
        {
            SupplierCategoryViewModel viewModel = new SupplierCategoryViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddRecord(SupplierCategoryViewModel viewModel)
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
        public async Task<IActionResult> UpdateRecord(SupplierCategoryViewModel model)
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
        public async Task<IActionResult> Search(DataTablePagination<SupplierCategorySearchDto> searchDto)
        {
            var dataTable = await _iService.SearchAsync(searchDto);
            return Json(dataTable);
        }
        #endregion
    }
}