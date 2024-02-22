using app.EntityModel.DataTablePaginationModels;
using app.Services.ProductServices;

namespace app.Services.ATMAssemble.AssembleWorkStepServices
{
    public interface IAssembleWorkStepService
    {
        Task<bool> AddRecord(AssembleWorkStepViewModel vm);
        Task<bool> UpdateRecord(AssembleWorkStepViewModel vm);
        Task<AssembleWorkStepViewModel> GetRecordById(long id);
        Task<bool> DeleteRecord(long id);
        Task<AssembleWorkStepViewModel> GetAllRecord();
        Task<DataTablePagination<AssembleWorkStepSearchDto>> SearchAsync(DataTablePagination<AssembleWorkStepSearchDto> searchDto);


    }
}
