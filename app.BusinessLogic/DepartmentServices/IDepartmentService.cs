using app.EntityModel.DataTablePaginationModels;
using app.Services.DesignationServices;

namespace app.Services.DepartmentServices
{
    public interface IDepartmentService
    {
       
        Task<bool> AddRecord(DepartmentViewModel vm);
        Task<bool> UpdateRecord(DepartmentViewModel vm);
        Task<DepartmentViewModel> GetRecordById(long id);
        Task<bool> DeleteRecord(long id);
        Task<DepartmentViewModel> GetAllRecord();
        Task<DataTablePagination<DepartmentSearchDto>> SearchAsync(DataTablePagination<DepartmentSearchDto> searchDto);
    }
}
