using app.EntityModel.DataTablePaginationModels;
using app.Services.AssetPurchaseOrderServices;
using app.Services.ProductServices;
using app.Services.SalesOrderServices;

namespace app.Services.AssetAllocationServices
{
    public interface IAssetAllocationService
    {
        Task<bool> AddRecord(AssetAllocationViewModel vm);      
        Task<AssetAllocationViewModel>GetAssetAllocation(long assetAllocationId);
        Task<AssetAllocationViewModel> GetAssetAllocationDetails(long id);
        Task<AssetAllocationViewModel> GetAllRecord();
        Task<bool> ConfirmAssetAllocation(long id);
        Task<bool> DeleteAssetAllocation(long id);
        Task<bool> RejectAssetAllocation(long id);
        Task<bool> UpdateAssetAllocation(AssetAllocationViewModel vm);
        Task<AssetAllocationViewModel> AssetAllocationById(long id);

        Task<DataTablePagination<AssetAllocationSearchDto>> SearchAsync(DataTablePagination<AssetAllocationSearchDto> searchDto);

    }
}
