namespace app.Services.AttendanceServices
{
    public interface IAttendanceService
    {
        Task<AttendanceViewModel> GetAllRecord();
        Task<int> AddRecord(AttendanceViewModel model);
        Task<int> UpdateRecord(AttendanceViewModel model);
        Task<bool> DeleteRecord(long id);
        Task<AttendanceViewModel> GetRecordById(long id);
    }
}
