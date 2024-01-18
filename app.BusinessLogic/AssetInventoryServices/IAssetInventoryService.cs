using app.Services.EmployeeServices;
using app.Services.ProductServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Services.AssetInventoryServices
{
    public interface IAssetInventoryService
    {
        Task<bool> AddRecord(AssetInventoryViewModel vm);
        Task<bool> UpdateRecord(AssetInventoryViewModel vm);
        Task<AssetInventoryViewModel> GetRecordById(long id);
        Task<AssetInventoryViewModel> GetAllRecord();
        Task<bool> DeleteRecord(long id);
    }
}
