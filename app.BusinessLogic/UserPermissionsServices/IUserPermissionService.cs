namespace app.Services.UserPermissionsServices
{
    public interface IUserPermissionService
    {
        Task<object> AddRecord(long id,string userId);
        Task<UserPermissionViewModel> GetAllRecordByUserId(string userId);
        Task<MenuPermissionViewModel> GetAllMenuItemRecordByUserId(string userId);

    }
}
