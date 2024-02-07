﻿using app.Services.JobStatusServices;
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
        Task<PurchaseOrderViewModel> GetAllRecord();       
        Task<PurchaseOrderDetailViewModel> SinglePurchaseOrderDetails(long id);
        Task<bool> ConfirmPurchaseOrder(long id);
        Task<bool> DeletePurchaseMaster(long id);
        Task<PurchaseOrderViewModel> GetPurchaseOrderDetails(long id);
        Task<bool> RejectPurchaseOrder(long id);
        Task<bool> UpdatePurchaseOrder(PurchaseOrderViewModel vm);
    }
}
