using app.Services.DropdownItemServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Services.DropdownItemServices
{
    public interface IDropdownItemService
    {
        Task<DropdownItemViewModel> GetAllRecord();
        Task<int> AddRecord(DropdownItemViewModel model);
        Task<int> UpdateRecord(DropdownItemViewModel model);
        Task<bool> DeleteRecord(long id);
        Task<DropdownItemViewModel> GetRecordById(long id);
    }
}
