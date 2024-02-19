using app.Services.UnitServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Services.UnitServices
{
    public interface IUnitService
    {
        Task<bool> AddRecord(UnitViewModel vm);
        Task<bool> UpdateRecord(UnitViewModel vm);
        Task<UnitViewModel> GetRecordById(long id);
        Task<bool> DeleteRecord(long id);
        Task<UnitViewModel> GetAllRecord();
    }
}
