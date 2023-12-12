using app.EntityModel.AppModels;
using app.Infrastructure.Auth;
using app.Infrastructure.Repository;
using app.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Services.EmployeeServices
{
    public class EmployeeService : IEmployeeService
    {

        private readonly IEntityRepository<Employee> _iEntityRepository;
        private readonly InventoryDbContext _dbContext;
        private readonly IWorkContext _iWorkContext;
        public EmployeeService(IEntityRepository<Employee> iEntityRepository, InventoryDbContext dbContext, IWorkContext iWorkContext)
        {
            _iEntityRepository = iEntityRepository;
            _dbContext = dbContext;
            _iWorkContext = iWorkContext;
        }
        public async Task<int> AddRecord(EmployeeViewModel model)
        {
            var user = await _iWorkContext.GetCurrentAdminUserAsync();
            var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Name.Trim() == model.Name.Trim());
            if (checkName == null)
            {
                Employee emp = new Employee();
                emp.EmployeeId = model.EmployeeId;
                emp.Name = model.Name;
                emp.ShortName = model.ShortName;
                emp.EmployeeOrder = model.EmployeeOrder;
                emp.Remarks = model.Remarks;
                emp.FatherName = model.FatherName;
                emp.MotherName = model.MotherName;

               

                var res = await _iEntityRepository.AddAsync(emp);
                return 2;
            }
            return 1;
        }

        public Task<bool> DeleteRecord(long id)
        {
            throw new NotImplementedException();
        }

        public Task<EmployeeViewModel> GetAllRecord()
        {
            throw new NotImplementedException();
        }

        public Task<EmployeeViewModel> GetRecordById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateRecord(EmployeeViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
