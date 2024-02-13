using app.EntityModel.DataTablePaginationModels;
using app.Services.CustomerServices;
using app.Services.SupplierServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Services.CustomerServices
{
    public interface ICustomerService
    {
        Task<bool> AddRecord(CustomerViewModel vm);
        Task<bool> UpdateRecord(CustomerViewModel vm);
        Task<CustomerViewModel> GetRecordById(long id);
        Task<bool> DeleteRecord(long id);
        Task<CustomerViewModel> GetAllRecord();
        Task<DataTablePagination<CustomerSearchDto>> SearchAsync(DataTablePagination<CustomerSearchDto> searchDto);
    }
}
