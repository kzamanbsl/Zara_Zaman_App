using app.Services.JobStatusServices;
using app.Services.ProductServices;
using app.Services.PurchaseOrderDetailServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Services.AssetPurchaseOrderServices
{
    public interface IAssetPurchaseOrderService
    {
        Task<bool> AddRecord(AssetPurchaseOrderViewModel vm);      
        Task<AssetPurchaseOrderViewModel>GetPurchaseOrder(long assetPurchaseOrderId);
        Task<AssetPurchaseOrderViewModel> GetPurchaseOrderDetails(long id);
        Task<AssetPurchaseOrderViewModel> GetAllRecord(); 
        Task<bool> ConfirmPurchaseOrder(long id);
        Task<bool> DeletePurchaseOrder(long id);
        Task<bool> RejectPurchaseOrder(long id);
        Task<bool> UpdatePurchaseOrder(AssetPurchaseOrderViewModel vm);
    }
}
