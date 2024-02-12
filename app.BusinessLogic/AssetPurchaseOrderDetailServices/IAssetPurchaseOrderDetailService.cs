using app.Services.AssetPurchaseOrderServices;
using app.Services.PurchaseOrderDetailServices;
using app.Services.PurchaseOrderServices;

namespace app.Services.AssetPurchaseOrderDetailServices
{
    public interface IAssetPurchaseOrderDetailService
    {
        Task<bool> AddRecord(AssetPurchaseOrderViewModel vm);
        Task<bool> UpdatePurchaseDetail(AssetPurchaseOrderViewModel vm);
        Task<bool> DeletePurchaseDetail(long id);
        Task<AssetPurchaseOrderDetailViewModel> SinglePurchaseOrderDetails(long id);
    }
}
