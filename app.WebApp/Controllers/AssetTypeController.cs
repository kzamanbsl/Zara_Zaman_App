using app.Services.DropdownServices;
using app.Services.AssetTypeServices;
using Microsoft.AspNetCore.Mvc;
using app.Services.AssetTypeServices;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace app.WebApp.Controllers
{
    public class AssetTypeController : Controller
    {

        private readonly IAssetTypeService _iService;
        private readonly IDropdownService _dropdownService;
        public AssetTypeController(IAssetTypeService iService, IDropdownService dropdownService)
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
            ViewBag.Unit = new SelectList((await _dropdownService.UnitSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            ViewBag.ProductCategories = new SelectList((await _dropdownService.ProductCategorySelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            AssetTypeViewModel viewModel = new AssetTypeViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddRecord(AssetTypeViewModel viewModel)
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
            ViewBag.Unit = new SelectList((await _dropdownService.UnitSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            ViewBag.ProductCategories = new SelectList((await _dropdownService.ProductCategorySelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            var result = await _iService.GetRecordById(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRecord(AssetTypeViewModel model)
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
    }
}
