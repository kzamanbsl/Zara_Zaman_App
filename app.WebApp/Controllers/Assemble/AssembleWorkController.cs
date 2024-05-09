using app.EntityModel.AppModels.ATMAssemble;
using app.EntityModel.DataTablePaginationModels;
using app.Services.ATMAssemble.AssembleWorkServices;
using app.Services.DropdownServices;
using app.Services.ProductServices;
using app.Utility;
using app.Utility.UtilityServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace app.WebApp.Controllers.Assemble
{
    public class AssembleWorkController : Controller
    {
        private readonly IAssembleWorkService _iService;
        private readonly IDropdownService _iDropdownService;
        private readonly IUtilityService _iUtilityService;

        public AssembleWorkController(IAssembleWorkService iService, IDropdownService iDropdownService, IUtilityService iUtilityService)
        {
            _iService = iService;
            _iDropdownService = iDropdownService;
            _iUtilityService = iUtilityService;
        }

        [HttpGet]
        public async Task<IActionResult> Details(long id)
        {
            var result = await _iService.GetRecordById(id);
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> AddRecord()
        {
            ViewBag.AssembleWorkCategoryList = new SelectList((await _iDropdownService.AssembleWorkCategorySelectionList())
                .Select(s => new { s.Id, s.Name }), "Id", "Name");
            ViewBag.EmployeeList = new MultiSelectList((await _iDropdownService.EmployeeSelectionList())
                .Select(s => new { s.Id, s.Name }), "Id", "Name");
            AssembleWorkViewModel viewModel = new AssembleWorkViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddRecord(AssembleWorkViewModel viewModel)
        {
            var result = await _iService.AddRecord(viewModel);
            if (result == true)
            {
                return RedirectToAction(nameof(Search));
            }
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateRecord(long id)
        {
            ViewBag.AssembleWorkCategoryList = new SelectList((await _iDropdownService.AssembleWorkCategorySelectionList())
                .Select(s => new { s.Id, s.Name }), "Id", "Name");
            ViewBag.EmployeeList = new MultiSelectList((await _iDropdownService.EmployeeSelectionList())
               .Select(s => new { s.Id, s.Name }), "Id", "Name");
            var result = await _iService.GetRecordById(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRecord(AssembleWorkViewModel model)
        {
            var result = await _iService.UpdateRecord(model);
            if (result == true)
            {
                return RedirectToAction(nameof(Search));
            }
            ModelState.AddModelError(string.Empty, "Update operation failed. Please try again!");
            return RedirectToAction("UpdateRecord", new { id = model.Id });
            //return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(long id)
        {
            var res = await _iService.DeleteRecord(id);
            return RedirectToAction(nameof(Search));
        }


        [HttpGet]
        public async Task<IActionResult> MainDashboard()
        {
            var result = await _iService.MainDashboard();
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> EmployeeDashboard()
        {
            var dataList = await _iService.EmployeeDashboard();
            return View(dataList);
        }

        [HttpPost]
        public async Task<JsonResult> MakeStepItemComplete(long assembleWorkId, long assembleWorkDetailId, long assembleWorkCategoryId, long assembleWorkStepId, long assembleWorkStepItemId)
        {
            var result = await _iService.MakeStepItemComplete(assembleWorkId, assembleWorkDetailId, assembleWorkCategoryId, assembleWorkStepId, assembleWorkStepItemId);
            return Json(result);
        }

        [HttpPost]
        public async Task<JsonResult> MakeStatusComplete(long assembleWorkId)
        {
            var result = await _iService.MakeStatusComplete(assembleWorkId);
            return Json(result);
        }

        [HttpPost]
        public async Task<JsonResult> MakeStatusFault(long assembleWorkId)
        {
            var result = await _iService.MakeStatusFault(assembleWorkId);
            return Json(result);
        }

        #region Search

        [HttpGet]
        public async Task<IActionResult> Search()
        {
            ViewBag.AssembleWorkCategoryList = new SelectList((await _iDropdownService.AssembleWorkCategorySelectionList()).Select(s => new { s.Id, s.Name }), "Id", "Name");
            ViewBag.StatusList = new SelectList(_iUtilityService.GetEnumSelectionList<AssembleWorkStatusEnum>().Select(s => new { Id = s.Value, Name = s.Text }), "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Search(DataTablePagination<AssembleWorkSearchDto> searchDto)
        {
            var dataTable = await _iService.SearchAsync(searchDto);
            return Json(dataTable);
        }

        #endregion
    }
}
