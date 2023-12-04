using app.Services.MainMenuServices;
using app.Services.UserPermissionsServices;
using app.Services.UserServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace app.WebApp.AdminControllers
{
    [Authorize]
    public class UserPermissionController : Controller
    {
        private readonly IUserPermissionService _iService;
        private readonly IMainMenuService _iMainMenuService;
        private readonly IUserService _iUserService;
        public UserPermissionController(IUserPermissionService iService, IMainMenuService iMainMenuService, IUserService iUserService)
        {
            _iService = iService;
            _iMainMenuService = iMainMenuService;
            _iUserService = iUserService;
        }

        [HttpGet]
        public async Task<IActionResult> AddPermission(string id)
        {
            ViewBag.Record = await _iUserService.GetAllRecord();
            var result = await _iService.GetAllRecordByUserId(id);
            result.UserId = id;
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> ChangePermission(long id, string userid)
        {
            var result = await _iService.AddRecord(id, userid);
            return Json(result);
        }
    }
}
