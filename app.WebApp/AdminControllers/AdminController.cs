using app.Services.UserPermissionsServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace app.WebApp.AdminControllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly IHttpContextAccessor _iHttpContextAccessor;
        public AdminController(IHttpContextAccessor iHttpContextAccessor)
        {
            _iHttpContextAccessor = iHttpContextAccessor;
        }

        public IActionResult Index()
        {
            string userName = HttpContext.Session.GetString("UserName");
            var serializedArrayFromSession = HttpContext.Session.GetString("ArrayData");
            if (serializedArrayFromSession != null)
            {
                var retrievedArray = JsonSerializer.Deserialize<MenuPermissionViewModel>(serializedArrayFromSession);
                // Now 'retrievedArray' contains the array of strings
            }
            return View();
        }
    }
}
