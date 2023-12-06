using app.Services.DepartmentServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Services.DesignationServices
{
    public interface IDesignationService
    {
        Task<DesignationViewModel> GetAllRecord();
        Task<int> AddRecord(DesignationViewModel model);
        Task<int> UpdateRecord(DesignationViewModel model);
        Task<bool> DeleteRecord(long id);
        Task<DesignationViewModel> GetRecordById(long id);
    }
}
