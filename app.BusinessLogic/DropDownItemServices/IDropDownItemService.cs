using app.Services.DropDownItemServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Services.DropDownItemServices
{
    public interface IDropDownItemService
    {
        Task<DropDownItemViewModel> GetAllRecord();
        Task<int> AddRecord(DropDownItemViewModel model);
        Task<int> UpdateRecord(DropDownItemViewModel model);
        Task<bool> DeleteRecord(long id);
        Task<DropDownItemViewModel> GetRecordById(long id);
    }
}
