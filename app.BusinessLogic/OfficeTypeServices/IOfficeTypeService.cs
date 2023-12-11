using app.Services.OfficeTypeServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Services.OfficeTypeServices
{
    public interface IOfficeTypeService
    {
        Task<OfficeTypeViewModel> GetAllRecord();
        Task<int> AddRecord(OfficeTypeViewModel model);
        Task<int> UpdateRecord(OfficeTypeViewModel model);
        Task<bool> DeleteRecord(long id);
        Task<OfficeTypeViewModel> GetRecordById(long id);
    }
}
