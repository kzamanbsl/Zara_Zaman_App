namespace app.Services.LeaveBalanceServices
{
    public interface ILeaveBalanceService
    {
       
        Task<bool> AddRecord(LeaveBalanceViewModel vm);
        Task<bool> UpdateRecord(LeaveBalanceViewModel vm);
        Task<LeaveBalanceViewModel> GetRecordById(long id);
        Task<LeaveBalanceViewModel> GetAllRecord();
        Task<bool> DeleteRecord(long id);

    }
}
