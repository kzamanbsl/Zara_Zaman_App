using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Services.EmployeeServices
{
    public interface IEmployeeService
    {
        Task<EmployeeViewModel> GetAllRecord();
        Task<int> AddRecord(EmployeeViewModel model);
        Task<int> UpdateRecord(EmployeeViewModel model);
        Task<bool> DeleteRecord(long id);
        Task<EmployeeViewModel> GetRecordById(long id);
    }
}
