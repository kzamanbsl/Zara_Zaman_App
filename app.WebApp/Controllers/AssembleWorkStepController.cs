using app.EntityModel.DataTablePaginationModels;
using app.Services.ATMAssemble.AssembleWorkCategoryServices;
using app.Services.ATMAssemble.AssembleWorkStepServices;
using app.Services.DropdownServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace app.WebApp.Controllers
{
    public class AssembleWorkStepController : Controller
    {

        private readonly IAssembleWorkStepService _iService;
        private readonly IDropdownService _iDropdownService;
        public AssembleWorkStepController(IAssembleWorkStepService iService, IDropdownService iDropdownService)
        {
            _iService = iService;
            _iDropdownService = iDropdownService;
        }

        [HttpGet]
        public async Task<IActionResult> AddRecord()
        {
            ViewBag.AssembleWorkCategoryList = new SelectList((await _iDropdownService.AssembleWorkCategorySelectionList())
                .Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            AssembleWorkStepViewModel viewModel = new AssembleWorkStepViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddRecord(AssembleWorkStepViewModel viewModel)
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
            ViewBag.AssembleWorkCategoryList = new SelectList((await _iDropdownService.AssembleWorkCategorySelectionList())
                .Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            var result = await _iService.GetRecordById(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRecord(AssembleWorkStepViewModel model)
        {
            var result = await _iService.UpdateRecord(model);
            if (result == true)
            {
                return RedirectToAction("Search");
            }
            ModelState.AddModelError(string.Empty, "This name is already used!");
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
            ViewBag.AssembleWorkCategoryList = new SelectList((await _iDropdownService.AssembleWorkCategorySelectionList())
               .Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Search(DataTablePagination<AssembleWorkStepSearchDto> searchDto)
        {
            var dataTable = await _iService.SearchAsync(searchDto);
            return Json(dataTable);
        }
        #endregion
    }
}
