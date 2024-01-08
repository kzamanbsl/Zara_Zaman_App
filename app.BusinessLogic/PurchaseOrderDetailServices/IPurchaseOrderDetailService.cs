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
        Task<bool> AddRecord(PurchaseOrderDetailViewModel vm);
        Task<bool> UpdateRecord(PurchaseOrderDetailViewModel vm);
    }
}