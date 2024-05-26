using app.EntityModel.DataTablePaginationModels;
using app.Services.AssetCategoryServices;
using app.Services.ATMAssemble.AssembleWorkCategoryServices;
using app.Services.DesignationServices;
using Microsoft.AspNetCore.Mvc;

namespace app.WebApp.Controllers.Assemble
{
    public class AssembleWorkCategoryController : Controller
    {

        private readonly IAssembleWorkCategoryService _iService;
        public AssembleWorkCategoryController(IAssembleWorkCategoryService iService)
        {
            _iService = iService;
        }

        [HttpGet]
        public async Task<IActionResult> AddRecord()
        {
            AssembleWorkCategoryViewModel viewModel = new AssembleWorkCategoryViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddRecord(AssembleWorkCategoryViewModel viewModel)
        {
            var result = await _iService.AddRecord(viewModel);
            if (result == true)
            {
                return RedirectToAction("Search");
            }
            ModelState.AddModelError(string.Empty, "This name is already used!");
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateRecord(long id)
        {
            var result = await _iService.GetRecordById(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRecord(AssembleWorkCategoryViewModel model)
        {
            var result = await _iService.UpdateRecord(model);
            if (result == true)
            {
                return RedirectToAction("Search");
            }
            ModelState.AddModelError(string.Empty, "This name is already used!");
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(AssembleWorkCategorySearchDto model)
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
        public async Task<IActionResult> Search(DataTablePagination<AssembleWorkCategorySearchDto> searchDto)
        {
            var dataTable = await _iService.SearchAsync(searchDto);
            return Json(dataTable);
        }
        #endregion
    }
}
