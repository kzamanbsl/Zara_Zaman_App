﻿using app.Services.AssetInventoryServices;
using app.Services.PurchaseOrderServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Services.InventoryServices
{
    public interface IInventoryService
    {
        Task<bool> AddInventory(long id);
    }
}
