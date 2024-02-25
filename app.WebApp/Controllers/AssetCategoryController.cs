using app.Services.DropdownServices;
using app.Services.AssetCategoryServices;
using Microsoft.AspNetCore.Mvc;
using app.EntityModel.DataTablePaginationModels;
using app.Services.SaleCenterServices;

namespace app.WebApp.Controllers
{
    public class AssetCategoryController : Controller
    {

        private readonly IAssetCategoryService _iService;
        private readonly IDropdownService _dropdownService;
        public AssetCategoryController(IAssetCategoryService iService, IDropdownService dropdownService)
        {
            _iService = iService;
            _dropdownService = dropdownService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _iService.GetAllRecord();
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> AddRecord()
        {
            AssetCategoryViewModel viewModel = new AssetCategoryViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddRecord(AssetCategoryViewModel viewModel)
        {
            var result = await _iService.AddRecord(viewModel);
            if (result == true)
            {
                return RedirectToAction("Index");
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
        public async Task<IActionResult> UpdateRecord(AssetCategoryViewModel model)
        {
            var result = await _iService.UpdateRecord(model);
            if (result == true)
            {
                return RedirectToAction("Index");
            }
            ModelState.AddModelError(string.Empty, "Same Name already exists!");
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(long id)
        {
            var res = await _iService.DeleteRecord(id);
            return RedirectToAction("Index");
        }

        #region Search
        [HttpGet]
        public async Task<IActionResult> Search()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Search(DataTablePagination<AssetCategorySearchDto> searchDto)
        {
            var dataTable = await _iService.SearchAsync(searchDto);
            return Json(dataTable);
        }
        #endregion
    }
}
