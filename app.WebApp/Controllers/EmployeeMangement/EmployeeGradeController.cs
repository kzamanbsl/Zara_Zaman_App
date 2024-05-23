using app.EntityModel.DataTablePaginationModels;
using app.Services.CompanyServices;
using app.Services.DesignationServices;
using app.Services.EmployeeGradeServices;
using app.Services.ProductServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace app.WebApp.Controllers.EmployeeMangement
{
    public class EmployeeGradeController : Controller
    {

        private readonly IEmployeeGradeService _iService;
        public EmployeeGradeController(IEmployeeGradeService iService)
        {
            _iService = iService;
        }

        [HttpGet]
        public async Task<IActionResult> AddRecord()
        {
            EmployeeGradeViewModel viewModel = new EmployeeGradeViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddRecord(EmployeeGradeViewModel viewModel)
        {
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
            var result = await _iService.GetRecordById(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRecord(EmployeeGradeViewModel model)
        {
            var result = await _iService.UpdateRecord(model);
            if (result == true)
            {
                return RedirectToAction(nameof(Search));
            }
            ModelState.AddModelError(string.Empty, "Same Name already exists!");
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Delete(EmployeeGradeSearchDto model)
        {
            var res = await _iService.DeleteRecord(model.Id ?? 0);
            return RedirectToAction("Search");
        }

        #region Search
        [HttpGet]
        public async Task<IActionResult> Search()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Search(DataTablePagination<EmployeeGradeSearchDto> searchDto)
        {
            var dataTable = await _iService.SearchAsync(searchDto);
            return Json(dataTable);
        }
        #endregion

    }
}
