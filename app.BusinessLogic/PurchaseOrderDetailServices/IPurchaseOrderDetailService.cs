﻿using app.Services.PurchaseOrderServices;
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
        Task<bool> UpdatePurchaseDetailsRecord(PurchaseOrderViewModel vm);
        Task<bool> PurchaseOrderDetailDeleteById(long id);
    }
}
