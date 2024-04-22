using app.EntityModel.DataTablePaginationModels;
using app.Services.DropdownServices;
using app.Services.ProductServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace app.WebApp.Controllers
{
    public class ProductController : Controller
    {
        
        private readonly IProductService _iService;
        private readonly IDropdownService _dropdownService;
        public ProductController(IProductService iService, IDropdownService dropdownService)
        {
            _iService = iService;
            _dropdownService = dropdownService;
        }


        [HttpGet]
        public async Task<IActionResult> AddRecord()
        {
            ViewBag.Units = new SelectList((await _dropdownService.UnitSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            ViewBag.ProductCategories = new SelectList((await _dropdownService.ProductCategorySelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            ProductViewModel viewModel = new ProductViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddRecord(ProductViewModel viewModel)
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
            ViewBag.Units = new SelectList((await _dropdownService.UnitSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            ViewBag.ProductCategories = new SelectList((await _dropdownService.ProductCategorySelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            var result = await _iService.GetRecordById(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRecord(ProductViewModel model)
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
            ViewBag.Units = new SelectList((await _dropdownService.UnitSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            ViewBag.ProductCategories = new SelectList((await _dropdownService.ProductCategorySelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Search(DataTablePagination<ProductSearchDto> searchDto)
        {
            var dataTable = await _iService.SearchAsync(searchDto);
            return Json(dataTable);
        }

        #endregion
    }
}
