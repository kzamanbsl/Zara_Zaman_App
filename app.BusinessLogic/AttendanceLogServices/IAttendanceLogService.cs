namespace app.Services.AttendanceLogServices
{
    public interface IAttendanceLogService
    {
        Task<bool> AddRecord(AttendanceLogViewModel vm);
        Task<bool> UpdateRecord(AttendanceLogViewModel vm);
        Task<AttendanceLogViewModel> GetRecordById(long id);
        Task<AttendanceLogViewModel> GetAllRecord();
        Task<bool> DeleteRecord(long id);
        //Task<bool> IsExist(int id);
    }
}
