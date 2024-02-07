using app.Services.PurchaseOrderServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Services.PurchaseOrderDetailServices
{
    public interface IPurchaseOrderDetailService
    {
        Task<bool> AddRecord(PurchaseOrderViewModel vm);
        Task<bool> UpdatePurchaseDetail(PurchaseOrderViewModel vm);
        Task<bool> DeletePurchaseDetail(long id);
    }
}
