using app.EntityModel.DataTablePaginationModels;
using app.Services.ProductServices;

namespace app.Services.EmployeeServiceTypeServices
{
    public interface IEmployeeServiceTypeService
    {
       
        Task<bool> AddRecord(EmployeeServiceTypeViewModel vm);
        Task<bool> UpdateRecord(EmployeeServiceTypeViewModel vm);
        Task<EmployeeServiceTypeViewModel> GetRecordById(long id);
        Task<bool> DeleteRecord(long id);
        Task<EmployeeServiceTypeViewModel> GetAllRecord();
        Task<DataTablePagination<EmployeeServiceTypeSearchDto>> SearchAsync(DataTablePagination<EmployeeServiceTypeSearchDto> searchDto);

    }
}
