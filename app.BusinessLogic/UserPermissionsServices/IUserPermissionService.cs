namespace app.Services.UserPermissionsServices
{
    public interface IUserPermissionService
    {
        Task<bool> AddRecord(long id,string userId);
        Task<UserPermissionViewModel> GetAllRecordByUserId(string userId);
        Task<MenuPermissionViewModel> GetAllMenuItemRecordByUserId(string userId);

    }
}
