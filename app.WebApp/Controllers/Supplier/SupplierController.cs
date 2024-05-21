using app.EntityModel.DataTablePaginationModels;
using app.Services.CompanyServices;
using app.Services.DropdownServices;
using app.Services.ProductServices;
using app.Services.SupplierServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace app.WebApp.Controllers.Supplier
{
    public class SupplierController : Controller
    {

        private readonly ISupplierService _iService;
        private readonly IDropdownService _dropdownService;
        public SupplierController(ISupplierService iService, IDropdownService iDropdownService)
        {
            _iService = iService;
            _dropdownService = iDropdownService;
        }


        [HttpGet]
        public async Task<IActionResult> AddRecord()
        {
            SupplierViewModel viewModel = new SupplierViewModel();
            ViewBag.SupplierCatgoryList = new SelectList((await _dropdownService.SupplierCategorySelectionList()).Select(s => new { s.Id, s.Name }), "Id", "Name");

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddRecord(SupplierViewModel viewModel)
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
            ViewBag.SupplierCatgoryList = new SelectList((await _dropdownService.SupplierCategorySelectionList()).Select(s => new { s.Id, s.Name }), "Id", "Name");
            ViewBag.Country = new SelectList((await _dropdownService.CountrySelectionList()).Select(s => new { s.Id, s.Name }), "Id", "Name");
            ViewBag.Division = new SelectList((await _dropdownService.DivisionSelectionList()).Select(s => new { s.Id, s.Name }), "Id", "Name");
            ViewBag.District = new SelectList((await _dropdownService.DistrictSelectionList()).Select(s => new { s.Id, s.Name }), "Id", "Name");
            ViewBag.Upazila = new SelectList((await _dropdownService.UpazilaSelectionList()).Select(s => new { s.Id, s.Name }), "Id", "Name");
            var result = await _iService.GetRecordById(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRecord(SupplierViewModel model)
        {
            var result = await _iService.UpdateRecord(model);
            if (result == true)
            {
                return RedirectToAction("Search");
            }
            ModelState.AddModelError(string.Empty, "Same Name already exists!");
            return View(model);
        }

        public async Task<JsonResult> GetSupplierInformation(long id)
        {
            if (id == 0) { return Json(null); }
            var model = await _iService.GetRecordById(id);
            return Json(model);
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
            ViewBag.Countries = new SelectList((await _dropdownService.CountrySelectionList()).Select(s => new { s.Id, s.Name }), "Id", "Name");
            ViewBag.Divisions = new SelectList((await _dropdownService.DivisionSelectionList()).Select(s => new { s.Id, s.Name }), "Id", "Name");
            ViewBag.Districts = new SelectList((await _dropdownService.EmptySelectionList()).Select(s => new { s.Id, s.Name }), "Id", "Name");
            ViewBag.Upazilas = new SelectList((await _dropdownService.EmptySelectionList()).Select(s => new { s.Id, s.Name }), "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Search(DataTablePagination<SupplierSearchDto> searchDto)
        {
            var dataTable = await _iService.SearchAsync(searchDto);
            return Json(dataTable);
        }

        #endregion
    }
}
