using app.EntityModel.DataTablePaginationModels;
using app.Services.AssetItemServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Services.AssetTransferServices
{
    public  interface IAssetTransferService
    {
        Task<bool> AddRecord(AssetTransferViewModel vm);
        Task<bool> UpdateRecord(AssetTransferViewModel vm);
        Task<AssetTransferViewModel> GetRecordById(long id);
        Task<bool> DeleteRecord(long id);
        Task<List<AssetTransferViewModel>> GetAllRecord();
        Task<DataTablePagination<AssetTransferSearchDto>> SearchAsync(DataTablePagination<AssetTransferSearchDto> searchDto);
    }
}
