namespace app.Services.ShiftServices
{
    public interface IShiftService
    {
        Task<ShiftViewModel> GetAllRecord(); 
        Task<int> AddRecord(ShiftViewModel model);
        Task<int> UpdateRecord(ShiftViewModel model);
        Task<bool> DeleteRecord(long id);
        Task<ShiftViewModel> GetRecordById(long id);
    }
}
