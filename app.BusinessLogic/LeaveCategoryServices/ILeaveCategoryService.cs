using app.Services.LeaveCategoryServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Services.LeaveCategoryServices
{
    public interface ILeaveCategoryService
    {
        Task<LeaveCategoryViewModel> GetAllRecord();
        Task<int> AddRecord(LeaveCategoryViewModel model);
        Task<int> UpdateRecord(LeaveCategoryViewModel model);
        Task<bool> DeleteRecord(long id);
        Task<LeaveCategoryViewModel> GetRecordById(long id);
    }
}
