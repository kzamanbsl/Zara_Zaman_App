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
        Task<int> AddRecord(LeaveApplicationViewModel model);
        Task<int> UpdateRecord(LeaveApplicationViewModel model);
        Task<bool> DeleteRecord(long id);
        Task<LeaveApplicationViewModel> GetRecordById(long id);
    }
}
