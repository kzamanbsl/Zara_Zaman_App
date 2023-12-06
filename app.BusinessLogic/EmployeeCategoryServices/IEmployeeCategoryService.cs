using app.Services.DesignationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Services.EmployeeCategoryServices
{
    public interface IEmployeeCategoryService
    {
        Task<EmployeeCategoryViewModel> GetAllRecord();
        Task<int> AddRecord(EmployeeCategoryViewModel model);
        Task<int> UpdateRecord(EmployeeCategoryViewModel model);
        Task<bool> DeleteRecord(long id);
        Task<EmployeeCategoryViewModel> GetRecordById(long id);
    }
}
