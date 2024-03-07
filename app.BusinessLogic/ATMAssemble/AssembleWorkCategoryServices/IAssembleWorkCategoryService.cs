using app.EntityModel.DataTablePaginationModels;
using app.Services.ProductServices;

namespace app.Services.ATMAssemble.AssembleWorkCategoryServices
{
    public interface IAssembleWorkCategoryService
    {

        Task<bool> AddRecord(AssembleWorkCategoryViewModel vm);
        Task<bool> UpdateRecord(AssembleWorkCategoryViewModel vm);
        Task<AssembleWorkCategoryViewModel> GetRecordById(long id);
        Task<bool> DeleteRecord(long id);
        Task<AssembleWorkCategoryViewModel> GetAllRecord();
        Task<DataTablePagination<AssembleWorkCategorySearchDto>> SearchAsync(DataTablePagination<AssembleWorkCategorySearchDto> searchDto);

    }
}
