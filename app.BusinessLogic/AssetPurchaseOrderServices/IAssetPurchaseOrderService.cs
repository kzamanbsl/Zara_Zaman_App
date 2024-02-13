namespace app.Services.AssetPurchaseOrderServices
{
    public interface IAssetPurchaseOrderService
    {
        Task<bool> AddRecord(AssetPurchaseOrderViewModel vm);      
        Task<AssetPurchaseOrderViewModel>GetAssetPurchaseOrder(long assetPurchaseOrderId);
        Task<AssetPurchaseOrderViewModel> GetAssetPurchaseOrderDetails(long id);
        Task<AssetPurchaseOrderViewModel> GetAllRecord(); 
        Task<bool> ConfirmAssetPurchaseOrder(long id);
        Task<bool> DeleteAssetPurchaseOrder(long id);
        Task<bool> RejectAssetPurchaseOrder(long id);
        Task<bool> UpdateAssetPurchaseOrder(AssetPurchaseOrderViewModel vm);
    }
}
