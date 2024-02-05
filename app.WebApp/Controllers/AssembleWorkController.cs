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
                return RedirectToAction("AddRecord");
            }
            return View(viewModel);
        }
    }
}
