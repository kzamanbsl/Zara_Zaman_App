using app.EntityModel.DataTablePaginationModels;
using app.Services.ProductServices;
namespace app.Services.EmployeeGradeServices
{
    public interface IEmployeeGradeService
    {
       
        Task<bool> AddRecord(EmployeeGradeViewModel vm);
        Task<bool> UpdateRecord(EmployeeGradeViewModel vm);
        Task<EmployeeGradeViewModel> GetRecordById(long id);
        Task<EmployeeGradeViewModel> GetAllRecord();
        Task<bool> DeleteRecord(long id);
        Task<DataTablePagination<EmployeeGradeSearchDto>> SearchAsync(DataTablePagination<EmployeeGradeSearchDto> searchDto);


    }
}
