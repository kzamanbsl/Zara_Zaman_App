using app.Services.AssetPurchaseOrderServices;

namespace app.Services.AssetPurchaseOrderDetailServices
{
    public interface IAssetPurchaseOrderDetailService
    {
        Task<bool> AddRecord(AssetPurchaseOrderViewModel vm);
        Task<bool> UpdateAssetPurchaseDetail(AssetPurchaseOrderViewModel vm);
        Task<bool> DeleteAssetPurchaseDetail(long id);
        Task<AssetPurchaseOrderDetailViewModel> SingleAssetPurchaseOrderDetails(long id);

    }
}
