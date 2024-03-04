﻿using app.EntityModel.DataTablePaginationModels;
using app.Services.ProductServices;

namespace app.Services.AssetAllocationServices
{
    public interface IAssetAllocationService
    {
        Task<bool> AddRecord(AssetAllocationViewModel vm);      
        Task<AssetAllocationViewModel>GetAssetAllocation(long assetAllocationId);
        Task<AssetAllocationViewModel> GetAssetAllocationDetails(long id);
        Task<bool> ConfirmAssetAllocation(long id);
        Task<bool> DeleteAssetAllocation(long id);
        Task<bool> RejectAssetAllocation(long id);
        Task<bool> UpdateAssetAllocation(AssetAllocationViewModel vm);
        Task<AssetAllocationViewModel> GetAllRecord();
        //Task<DataTablePagination<AssetAllocationSearchDto>> SearchAsync(DataTablePagination<AssetAllocationSearchDto> searchDto);
    }
}
