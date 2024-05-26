using app.EntityModel.DataTablePaginationModels;
using app.Services.DepartmentServices;
using app.Services.DesignationServices;
using app.Services.ServiceCenterServices;
using Microsoft.AspNetCore.Mvc;

namespace app.WebApp.Controllers
{
    public class ServiceCenterController : Controller
    {

        private readonly IServiceCenterService _iService;
        public ServiceCenterController(IServiceCenterService iService)
        {
            _iService = iService;
        }

        [HttpGet]
        public async Task<IActionResult> AddRecord()
        {
            ServiceCenterViewModel viewModel = new ServiceCenterViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddRecord(ServiceCenterViewModel viewModel)
        {
            var result = await _iService.AddRecord(viewModel);
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
            var result = await _iService.GetRecordById(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRecord(ServiceCenterViewModel model)
        {
            var result = await _iService.UpdateRecord(model);
            if (result == true)
            {
                return RedirectToAction("Search");
            }
            ModelState.AddModelError(string.Empty, "Same Name already exists!");
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ServiceCenterSearchDto model)
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
        public async Task<IActionResult> Search(DataTablePagination<ServiceCenterSearchDto> searchDto)
        {
            var dataTable = await _iService.SearchAsync(searchDto);
            return Json(dataTable);
        }
        #endregion
    }
}
