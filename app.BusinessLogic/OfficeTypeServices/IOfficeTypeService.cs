using app.EntityModel.DataTablePaginationModels;
using app.Services.EmployeeCategoryServices;

namespace app.Services.OfficeTypeServices
{
    public interface IOfficeTypeService
    {
        
        Task<bool> AddRecord(OfficeTypeViewModel vm);
        Task<bool> UpdateRecord(OfficeTypeViewModel vm);
        Task<OfficeTypeViewModel> GetRecordById(long id);
        Task<bool> DeleteRecord(long id);
        Task<OfficeTypeViewModel> GetAllRecord();
        Task<DataTablePagination<OfficeTypeSearchDto>> SearchAsync(DataTablePagination<OfficeTypeSearchDto> searchDto);
    }
}
