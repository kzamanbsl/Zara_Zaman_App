using Microsoft.AspNetCore.Mvc;
using app.WebApp.Models;
using app.Services.UserServices;
using app.Infrastructure.Auth;
using System.Text.Json;
using Microsoft.AspNetCore.Identity;
using app.Services.UserPermissionsServices;

namespace app.WebApp.Controllers.Authentication
{
    public class AccountController : Controller
    {
        private readonly IUserService _iUserService;
        private readonly IUserPermissionService _iUserPermissionService;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public AccountController(IUserService iUserService, IUserPermissionService iUserPermissionService, SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
            _iUserService = iUserService;
            _iUserPermissionService = iUserPermissionService;
        }

        [HttpGet]
        public Task<IActionResult> Login()
        {
            LoginViewModel model = new LoginViewModel();
            return Task.FromResult<IActionResult>(View(model));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var user = await _iUserService.GetUserByEmail(model.Email);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "User not found");
                return View(model);

            }
            var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
            if (result.Succeeded)
            {
                var getItem = await _iUserPermissionService.GetAllMenuItemRecordByUserId(user.Id);
                HttpContext.Session.SetString("UserName", user.UserName.ToString());
                var array = JsonSerializer.Serialize(getItem);
                HttpContext.Session.SetString("ArrayData", array);
                return Redirect("/Admin/Index");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Password is not verified!");
                return View(model);
            }

        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            if (!_signInManager.IsSignedIn(User)) return Redirect("Login");

            await _signInManager.SignOutAsync();
            HttpContext.Session.Clear();
            return Redirect("Login");
        }
    }
}
