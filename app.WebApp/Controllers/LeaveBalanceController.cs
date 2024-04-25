using app.EntityModel.DataTablePaginationModels;
using app.Services.CompanyServices;
using app.Services.DropdownServices;
using app.Services.LeaveBalanceServices;
using app.Services.ProductServices;
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
        public async Task<IActionResult> AddRecord()
        {
            ViewBag.LeaveCategoryList = new SelectList((await _iDropdownService.LeaveCategorySelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            LeaveBalanceViewModel viewModel = new LeaveBalanceViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddRecord(LeaveBalanceViewModel viewModel)
        {
            var result = await _iService.AddRecord(viewModel);
            if (result ==true)
            {
                return RedirectToAction("Search");
            }
            ModelState.AddModelError(string.Empty, "Same Name already exists!");
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateRecord(long id)
        {
            ViewBag.LeaveCategoryList = new SelectList((await _iDropdownService.LeaveCategorySelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            var result = await _iService.GetRecordById(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRecord(LeaveBalanceViewModel model)
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
            ViewBag.LeaveCategoryList = new SelectList((await _iDropdownService.LeaveCategorySelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Search(DataTablePagination<LeaveBalanceSearchDto> searchDto)
        {
            var dataTable = await _iService.SearchAsync(searchDto);
            return Json(dataTable);
        }

        #endregion
    }
}
