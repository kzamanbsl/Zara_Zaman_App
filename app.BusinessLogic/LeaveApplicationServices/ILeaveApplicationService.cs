using app.Services.LeaveApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Services.LeaveApplicationServices
{
    public interface ILeaveApplicationService
    {
        Task<LeaveApplicationViewModel> GetAllRecord();
        Task<LeaveApplicationViewModel> GetRecordById(long id);
        Task<int> AddRecord(LeaveApplicationViewModel model);
        Task<int> UpdateRecord(LeaveApplicationViewModel model);
        Task<bool> ConfirmRecord(long id);
        Task<bool> ApproveRecord(long id);
        Task<bool> RejectRecord(long id);
        Task<bool> DeleteRecord(long id);
        
    }
}
