using app.Services.AssetInventoryServices;
using app.Services.AssetPurchaseOrderServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Services.IAssetnventoryServices
{
    public interface IAssetInventoryService
    {
        Task<bool> AddAssetInventory(long id);
    }
}
