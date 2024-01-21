using app.Services.AssetTypeServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Services.AssetTypeServices
{
    public interface IAssetTypeService
    {
        Task<bool> AddRecord(AssetTypeViewModel vm);
        Task<bool> UpdateRecord(AssetTypeViewModel vm);
        Task<AssetTypeViewModel> GetRecordById(long id);
        Task<AssetTypeViewModel> GetAllRecord();
        Task<bool> DeleteRecord(long id);
    }
}
