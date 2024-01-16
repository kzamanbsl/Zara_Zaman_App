using app.Services.ProductServices;
using app.Services.PurchaseOrderDetailServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Services.PurchaseOrderServices
{
    public interface IPurchaseOrderService
    {
        Task<bool> AddRecord(PurchaseOrderViewModel vm);
        Task<PurchaseOrderViewModel>GetPurchaseOrder(long purchaseOrderId);
        Task<ProductViewModel> GetAllRecord();
        Task<PurchaseOrderDetailViewModel> SingleOrderDetails(long id);

    }
}
