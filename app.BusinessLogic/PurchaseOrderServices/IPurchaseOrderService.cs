namespace app.Services.PurchaseOrderServices
{
    public interface IPurchaseOrderService
    {
        Task<bool> AddRecord(PurchaseOrderViewModel vm);      
        Task<PurchaseOrderViewModel>GetPurchaseOrder(long purchaseOrderId);
        Task<PurchaseOrderViewModel> GetPurchaseOrderDetails(long id);
        Task<PurchaseOrderViewModel> GetAllRecord(); 
        Task<bool> ConfirmPurchaseOrder(long id);
        Task<bool> DeletePurchaseOrder(long id);
        Task<bool> RejectPurchaseOrder(long id);
        Task<bool> UpdatePurchaseOrder(PurchaseOrderViewModel vm);
    }
}
