using app.Services.JobStatusServices;
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
        Task<bool> UpdateRecord(PurchaseOrderViewModel vm);
        Task<PurchaseOrderViewModel> GetRecordById(long id);
        Task<bool> PurchaseOrderMasterUpdateRecord(PurchaseOrderViewModel vm);
        Task<bool> DeleteRecord(PurchaseOrderViewModel vm);
        Task<PurchaseOrderViewModel>GetPurchaseOrder(long purchaseOrderId);
        Task<PurchaseOrderViewModel> GetAllRecord();
        //Task<PurchaseOrderViewModel> GetAllRecordTest();
        Task<PurchaseOrderDetailViewModel> SinglePurchaseOrderDetails(long id);

    }
}
