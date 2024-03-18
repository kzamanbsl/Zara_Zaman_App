using app.EntityModel.DataTablePaginationModels;

namespace app.Services.AssetItemServices
{
    public interface IAssetItemService
    {
        Task<bool> AddRecord(AssetItemViewModel vm);
        Task<bool> UpdateRecord(AssetItemViewModel vm);
        Task<AssetItemViewModel> GetRecordById(long id);
        Task<bool> DeleteRecord(long id);
        Task<AssetItemViewModel> GetAllRecord();
        Task<DataTablePagination<AssetItemSearchDto>> SearchAsync(DataTablePagination<AssetItemSearchDto> searchDto);
    }
}
