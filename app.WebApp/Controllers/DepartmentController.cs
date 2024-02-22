using app.EntityModel.DataTablePaginationModels;
using app.Services.DepartmentServices;
using app.Services.DesignationServices;
using Microsoft.AspNetCore.Mvc;

namespace app.WebApp.Controllers
{
    public class DepartmentController : Controller
    {

        private readonly IDepartmentService _iService;
        public DepartmentController(IDepartmentService iService)
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
            DepartmentViewModel viewModel = new DepartmentViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddRecord(DepartmentViewModel viewModel)
        {
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
            var result = await _iService.GetRecordById(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRecord(DepartmentViewModel model)
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

        #region Search
        [HttpGet]
        public async Task<IActionResult> Search()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Search(DataTablePagination<DepartmentSearchDto> searchDto)
        {
            var dataTable = await _iService.SearchAsync(searchDto);
            return Json(dataTable);
        }
        #endregion
    }
}
