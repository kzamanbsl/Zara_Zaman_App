using app.Services.CompanyServices;
using app.Services.AttendanceLogServices;
using Microsoft.AspNetCore.Mvc;
using app.Services.DropdownServices;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace app.WebApp.Controllers
{
    public class AttendanceLogController : Controller
    {

        private readonly IAttendanceLogService _iService;
        private readonly IDropdownService _dropdownService;
        public AttendanceLogController(IAttendanceLogService iService , IDropdownService dropdownService)
        {
            _iService = iService;
            _dropdownService=dropdownService;
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
            ViewBag.Employee = new SelectList((await _dropdownService.EmployeeSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");

            AttendanceLogViewModel viewModel = new AttendanceLogViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddRecord(AttendanceLogViewModel viewModel)
        {
            var result = await _iService.AddRecord(viewModel);
            if (result == 2)
            {
                return RedirectToAction("Index");
            }
            ModelState.AddModelError(string.Empty, "Same Name already exists!");
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateRecord(long id)
        {
            ViewBag.Employee = new SelectList((await _dropdownService.EmployeeSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");

            var result = await _iService.GetRecordById(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRecord(AttendanceLogViewModel model)
        {
            var result = await _iService.UpdateRecord(model);
            if (result == 2)
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
