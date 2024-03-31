using app.EntityModel.DataTablePaginationModels;
using app.Services.SupplierServices;

namespace app.Services.PurchaseOrderServices

{
    public interface IPurchaseOrderService
    {
        Task<bool> AddRecord(PurchaseOrderViewModel vm);
        Task<bool> UpdatePurchaseOrder(PurchaseOrderViewModel vm);
        Task<PurchaseOrderViewModel>GetPurchaseOrder(long purchaseOrderId);
        Task<PurchaseOrderViewModel> GetPurchaseOrderDetails(long id);
        Task<SupplierViewModel> GetSupplierInformation(long id);
        Task<bool> ConfirmPurchaseOrder(long id);
        Task<bool> RejectPurchaseOrder(PurchaseOrderViewModel vm);
        //Task<bool> RejectAssetPurchaseOrder(long id);
        Task<bool> DeletePurchaseOrder(long id);
        Task<PurchaseOrderViewModel> GetAllRecord();
        Task<DataTablePagination<PurchaseOrderSearchDto>> SearchAsync(DataTablePagination<PurchaseOrderSearchDto> searchDto);

    }
}
