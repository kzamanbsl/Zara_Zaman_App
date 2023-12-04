namespace app.Services.MenuItemServices
{
    public interface IMenuItemService
    {
        Task<bool> AddRecord(MenuItemViewModel model);
        Task<MenuItemViewModel> GetAllRecord();
        Task<bool> UpdateRecord(MenuItemViewModel model);
        Task<bool> DeleteRecord(long id);
        Task<MenuItemViewModel> GetRecordById(long id);
    }
}
