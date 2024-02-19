using app.EntityModel.DataTablePaginationModels;
using app.Services.ProductServices;

namespace app.Services.LeaveBalanceServices
{
    public interface ILeaveBalanceService
    {
       
        Task<bool> AddRecord(LeaveBalanceViewModel vm);
        Task<bool> UpdateRecord(LeaveBalanceViewModel vm);
        Task<LeaveBalanceViewModel> GetRecordById(long id);
        Task<bool> DeleteRecord(long id);
        Task<LeaveBalanceViewModel> GetAllRecord();
        Task<DataTablePagination<LeaveBalanceSearchDto>> SearchAsync(DataTablePagination<LeaveBalanceSearchDto> searchDto);
    }
}
