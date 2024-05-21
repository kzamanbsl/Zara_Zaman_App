using app.EntityModel.DataTablePaginationModels;
using app.Services.DepartmentServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Services.BankServices
{
    public interface IBankService
    {

        Task<bool> AddRecord(BankViewModel vm);
        Task<bool> UpdateRecord(BankViewModel vm);
        Task<BankViewModel> GetRecordById(long id);
        Task<bool> DeleteRecord(long id);
        Task<BankViewModel> GetAllRecord();
        Task<DataTablePagination<BankSearchDto>> SearchAsync(DataTablePagination<BankSearchDto> searchDto);
    }
}
