using app.EntityModel.DataTablePaginationModels;
using app.Services.SupplierServices;

namespace app.Services.EmployeeServices
{
    public interface IEmployeeService
    {
        Task<bool> AddRecord(EmployeeViewModel vm);
        Task<bool> UpdateRecord(EmployeeViewModel vm);
        Task<EmployeeViewModel> GetRecordById(long id);
        Task<bool> DeleteRecord(long id);
        Task<EmployeeViewModel> GetAllRecord();
        Task<DataTablePagination<EmployeeSearchDto>> SearchAsync(DataTablePagination<EmployeeSearchDto> searchDto);

    }
}
