namespace app.Services.AttendanceServices
{
    public interface IAttendanceService
    {
        Task<bool> AddRecord(AttendanceViewModel vm);
        Task<bool> UpdateRecord(AttendanceViewModel vm);
        Task<AttendanceViewModel> GetRecordById(long id);
        Task<AttendanceViewModel> GetAllRecord();
        Task<bool> DeleteRecord(long id);
    
    }
}
