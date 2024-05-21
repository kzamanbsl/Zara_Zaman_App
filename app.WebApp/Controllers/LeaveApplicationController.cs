using app.EntityModel.DataTablePaginationModels;
using app.Services.DropdownServices;
using app.Services.LeaveApplicationServices;
using app.Utility;
using app.Utility.UtilityServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace app.WebApp.Controllers
{
    public class LeaveApplicationController : Controller
    {

        private readonly ILeaveApplicationService _iService;
        private readonly IDropdownService _iDropdownService;
        private readonly IUtilityService _iUtilityService;
        public LeaveApplicationController(ILeaveApplicationService iService, IDropdownService dropdownService, IUtilityService iUtilityService)
        {
            _iService = iService;
            _iDropdownService = dropdownService;
            _iUtilityService = iUtilityService;
        }

        [HttpGet]
        public async Task<IActionResult> Details(long id)
        {
            
            if (id == 0)
            {
                return NotFound();
            }

            var leaveApplicationVm = await _iService.GetRecordById(id);
            var empLeaveBalanceList = await _iService.GetLeaveBalanceByEmployeeId(leaveApplicationVm.EmployeeId);
            leaveApplicationVm.LeaveBalanceCountList = empLeaveBalanceList;

            return View(leaveApplicationVm);
        }

        [HttpGet]
        public async Task<IActionResult> AddRecord()
        {

            ViewBag.LeaveCategories = new SelectList((await _iDropdownService.LeaveCategorySelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            ViewBag.Employees = new SelectList((await _iDropdownService.EmployeeSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            ViewBag.Managers = new SelectList((await _iDropdownService.EmployeeSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            ViewBag.Status = new SelectList((_iUtilityService.GetEnumSelectionList<LeaveApplicationStatusEnum>()).Select(s => new { Id = s.Value, Name = s.Text }), "Id", "Name");
            
            var leaveApplicationVm = new LeaveApplicationViewModel(); 
            var empLeaveBalanceList = await _iService.GetLeaveBalanceByEmployeeId(leaveApplicationVm.EmployeeId);
            leaveApplicationVm.LeaveBalanceCountList = empLeaveBalanceList;
            return View(leaveApplicationVm);
        }

        [HttpPost]
        public async Task<IActionResult> AddRecord(LeaveApplicationViewModel viewModel)
        {
            //ViewBag.Status = new SelectList(Enum.GetValues(typeof(LeaveApplicationStatusEnum))
            //                      .Cast<LeaveApplicationStatusEnum>()
            //                      .Select(e => new SelectListItem
            //                      {
            //                          Value = ((int)e).ToString(),
            //                          Text = e.ToString()
            //                      }), "Value", "Text", viewModel.StatusName);
            ViewBag.Status = new SelectList((_iUtilityService.GetEnumSelectionList<LeaveApplicationStatusEnum>()).Select(s => new { Id = s.Value, Name = s.Text }), "Id", "Name");

            var result = await _iService.AddRecord(viewModel);
            if (result == true)
            {
                return RedirectToAction(nameof(Search));
            }
            ModelState.AddModelError(string.Empty, "Same Name already exists!");
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateRecord(long id)
        {
            ViewBag.LeaveCategories = new SelectList((await _iDropdownService.LeaveCategorySelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            ViewBag.Employees = new SelectList((await _iDropdownService.EmployeeSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            ViewBag.Managers = new SelectList((await _iDropdownService.EmployeeSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            
            var result = await _iService.GetRecordById(id);
            var empLeaveBalanceList = await _iService.GetLeaveBalanceByEmployeeId(result.EmployeeId);
            result.LeaveBalanceCountList = empLeaveBalanceList;
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRecord(LeaveApplicationViewModel model)
        {
            var result = await _iService.UpdateRecord(model);
            if (result ==true)
            {
                return RedirectToAction(nameof(Search));
            }
            ModelState.AddModelError(string.Empty, "Same Name already exists!");
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmRecord(long id)
        {
            var res = await _iService.ConfirmRecord(id);
            return RedirectToAction(nameof(Details), new {id=id});
        }

        [HttpPost]
        public async Task<ActionResult> ApproveRecord(long id)
        {
            var res = await _iService.ApproveRecord(id);
            return RedirectToAction(nameof(Details), new { id = id });
        }

        [HttpPost]
        public async Task<ActionResult> RejectRecord(long id)
        {
            var res = await _iService.RejectRecord(id);
            return RedirectToAction(nameof(Details), new { id = id });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(long id)
        {
            var res = await _iService.DeleteRecord(id);
            return RedirectToAction(nameof(Search));
        }

        #region Search

        [HttpGet]
        public async Task<IActionResult> Search()
        {
            ViewBag.Employees = new SelectList((await _iDropdownService.EmployeeSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            ViewBag.LeaveCategories = new SelectList((await _iDropdownService.LeaveCategorySelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            ViewBag.Status = new SelectList((_iUtilityService.GetEnumSelectionList<LeaveApplicationStatusEnum>()).Select(s => new { Id = s.Value, Name = s.Text }), "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Search(DataTablePagination<LeaveApplicationSearchDto> searchDto)
        {
            var dataTable = await _iService.SearchAsync(searchDto);
            return Json(dataTable);
        }

        #endregion
    }
}
