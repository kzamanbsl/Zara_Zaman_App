using app.EntityModel.DataTablePaginationModels;
using app.Services.ProductServices;
using app.Services.SalesTermsAndConditonServices;
using Microsoft.AspNetCore.Mvc;

namespace app.WebApp.Controllers
{
    public class SalesTermsAndConditionController : Controller
    {

        private readonly ISalesTermsAndConditionService _iService;
        public SalesTermsAndConditionController(ISalesTermsAndConditionService iService)
        {
            _iService = iService;
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
            SalesTermsAndConditionViewModel viewModel = new SalesTermsAndConditionViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddRecord(SalesTermsAndConditionViewModel viewModel)
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
        public async Task<IActionResult> UpdateRecord(SalesTermsAndConditionViewModel model)
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
        public async Task<IActionResult> Search(DataTablePagination<SalesTermsAndConditionSearchDto> searchDto)
        {
            var dataTable = await _iService.SearchAsync(searchDto);
            return Json(dataTable);
        }

        #endregion
    }
}
