using app.EntityModel.DataTablePaginationModels;

namespace app.Services.ProductServices
{
    public interface IProductService
    {
        Task<bool> AddRecord(ProductViewModel vm);
        Task<bool> UpdateRecord(ProductViewModel vm);
        Task<ProductViewModel> GetRecordById(long id);
        Task<bool> DeleteRecord(long id);
        Task<ProductViewModel> GetAllRecord();
        Task<DataTablePagination<ProductSearchDto>> SearchAsync(DataTablePagination<ProductSearchDto> searchDto);
    
    }
}
