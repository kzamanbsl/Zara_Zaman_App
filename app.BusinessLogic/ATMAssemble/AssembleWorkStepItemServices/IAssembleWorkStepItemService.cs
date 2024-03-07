using app.EntityModel.DataTablePaginationModels;
using app.Services.ProductServices;

namespace app.Services.ATMAssemble.AssembleWorkStepItemServices
{
    public interface IAssembleWorkStepItemService
    {

        Task<bool> AddRecord(AssembleWorkStepItemViewModel vm);
        Task<bool> UpdateRecord(AssembleWorkStepItemViewModel vm);
        Task<AssembleWorkStepItemViewModel> GetRecordById(long id);
        Task<bool> DeleteRecord(long id);
        Task<AssembleWorkStepItemViewModel> GetAllRecord();
        Task<DataTablePagination<AssembleWorkStepItemSearchDto>> SearchAsync(DataTablePagination<AssembleWorkStepItemSearchDto> searchDto);

    }
}
