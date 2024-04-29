using app.Services.AttendanceServices;
using Microsoft.AspNetCore.Mvc;
using app.Services.DropdownServices;
using Microsoft.AspNetCore.Mvc.Rendering;
using app.Services.AttendanceLogServices;
using app.EntityModel.AppModels;
using app.WebApp.Models;
using app.EntityModel.DataTablePaginationModels;
using app.Services.ProductServices;

namespace app.WebApp.Controllers
{
    public class AttendanceController : Controller
    {

        private readonly IAttendanceService _iService;
        private readonly IDropdownService _iDropdownService;
        public AttendanceController(IAttendanceService iService, IDropdownService iDropdownService)
        {
            _iService = iService;
            _iDropdownService = iDropdownService;
        }

        [HttpGet]
        public async Task<JsonResult> CheckEmployeeTodaysAttendance(long employeeId, DateTime date)
        {
            var data = await _iService.CheckEmployeeTodaysAttendance(employeeId, date);
            
            return Json(data);
        }

        [HttpGet]
        public async Task<IActionResult> AddRecord()
        {
            ViewBag.Employees = new SelectList((await _iDropdownService.EmployeeSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");

            ViewBag.Shifts = new SelectList((await _iDropdownService.ShiftSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            AttendanceViewModel viewModel = new AttendanceViewModel();
            viewModel.AttendanceDate = DateTime.Now;
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddRecord(AttendanceViewModel viewModel)
        {

            bool result = false;
            if(viewModel.Id > 0)
            {
                result = await _iService.UpdateRecord(viewModel);
            }
            else
            {
                result = await _iService.AddRecord(viewModel);
            }

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
            ViewBag.Employees = new SelectList((await _iDropdownService.EmployeeSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            ViewBag.Shifts = new SelectList((await _iDropdownService.ShiftSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            var result = await _iService.GetRecordById(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRecord(AttendanceViewModel model)
        {
            var result = await _iService.UpdateRecord(model);
            if (result == true)
            {
                return RedirectToAction("Search");
            }
            ModelState.AddModelError(string.Empty, "Same Name already exists!");
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
            ViewBag.Employees = new SelectList((await _iDropdownService.EmployeeSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            ViewBag.Shifts = new SelectList((await _iDropdownService.ShiftSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Search(DataTablePagination<AttendanceSearchDto> searchDto)
        {
            var dataTable = await _iService.SearchAsync(searchDto);
            return Json(dataTable);
        }

        #endregion
    }
}
