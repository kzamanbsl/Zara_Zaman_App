using app.Services.AssetPurchaseOrderServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Services.AssetPurchaseOrderDetailServices
{
    public interface IAssetPurchaseOrderDetailService
    {
        Task<bool> AddRecord(AssetPurchaseOrderViewModel vm);
        Task<bool> UpdatePurchaseDetail(AssetPurchaseOrderViewModel vm);
        Task<bool> DeletePurchaseDetail(long id);
        Task<AssetPurchaseOrderDetailViewModel> SingleAssetPurchaseOrderDetails(long id);

    }
}
