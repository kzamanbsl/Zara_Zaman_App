using app.EntityModel.DataTablePaginationModels;
using app.Services.MainMenuServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace app.WebApp.AdminControllers
{
   // [Authorize("kgecomAuthorizatio")]
    public class MainMenuController : Controller
    {
        private readonly IMainMenuService _iService;
        public MainMenuController(IMainMenuService iService)
        {
            _iService = iService;
        }


        [HttpGet]
        public IActionResult AddRecord()
        {
            MainMenuViewModel viewModel = new MainMenuViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddRecord(MainMenuViewModel viewModel)
        {
            var result = await _iService.AddRecord(viewModel);
            if (result)
            {
                return RedirectToAction("Search");
            }
            ModelState.AddModelError(string.Empty, "Same Name already exists!");
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateRecord(long id)
        {
            MainMenuViewModel viewModel = new MainMenuViewModel();
            viewModel= await _iService.GetRecordById(id);


            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRecord(MainMenuViewModel viewModel)
        {
            var result = await _iService.UpdateRecord(viewModel);
            if (result)
            {
                return RedirectToAction("Search");
            }
            ModelState.AddModelError(string.Empty, "Same Name already exists!");
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(MainMenuSearchDto model)
        {
            var res = await _iService.DeleteRecord(model.Id);
            return RedirectToAction("Search");
        }


        [HttpGet]
        public async Task<IActionResult> Search()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Search(DataTablePagination<MainMenuSearchDto> searchDto)
        {
            var dataTable = await _iService.SearchAsync(searchDto);
            return Json(dataTable);
        }

    }
}
