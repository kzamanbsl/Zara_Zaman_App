using app.EntityModel.AppModels;
using app.EntityModel.DataTablePaginationModels;
using app.Infrastructure.Migrations;
using app.Services.DropdownServices;
using app.Services.LeaveApplicationServices;
using app.Services.LeaveBalanceServices;
using app.Services.ProductServices;
using app.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace app.WebApp.Controllers
{
    public class LeaveApplicationController : Controller
    {

        private readonly ILeaveApplicationService _iService;
        private readonly IDropdownService _dropdownService;
        public LeaveApplicationController(ILeaveApplicationService iService, IDropdownService dropdownService)
        {
            _iService = iService;
            _dropdownService = dropdownService;
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

            ViewBag.LeaveCategories = new SelectList((await _dropdownService.LeaveCategorySelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            ViewBag.Employees = new SelectList((await _dropdownService.EmployeeSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            ViewBag.Managers = new SelectList((await _dropdownService.EmployeeSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            ViewBag.Status = new SelectList(Enum.GetValues(typeof(LeaveApplicationStatusEnum))
                                   .Cast<LeaveApplicationStatusEnum>()
                                   .Select(e => new SelectListItem
                                   {
                                       Value = ((int)e).ToString(),
                                       Text = e.ToString()
                                   }), "Value", "Text");

            var leaveApplicationVm = new LeaveApplicationViewModel(); 
            var empLeaveBalanceList = await _iService.GetLeaveBalanceByEmployeeId(leaveApplicationVm.EmployeeId);
            leaveApplicationVm.LeaveBalanceCountList = empLeaveBalanceList;
            return View(leaveApplicationVm);
        }
        [HttpPost]
        public async Task<IActionResult> AddRecord(LeaveApplicationViewModel viewModel)
        {
            ViewBag.Status = new SelectList(Enum.GetValues(typeof(LeaveApplicationStatusEnum))
                                  .Cast<LeaveApplicationStatusEnum>()
                                  .Select(e => new SelectListItem
                                  {
                                      Value = ((int)e).ToString(),
                                      Text = e.ToString()
                                  }), "Value", "Text", viewModel.StatusName);
            var result = await _iService.AddRecord(viewModel);
            if (result == true)
            {
                return RedirectToAction(nameof(Index));
            }
            ModelState.AddModelError(string.Empty, "Same Name already exists!");
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateRecord(long id)
        {
            ViewBag.LeaveCategories = new SelectList((await _dropdownService.LeaveCategorySelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            ViewBag.Employees = new SelectList((await _dropdownService.EmployeeSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            ViewBag.Managers = new SelectList((await _dropdownService.EmployeeSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            var result = await _iService.GetRecordById(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRecord(LeaveApplicationViewModel model)
        {
            var result = await _iService.UpdateRecord(model);
            if (result ==true)
            {
                return RedirectToAction(nameof(Index));
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
            return RedirectToAction(nameof(Index));
        }

        #region Search

        [HttpGet]
        public async Task<IActionResult> Search()
        {
            ViewBag.Employees = new SelectList((await _dropdownService.EmployeeSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            ViewBag.LeaveCategories = new SelectList((await _dropdownService.LeaveCategorySelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
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
