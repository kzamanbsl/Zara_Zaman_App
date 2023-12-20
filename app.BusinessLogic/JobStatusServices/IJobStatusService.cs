﻿namespace app.Services.JobStatusServices
{
    public interface IJobStatusService
    {
       
        Task<bool> AddRecord(JobStatusViewModel vm);
        Task<bool> UpdateRecord(JobStatusViewModel vm);
        Task<JobStatusViewModel> GetRecordById(long id);
        Task<JobStatusViewModel> GetAllRecord();
        Task<bool> DeleteRecord(long id);
       
    }
}