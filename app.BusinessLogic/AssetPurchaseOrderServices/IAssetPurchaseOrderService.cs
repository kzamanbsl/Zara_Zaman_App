using app.EntityModel.DataTablePaginationModels;
using app.Services.ProductServices;
using app.Services.PurchaseOrderServices;
using app.Services.SupplierServices;

namespace app.Services.AssetPurchaseOrderServices
{
    public interface IAssetPurchaseOrderService
    {
        Task<bool> AddRecord(AssetPurchaseOrderViewModel vm);      
        Task<AssetPurchaseOrderViewModel>GetAssetPurchaseOrder(long assetPurchaseOrderId);
        Task<AssetPurchaseOrderViewModel> GetAssetPurchaseOrderDetails(long id);
        Task<bool> ConfirmAssetPurchaseOrder(long id);
        Task<bool> DeleteAssetPurchaseOrder(long id);
        Task<bool> RejectAssetPurchaseOrder(AssetPurchaseOrderViewModel vm);
        Task<bool> UpdateAssetPurchaseOrder(AssetPurchaseOrderViewModel vm);
        Task<AssetPurchaseOrderViewModel> GetAllRecord();
        Task<DataTablePagination<AssetPurchaseOrderSearchDto>> SearchAsync(DataTablePagination<AssetPurchaseOrderSearchDto> searchDto);
    }
}
