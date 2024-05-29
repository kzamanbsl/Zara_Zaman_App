using app.EntityModel.DataTablePaginationModels;
using app.Services.ProductServices;
using app.Services.RolesServices;
using app.Services.UserServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace app.WebApp.AdminControllers
{
    public class UserController : Controller
    {
        private readonly IUserService _iUserService;   
        private readonly IRoleService _iRoleService;
        public UserController(IUserService iUserService, IRoleService iRoleService)
        {
            _iUserService = iUserService;
            _iRoleService = iRoleService;
        }

        #region User Section 

        [HttpGet]
        public async Task<IActionResult> AddRecord()
        {
            UserViewModel model = new UserViewModel();
            ViewBag.Record = new SelectList(_iRoleService.GetAllAsync().Select(s => new { Id = s.Name, Name = s.Name }), "Id", "Name");
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddRecord(UserViewModel model)
        {
            var result = await _iUserService.AddUser(model);
            if (result == false)
            {
                UserViewModel model2 = new UserViewModel();
                ViewBag.Record = new SelectList(_iRoleService.GetAllAsync().Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
                ModelState.AddModelError(string.Empty, "Same Email already exists!");
                return View(model2);
            }

            return RedirectToAction("Search");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateRecord(string id)
        {
            UserViewModel viewModel = new UserViewModel();
            ViewBag.Record = new SelectList(_iRoleService.GetAllAsync().Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            viewModel = await _iUserService.GetUserById(id);
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRecord(UserViewModel model)
        {
            var result = await _iUserService.UpdateUser(model);
            if (result == false)
            {
                UserViewModel model2 = new UserViewModel();
                ViewBag.Record = new SelectList(_iRoleService.GetAllAsync().Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
                ModelState.AddModelError(string.Empty, "Same Email already exists!");
                return View(model2);
            }

            return RedirectToAction("Search");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(UserSearchDto model)
        {
            var res = await _iUserService.SoftDelete(model.UserId);

            return RedirectToAction("Search");
        }

        [HttpGet]
        public async Task<IActionResult> Search()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Search(DataTablePagination<UserSearchDto> searchDto)
        {
            var dataTable = await _iUserService.SearchAsync(searchDto);
            return Json(dataTable);
        }

        #endregion

        #region Role Section   

        [HttpPost]
        public async Task<IActionResult> AddNewRole(RoleViewModel model)
        {
            var result = await _iRoleService.AddAsync(model);
            return View(result); 
        }


        #endregion


    }
}
