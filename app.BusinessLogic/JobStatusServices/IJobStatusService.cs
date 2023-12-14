using app.Services.JobStatusServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Services.JobStatusServices
{
    public interface IJobStatusService
    {
        Task<JobStatusViewModel> GetAllRecord();
        Task<int> AddRecord(JobStatusViewModel model);
        Task<int> UpdateRecord(JobStatusViewModel model);
        Task<bool> DeleteRecord(long id);
        Task<JobStatusViewModel> GetRecordById(long id);
    }
}
