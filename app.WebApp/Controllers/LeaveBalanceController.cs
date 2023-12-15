using app.Services.CompanyServices;
using app.Services.DropdownServices;
using app.Services.LeaveBalanceServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace app.WebApp.Controllers
{
    public class LeaveBalanceController : Controller
    {

        private readonly ILeaveBalanceService _iService;
        private readonly IDropdownService _iDropdownService;
        public LeaveBalanceController(ILeaveBalanceService iService,IDropdownService iDropdownService)
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
        public async Task<IActionResult> AddRecord()
        {
            ViewBag.leaveCategory = new SelectList((await _iDropdownService.LeaveCategorySelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            LeaveBalanceViewModel viewModel = new LeaveBalanceViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddRecord(LeaveBalanceViewModel viewModel)
        {
            var result = await _iService.AddRecord(viewModel);
            if (result ==true)
            {
                return RedirectToAction("Index");
            }
            ModelState.AddModelError(string.Empty, "Same Name already exists!");
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateRecord(long id)
        {
            ViewBag.leaveCategory = new SelectList((await _iDropdownService.LeaveCategorySelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            var result = await _iService.GetRecordById(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRecord(LeaveBalanceViewModel model)
        {
            var result = await _iService.UpdateRecord(model);
            if (result == true)
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
