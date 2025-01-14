﻿using app.EntityModel.DataTablePaginationModels;
using app.Services.ProductServices;

namespace app.Services.JobStatusServices
{
    public interface IJobStatusService
    {
       
        Task<bool> AddRecord(JobStatusViewModel vm);
        Task<bool> UpdateRecord(JobStatusViewModel vm);
        Task<JobStatusViewModel> GetRecordById(long id);
        Task<bool> DeleteRecord(long id);
        Task<JobStatusViewModel> GetAllRecord();
        Task<DataTablePagination<JobStatusSearchDto>> SearchAsync(DataTablePagination<JobStatusSearchDto> searchDto);
    }
}
