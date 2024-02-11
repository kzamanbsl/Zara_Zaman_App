namespace app.Services.AssetPurchaseOrderDetailServices
{
    public interface IAssetPurchaseOrderDetailService
    {
        Task<bool> AddRecord(AssetPurchaseOrderDetailViewModel vm);
        //Task<bool> UpdatePurchaseDetail(AssetPurchaseOrderDetailViewModel vm);
        Task<bool> DeletePurchaseDetail(long id);
        Task<AssetPurchaseOrderDetailViewModel> SinglePurchaseOrderDetails(long id);
        //Task<bool> UpdatePurchaseDetail(AssetPurchaseOrderViewModel vm);
    }
}
