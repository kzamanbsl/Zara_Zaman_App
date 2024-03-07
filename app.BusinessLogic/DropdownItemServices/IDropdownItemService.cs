using app.EntityModel.DataTablePaginationModels;
using app.Services.ProductCategoryServices;

namespace app.Services.DropdownItemServices
{
    public interface IDropdownItemService
    {
        Task<bool> AddRecord(DropdownItemViewModel vm);
        Task<bool> UpdateRecord(DropdownItemViewModel vm);
        Task<DropdownItemViewModel> GetRecordById(long id);
        Task<bool> DeleteRecord(long id);
        Task<DropdownItemViewModel> GetAllRecord();
        Task<DataTablePagination<DropdownItemSearchDto>> SearchAsync(DataTablePagination<DropdownItemSearchDto> searchDto);

    }
}
