using app.EntityModel.DataTablePaginationModels;
using app.Services.ServiceCenterServices;

namespace app.Services.SaleCenterServices
{
    public interface ISaleCenterService
    {
       
        Task<bool> AddRecord(SaleCenterViewModel vm);
        Task<bool> UpdateRecord(SaleCenterViewModel vm);
        Task<SaleCenterViewModel> GetRecordById(long id);
        Task<bool> DeleteRecord(long id);
        Task<SaleCenterViewModel> GetAllRecord();
        Task<DataTablePagination<SaleCenterSearchDto>> SearchAsync(DataTablePagination<SaleCenterSearchDto> searchDto);
    }
}
