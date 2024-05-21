using app.EntityModel.DataTablePaginationModels;
using app.Services.BankServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Services.BankBranchServices
{
    public  interface IBankBranchService
    {
        Task<bool> AddRecord(BankBranchViewModel vm);
        Task<bool> UpdateRecord(BankBranchViewModel vm);
        Task<BankBranchViewModel> GetRecordById(long id);
        Task<bool> DeleteRecord(long id);
        Task<BankBranchViewModel> GetAllRecord();
        Task<DataTablePagination<BankBranchSearchDto>> SearchAsync(DataTablePagination<BankBranchSearchDto> searchDto);

    }
}
