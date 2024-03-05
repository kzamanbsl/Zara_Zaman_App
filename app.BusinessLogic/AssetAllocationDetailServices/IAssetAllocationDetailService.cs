using app.Services.AssetAllocationServices;

namespace app.Services.AssetAllocationDetailServices
{
    public interface IAssetAllocationDetailService
    {
        Task<bool> AddRecord(AssetAllocationViewModel vm);
        Task<bool> UpdateAssetAllocationDetail(AssetAllocationViewModel vm);
        Task<bool> DeleteAssetAllocationDetail(long id);
        Task<AssetAllocationDetailViewModel> SingleAssetAllocationDetails(long id);

    }
}
