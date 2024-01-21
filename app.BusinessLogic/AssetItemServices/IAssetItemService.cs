using app.Services.AssetItemServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Services.AssetItemServices
{
    public interface IAssetItemService
    {
        Task<bool> AddRecord(AssetItemViewModel vm);
        Task<bool> UpdateRecord(AssetItemViewModel vm);
        Task<AssetItemViewModel> GetRecordById(long id);
        Task<AssetItemViewModel> GetAllRecord();
        Task<bool> DeleteRecord(long id);
    }
}
