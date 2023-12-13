namespace app.Services.AttendanceLogServices
{
    public interface IAttendanceLogService
    {
        Task<AttendanceLogViewModel> GetAllRecord();
        Task<int> AddRecord(AttendanceLogViewModel model);
        Task<int> UpdateRecord(AttendanceLogViewModel model);
        Task<bool> DeleteRecord(long id);
        Task<AttendanceLogViewModel> GetRecordById(long id);
    }
}
