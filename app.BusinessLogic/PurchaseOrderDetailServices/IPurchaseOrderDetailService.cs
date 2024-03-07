using app.Services.PurchaseOrderServices;

namespace app.Services.PurchaseOrderDetailServices
{
    public interface IPurchaseOrderDetailService
    {
        Task<bool> AddRecord(PurchaseOrderViewModel vm);
        Task<bool> UpdatePurchaseDetail(PurchaseOrderViewModel vm);
        Task<bool> DeletePurchaseDetail(long id);
        Task<PurchaseOrderDetailViewModel> SinglePurchaseOrderDetails(long id);
        
    }
}
