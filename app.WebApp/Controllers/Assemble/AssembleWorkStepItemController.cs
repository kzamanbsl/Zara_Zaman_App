using app.EntityModel.DataTablePaginationModels;
using app.Services.ATMAssemble.AssembleWorkStepItemServices;
using app.Services.ATMAssemble.AssembleWorkStepServices;
using app.Services.DesignationServices;
using app.Services.DropdownServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace app.WebApp.Controllers.Assemble
{
    public class AssembleWorkStepItemController : Controller
    {

        private readonly IAssembleWorkStepItemService _iService;
        private readonly IDropdownService _iDropdownService;
        public AssembleWorkStepItemController(IAssembleWorkStepItemService iService, IDropdownService iDropdownService)
        {
            _iService = iService;
            _iDropdownService = iDropdownService;
        }

        [HttpGet]
        public async Task<IActionResult> AddRecord()
        {
            ViewBag.AssembleWorkStepList = new SelectList((await _iDropdownService.AssembleWorkStepSelectionList())
                .Select(s => new { s.Id, s.Name }), "Id", "Name");
            AssembleWorkStepItemViewModel viewModel = new AssembleWorkStepItemViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddRecord(AssembleWorkStepItemViewModel viewModel)
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
            ViewBag.AssembleWorkStepList = new SelectList((await _iDropdownService.AssembleWorkStepSelectionList())
                .Select(s => new { s.Id, s.Name }), "Id", "Name");
            var result = await _iService.GetRecordById(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRecord(AssembleWorkStepItemViewModel model)
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
        public async Task<IActionResult> Delete(AssembleWorkStepItemSearchDto model)
        {
            var res = await _iService.DeleteRecord(model.Id ?? 0);
            return RedirectToAction("Search");
        }

        #region Search
        [HttpGet]
        public async Task<IActionResult> Search()
        {
            ViewBag.AssembleWorkCategoryList = new SelectList((await _iDropdownService.AssembleWorkCategorySelectionList())
               .Select(s => new { s.Id, s.Name }), "Id", "Name");
            ViewBag.AssembleWorkStepList = new SelectList((await _iDropdownService.AssembleWorkStepSelectionList())
               .Select(s => new { s.Id, s.Name }), "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Search(DataTablePagination<AssembleWorkStepItemSearchDto> searchDto)
        {
            var dataTable = await _iService.SearchAsync(searchDto);
            return Json(dataTable);
        }
        #endregion
    }
}
