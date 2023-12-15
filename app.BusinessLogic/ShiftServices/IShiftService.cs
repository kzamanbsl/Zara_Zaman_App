namespace app.Services.ShiftServices
{
    public interface IShiftService
    {
       
        Task<bool> AddRecord(ShiftViewModel vm);
        Task<bool> UpdateRecord(ShiftViewModel vm);

        Task<ShiftViewModel> GetRecordById(long id);
        Task<ShiftViewModel> GetAllRecord();
        Task<bool> DeleteRecord(long id);
    }
}
