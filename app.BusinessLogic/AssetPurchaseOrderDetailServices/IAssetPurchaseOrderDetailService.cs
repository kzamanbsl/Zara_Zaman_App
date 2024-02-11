using app.Services.AssetPurchaseOrderServices;
using app.Services.PurchaseOrderServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Services.AssetPurchaseOrderDetailServices
{
    public interface IAssetPurchaseOrderDetailService
    {
        Task<bool> AddRecord(AssetPurchaseOrderDetailViewModel vm);
        Task<bool> UpdatePurchaseDetail(AssetPurchaseOrderDetailViewModel vm);
        Task<bool> DeletePurchaseDetail(long id);
        Task<AssetPurchaseOrderDetailViewModel> SinglePurchaseOrderDetails(long id);
        Task UpdatePurchaseDetail(AssetPurchaseOrderViewModel vm);
    }
}
