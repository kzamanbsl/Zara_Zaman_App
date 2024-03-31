using app.EntityModel.DataTablePaginationModels;
using app.Services.SupplierServices;

namespace app.Services.SupplierCategoryServices
{
    public interface ISupplierCategoryService
    {
       
        Task<bool> AddRecord(SupplierCategoryViewModel vm);
        Task<bool> UpdateRecord(SupplierCategoryViewModel vm);
        Task<SupplierCategoryViewModel> GetRecordById(long id);
        Task<bool> DeleteRecord(long id);
        Task<SupplierCategoryViewModel> GetAllRecord();
        Task<DataTablePagination<SupplierCategorySearchDto>> SearchAsync(DataTablePagination<SupplierCategorySearchDto> searchDto);

    }
}
