using app.EntityModel.DataTablePaginationModels;
using app.Services.ProductServices;

namespace app.Services.ShiftServices
{
    public interface IShiftService
    {
       
        Task<bool> AddRecord(ShiftViewModel vm);
        Task<bool> UpdateRecord(ShiftViewModel vm);

        Task<ShiftViewModel> GetRecordById(long id);
        Task<bool> DeleteRecord(long id);
        Task<ShiftViewModel> GetAllRecord();
        Task<DataTablePagination<ShiftSearchDto>> SearchAsync(DataTablePagination<ShiftSearchDto> searchDto);
    }
}
