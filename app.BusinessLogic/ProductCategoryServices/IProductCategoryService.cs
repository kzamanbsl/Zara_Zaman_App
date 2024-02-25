using app.EntityModel.DataTablePaginationModels;
using app.Services.ProductServices;

namespace app.Services.ProductCategoryServices
{
    public interface IProductCategoryService
    {
       
        Task<bool> AddRecord(ProductCategoryViewModel vm);
        Task<bool> UpdateRecord(ProductCategoryViewModel vm);
        Task<ProductCategoryViewModel> GetRecordById(long id);
        Task<bool> DeleteRecord(long id);
        Task<ProductCategoryViewModel> GetAllRecord();
        Task<DataTablePagination<ProductCategorySearchDto>> SearchAsync(DataTablePagination<ProductCategorySearchDto> searchDto);

    }
}
