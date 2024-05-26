using app.EntityModel.DataTablePaginationModels;
using app.Services.DesignationServices;
using app.Services.DropdownItemServices;
using app.Services.ProductCategoryServices;
using Microsoft.AspNetCore.Mvc;

namespace app.WebApp.Controllers
{
    public class DropdownItemController : Controller
    {

        private readonly IDropdownItemService _iService;
        public DropdownItemController(IDropdownItemService iService)
        {
            _iService = iService;
        }

        [HttpGet]
        public async Task<IActionResult> AddRecord()
        {
            DropdownItemViewModel viewModel = new DropdownItemViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddRecord(DropdownItemViewModel viewModel)
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
        public async Task<IActionResult> UpdateRecord(DropdownItemViewModel model)
        {
            var result = await _iService.UpdateRecord(model);
            if (result == true)
            {
                return RedirectToAction("Search");
            }
            ModelState.AddModelError(string.Empty, "Same Name already exists!");
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DropdownItemSearchDto model)
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
        public async Task<IActionResult> Search(DataTablePagination<DropdownItemSearchDto> searchDto)
        {
            var dataTable = await _iService.SearchAsync(searchDto);
            return Json(dataTable);
        }
        #endregion
    }
}
