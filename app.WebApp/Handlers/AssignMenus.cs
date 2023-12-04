using app.Infrastructure.Auth;
using app.Services.UserPermissionsServices;
using System.Text.Json;

namespace app.WebApp.Handlers
{
    public class AssignMenus : IAssignMenus
    {
        private readonly IHttpContextAccessor _iHttpContextAccessor;
        private readonly IWorkContext _iWorkContext;
        public AssignMenus(IHttpContextAccessor iHttpContextAccessor, IWorkContext iWorkContext)
        {
            _iHttpContextAccessor = iHttpContextAccessor;
            _iWorkContext = iWorkContext;
        }

        public async Task<MenuPermissionViewModel> MenuList()
        {
            MenuPermissionViewModel model = new MenuPermissionViewModel();
            string userName = _iHttpContextAccessor.HttpContext?.Session.GetString("UserName");
            var serializedArrayFromSession = _iHttpContextAccessor.HttpContext?.Session.GetString("ArrayData");
            var res = await _iWorkContext.GetCurrentUserAsync();
            if (serializedArrayFromSession != null)
            {
                model = JsonSerializer.Deserialize<MenuPermissionViewModel>(serializedArrayFromSession);
            }
            return model;
        }
    }
}
