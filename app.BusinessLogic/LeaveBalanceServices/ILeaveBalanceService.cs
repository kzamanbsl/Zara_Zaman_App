namespace app.Services.LeaveBalanceServices
{
    public interface ILeaveBalanceService
    {
        Task<LeaveBalanceViewModel> GetAllRecord();
        Task<int> AddRecord(LeaveBalanceViewModel model);
        Task<int> UpdateRecord(LeaveBalanceViewModel model);
        Task<bool> DeleteRecord(long id);
        Task<LeaveBalanceViewModel> GetRecordById(long id);
    }
}
