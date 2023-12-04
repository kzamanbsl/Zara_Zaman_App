using app.Services.UserPermissionsServices;

namespace app.WebApp.Handlers
{
    public interface IAssignMenus
    {
        Task<MenuPermissionViewModel> MenuList();
    }
}
