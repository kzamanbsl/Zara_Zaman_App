using app.EntityModel.DataTablePaginationModels;
using app.Services.ProductServices;

namespace app.Services.CompanyServices
{
    public interface ICompanyService
    {
      
        Task<bool> AddRecord(CompanyViewModel vm);
        Task<bool> UpdateRecord(CompanyViewModel vm);
        Task<CompanyViewModel> GetRecordById(long id);
        Task<bool> DeleteRecord(long id);
        Task<CompanyViewModel> GetAllRecord();
        Task<DataTablePagination<CompanySearchDto>> SearchAsync(DataTablePagination<CompanySearchDto> searchDto);
    }
}
