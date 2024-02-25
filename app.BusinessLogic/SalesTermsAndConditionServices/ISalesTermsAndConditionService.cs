using app.EntityModel.DataTablePaginationModels;
using app.Services.ProductServices;

namespace app.Services.SalesTermsAndConditonServices
{
    public interface ISalesTermsAndConditionService
    {
        
        Task<bool> AddRecord(SalesTermsAndConditionViewModel vm);
        Task<bool> UpdateRecord(SalesTermsAndConditionViewModel vm);
        Task<SalesTermsAndConditionViewModel> GetRecordById(long id);
        Task<bool> DeleteRecord(long id);
        Task<SalesTermsAndConditionViewModel> GetAllRecord();
        Task<DataTablePagination<SalesTermsAndConditionSearchDto>> SearchAsync(DataTablePagination<SalesTermsAndConditionSearchDto> searchDto);

    }
}
