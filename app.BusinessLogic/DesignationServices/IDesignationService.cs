using app.EntityModel.DataTablePaginationModels;
using app.Services.CompanyServices;

namespace app.Services.DesignationServices
{
    public interface IDesignationService
    {
      
        Task<bool> AddRecord(DesignationViewModel vm);
        Task<bool> UpdateRecord(DesignationViewModel vm);
        Task<DesignationViewModel> GetRecordById(long id);
        Task<bool> DeleteRecord(long id);
        Task<DesignationViewModel> GetAllRecord();
        Task<DataTablePagination<DesignationSearchDto>> SearchAsync(DataTablePagination<DesignationSearchDto> searchDto);
    }
}
