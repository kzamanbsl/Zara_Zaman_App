using app.Services.CompanyServices;
using app.Services.LeaveBalanceServices;
using Microsoft.AspNetCore.Mvc;

namespace app.WebApp.Controllers
{
    public class LeaveBalanceController : Controller
    {

        private readonly ILeaveBalanceService _iService;
        public LeaveBalanceController(ILeaveBalanceService iService)
        {
            _iService = iService;
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
            LeaveBalanceViewModel viewModel = new LeaveBalanceViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddRecord(LeaveBalanceViewModel viewModel)
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
            var result = await _iService.GetRecordById(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRecord(LeaveBalanceViewModel model)
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
