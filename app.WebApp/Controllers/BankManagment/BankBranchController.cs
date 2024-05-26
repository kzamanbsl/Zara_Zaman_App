using app.EntityModel.DataTablePaginationModels;
using app.Services.BankBranchServices;
using app.Services.DesignationServices;
using app.Services.DropdownItemServices;
using app.Services.DropdownServices;
using app.Services.JobStatusServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace app.WebApp.Controllers.BankManagment
{
    public class BankBranchController : Controller
    {
        public readonly IBankBranchService _bankBranchService;
        public readonly IDropdownService _dropdownService;

        public BankBranchController( IBankBranchService bankBranchService,IDropdownService dropdownService)
        {
            _bankBranchService = bankBranchService;
            _dropdownService= dropdownService;
        }


        [HttpGet]
        public async Task<IActionResult> AddRecord()
        {
            BankBranchViewModel viewModel = new BankBranchViewModel();
            ViewBag.BankList = new SelectList(await  _dropdownService.BankSelectionList(),"Id", "Name"); 
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddRecord(BankBranchViewModel viewModel)
        {
            var result = await _bankBranchService.AddRecord(viewModel);
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
            var result = await _bankBranchService.GetRecordById(id);
            ViewBag.BankList = new SelectList(await _dropdownService.BankSelectionList(), "Id", "Name");
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRecord(BankBranchViewModel model)
        {
            var result = await _bankBranchService.UpdateRecord(model);
            if (result == true)
            {
                return RedirectToAction("Search");
            }
            ModelState.AddModelError(string.Empty, "Same Name already exists!");
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(BankBranchSearchDto model)
        {
            var res = await _bankBranchService.DeleteRecord(model.Id ?? 0);
            return RedirectToAction("Search");
        }


        #region Search
        [HttpGet]
        public async Task<IActionResult> Search()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Search(DataTablePagination<BankBranchSearchDto> searchDto)
        {
            var dataTable = await _bankBranchService.SearchAsync(searchDto);
            return Json(dataTable);
        }
        #endregion
    }
}
