using app.EntityModel.DataTablePaginationModels;
using app.Services.ProductServices;

namespace app.Services.SupplierServices
{
    public interface ISupplierService
    {
       
        Task<bool> AddRecord(SupplierViewModel vm);
        Task<bool> UpdateRecord(SupplierViewModel vm);
        Task<SupplierViewModel> GetRecordById(long id);
        Task<bool> DeleteRecord(long id);
        Task<SupplierViewModel> GetAllRecord();
        Task<DataTablePagination<SupplierSearchDto>> SearchAsync(DataTablePagination<SupplierSearchDto> searchDto);

    }
}
