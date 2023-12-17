namespace app.Services.DropdownItemServices
{
    public interface IDropdownItemService
    {
        Task<bool> AddRecord(DropdownItemViewModel vm);
        Task<bool> UpdateRecord(DropdownItemViewModel vm);
        Task<DropdownItemViewModel> GetRecordById(long id);
        Task<DropdownItemViewModel> GetAllRecord();
        Task<bool> DeleteRecord(long id);
       
    }
}
