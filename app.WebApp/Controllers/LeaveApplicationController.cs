using app.EntityModel.AppModels;
using app.Services.DropdownServices;
using app.Services.LeaveApplicationServices;
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
            LeaveApplicationViewModel viewModel = new LeaveApplicationViewModel();
            return View(viewModel);
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
                return RedirectToAction("Index");
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
                return RedirectToAction("Index");
            }
            ModelState.AddModelError(string.Empty, "Same Name already exists!");
            return View(model);
        }

        [HttpGet]
        public async Task <ActionResult> ConfirmRecord(long id)
        {
            var res = await _iService.ConfirmRecord(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> ApproveRecord(long id)
        {
            var res = await _iService.ApproveRecord(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> RejectRecord(long id)
        {
            var res = await _iService.RejectRecord(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(long id)
        {
            var res = await _iService.DeleteRecord(id);
            return RedirectToAction("Index");
        }
    }
}
