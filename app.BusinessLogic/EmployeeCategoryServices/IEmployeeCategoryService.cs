using app.EntityModel.DataTablePaginationModels;
using app.Services.ProductServices;

namespace app.Services.EmployeeCategoryServices
{
    public interface IEmployeeCategoryService
    {
        Task<bool> AddRecord(EmployeeCategoryViewModel vm);
        Task<bool> UpdateRecord(EmployeeCategoryViewModel vm);
        Task<EmployeeCategoryViewModel> GetRecordById(long id);
        Task<bool> DeleteRecord(long id);
        Task<EmployeeCategoryViewModel> GetAllRecord();
        Task<DataTablePagination<EmployeeCategorySearchDto>> SearchAsync(DataTablePagination<EmployeeCategorySearchDto> searchDto);
    }
}
