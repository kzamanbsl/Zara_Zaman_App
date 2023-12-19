using app.Services.MainMenuServices;
using app.Services.MenuItemServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace app.WebApp.AdminControllers
{
    [Authorize]
    public class MenuItemController : Controller
    {
        private readonly IMenuItemService _iService;
        private readonly IMainMenuService _iMainMenuService;
        public MenuItemController(IMenuItemService iService, IMainMenuService iMainMenuService)
        {
            _iService = iService;
            _iMainMenuService = iMainMenuService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            MenuItemViewModel menuItemViewModel = new MenuItemViewModel();
            menuItemViewModel = await _iService.GetAllRecord();
            return View(menuItemViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> AddRecord()
        {
            MenuItemViewModel menuItemViewModel = new MenuItemViewModel();
            ViewBag.Record = new SelectList((await _iMainMenuService.GetAllRecord()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            return View(menuItemViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddRecord(MenuItemViewModel model)
        {
            var result = await _iService.AddRecord(model);
            if (result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Same Name Action Controller already exists!");
                MenuItemViewModel menuItemViewModel = new MenuItemViewModel();
                ViewBag.Record = new SelectList((await _iMainMenuService.GetAllRecord()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
                return View(menuItemViewModel);
            }

        }

        [HttpGet]
        public async Task<IActionResult> Delete(long id)
        {
            var res = await _iService.DeleteRecord(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateRecord(long id)
        {
            MenuItemViewModel menuItemViewModel = new MenuItemViewModel();
            ViewBag.Record = new SelectList((await _iMainMenuService.GetAllRecord()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            menuItemViewModel = await _iService.GetRecordById(id);
            return View(menuItemViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRecord(MenuItemViewModel viewModel)
        {
            var result = await _iService.UpdateRecord(viewModel);
            if (result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Same Name Action Controller already exists!");
                MenuItemViewModel menuItemViewModel = new MenuItemViewModel();
                ViewBag.Recort = new SelectList((await _iMainMenuService.GetAllRecord()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
                return View(menuItemViewModel);
            }
        }

        [HttpGet]
        public async Task<IActionResult> MenuHide(long id)
        {
            var res = await _iService.MenuShowSideBar(id);
            return RedirectToAction("Index");
        }

    }
}

