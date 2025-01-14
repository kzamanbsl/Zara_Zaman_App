﻿using app.EntityModel.DataTablePaginationModels;
using app.Services.ProductServices;

namespace app.Services.LeaveCategoryServices
{
    public interface ILeaveCategoryService
    {
       
        Task<bool> AddRecord(LeaveCategoryViewModel vm);
        Task<bool> UpdateRecord(LeaveCategoryViewModel vm);
        Task<LeaveCategoryViewModel> GetRecordById(long id);
        Task<bool> DeleteRecord(long id);
        Task<LeaveCategoryViewModel> GetAllRecord();
        Task<DataTablePagination<LeaveCategorySearchDto>> SearchAsync(DataTablePagination<LeaveCategorySearchDto> searchDto);

    }
}
