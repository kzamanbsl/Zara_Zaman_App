using app.EntityModel.DataTablePaginationModels;
using app.Services.ProductCategoryServices;
using app.Services.SaleCenterServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Services.AssetCategoryServices
{
    public interface IAssetCategoryService
    {
        Task<bool> AddRecord(AssetCategoryViewModel vm);
        Task<bool> UpdateRecord(AssetCategoryViewModel vm);
        Task<AssetCategoryViewModel> GetRecordById(long id);
        Task<bool> DeleteRecord(long id);
        Task<AssetCategoryViewModel> GetAllRecord();
        Task<DataTablePagination<AssetCategorySearchDto>> SearchAsync(DataTablePagination<AssetCategorySearchDto> searchDto);
    }
}
