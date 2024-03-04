using app.Services.AssetPurchaseOrderServices;

namespace app.Services.AssetAllocationDetailServices
{
    public interface IAssetAllocationDetailService
    {
        Task<bool> AddRecord(AssetPurchaseOrderViewModel vm);
        Task<bool> UpdateAssetPurchaseDetail(AssetPurchaseOrderViewModel vm);
        Task<bool> DeleteAssetPurchaseDetail(long id);
        Task<AssetAllocationDetailViewModel> SingleAssetAllocationDetails(long id);

    }
}
