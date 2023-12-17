using app.Services.CompanyServices;
using app.Services.AttendanceServices;
using Microsoft.AspNetCore.Mvc;
using app.Services.DropdownServices;
using Microsoft.AspNetCore.Mvc.Rendering;
using app.Services.AttendanceLogServices;

namespace app.WebApp.Controllers
{
    public class AttendanceController : Controller
    {

        private readonly IAttendanceService _iService;
        private readonly IDropdownService _dropdownService;
        private readonly IAttendanceLogService _attendanceLogService;

        public AttendanceController(IAttendanceService iService , IDropdownService dropdownService, IAttendanceLogService attendanceLogService)
        {
            _iService = iService;
            _dropdownService = dropdownService;
            _attendanceLogService = attendanceLogService;
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

            ViewBag.Employees = new SelectList((await _dropdownService.EmployeeSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            ViewBag.Shifts = new SelectList((await _dropdownService.ShiftSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            AttendanceViewModel viewModel = new AttendanceViewModel();

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddRecord(AttendanceViewModel viewModel)
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
            ViewBag.Employees = new SelectList((await _dropdownService.EmployeeSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            ViewBag.Shifts = new SelectList((await _dropdownService.ShiftSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            var result = await _iService.GetRecordById(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRecord(AttendanceViewModel model)
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
