using app.EntityModel.AppModels.ATMAssemble;
using app.Services.ATMAssemble.AssembleWorkServices;
using app.Services.DropdownServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace app.WebApp.Controllers
{
    public class AssembleWorkController : Controller
    {
        private readonly IAssembleWorkService _iService;
        private readonly IDropdownService _iDropdownService;

        public AssembleWorkController(IAssembleWorkService iService, IDropdownService iDropdownService)
        {
            _iService = iService;
            _iDropdownService = iDropdownService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _iService.GetAllRecord();
            return View(result);
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
                .Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            ViewBag.EmployeeList = new MultiSelectList((await _iDropdownService.EmployeeSelectionList())
                .Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            AssembleWorkViewModel viewModel = new AssembleWorkViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddRecord(AssembleWorkViewModel viewModel)
        {
            var result = await _iService.AddRecord(viewModel);
            if (result == true)
            {
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateRecord(long id)
        {
            ViewBag.AssembleWorkCategoryList = new SelectList((await _iDropdownService.AssembleWorkCategorySelectionList())
                .Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            ViewBag.EmployeeList = new MultiSelectList((await _iDropdownService.EmployeeSelectionList())
               .Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            // AssembleWorkViewModel viewModel = new AssembleWorkViewModel();
            var result = await _iService.GetRecordById(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRecord(AssembleWorkViewModel model)
        {
            var result = await _iService.UpdateRecord(model);
            if (result == true)
            {
                return RedirectToAction("Index");
            }
            ModelState.AddModelError(string.Empty, "This name is already used!");
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(long id)
        {
            var res = await _iService.DeleteRecord(id);
            return RedirectToAction("Index");
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
    }
}
