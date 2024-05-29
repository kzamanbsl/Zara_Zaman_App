using app.Services.AssetAllocationDetailServices;
using app.Services.AssetAllocationServices;

namespace app.Services.AssetTransferDetailServices
{
    public interface IAssetTransferDetailService
    {
        Task<bool> AddRecord(AssetTransferDetailViewModel vm);
        Task<bool> UpdateRecord(AssetTransferDetailViewModel vm);
        Task<bool> DeleteRecord(long id);
        Task<AssetTransferDetailViewModel> GetRecordById(long id);

    }
}
