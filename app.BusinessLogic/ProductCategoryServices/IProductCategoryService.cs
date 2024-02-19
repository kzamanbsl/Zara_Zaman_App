namespace app.Services.ProductCategoryServices
{
    public interface IProductCategoryService
    {
       
        Task<bool> AddRecord(ProductCategoryViewModel vm);
        Task<bool> UpdateRecord(ProductCategoryViewModel vm);
        Task<ProductCategoryViewModel> GetRecordById(long id);
        Task<bool> DeleteRecord(long id);
        Task<ProductCategoryViewModel> GetAllRecord();

    }
}
