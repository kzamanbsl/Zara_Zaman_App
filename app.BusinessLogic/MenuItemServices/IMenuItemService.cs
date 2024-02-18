namespace app.Services.MenuItemServices
{
    public interface IMenuItemService
    {
        Task<bool> AddRecord(MenuItemViewModel vm);
        Task<bool> UpdateRecord(MenuItemViewModel vm);
        Task<MenuItemViewModel> GetRecordById(long id);
        Task<bool> DeleteRecord(long id);
        Task<bool> MenuShowSideBar(long id);
        Task<MenuItemViewModel> GetAllRecord();

    }
}
