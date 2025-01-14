﻿using app.EntityModel.DataTablePaginationModels;
using app.Services.LeaveBalanceServices;
using app.Services.ProductServices;

namespace app.Services.LeaveApplicationServices
{
    public interface ILeaveApplicationService
    {
       
        Task<bool> AddRecord(LeaveApplicationViewModel vm);
        Task<bool> UpdateRecord(LeaveApplicationViewModel vm);
       
        Task<LeaveApplicationViewModel> GetRecordById(long id);
        Task<IEnumerable<LeaveBalanceCountViewModel>> GetLeaveBalanceByEmployeeId(long employeeId);
        Task<bool> ConfirmRecord(long id);
        Task<bool> ApproveRecord(long id);
        Task<bool> RejectRecord(long id);
        Task<bool> DeleteRecord(long id);
        Task<LeaveApplicationViewModel> GetAllRecord();
        Task<DataTablePagination<LeaveApplicationSearchDto>> SearchAsync(DataTablePagination<LeaveApplicationSearchDto> searchDto);

    }
}
