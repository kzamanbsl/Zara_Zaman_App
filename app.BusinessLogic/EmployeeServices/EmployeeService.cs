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
            var existingEmployee = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Id == model.Id && f.EmployeeCode == model.EmployeeCode);
            if (existingEmployee == null)
            {
                Employee emp = new Employee();
                emp.Name = model.Name;
                emp.EmployeeCode = model.EmployeeCode;
                emp.ShortName = model.ShortName;
                emp.EmployeeOrder = model.EmployeeOrder;
                emp.ManagerId = model.ManagerId;
                emp.Remarks = model.Remarks;


                emp.FatherName = model.FatherName;
                emp.MotherName = model.MotherName;
                emp.DateOfMarriage = model.DateOfMarriage;
                emp.MaritalTypeId = model.MaritalTypeId;
                emp.SpouseName = model.SpouseName;
                emp.DateOfBirth = model.DateOfBirth;
                emp.NationalId = model.NationalId;
                emp.GenderId = model.GenderId;
                emp.BloodGroupId = model.BloodGroupId;
                emp.ReligionId = model.ReligionId;
                emp.TinNo = model.TinNo;


                emp.JoiningDate = model.JoiningDate;
                emp.ProbationEndDate = model.ProbationEndDate;
                emp.DepartmentId = model.DepartmentId;
                emp.DesignationId = model.DesignationId;
                emp.EmployeeCategoryId = model.EmployeeCategoryId;
                emp.JobStatusId = model.JobStatusId;
                emp.ServiceTypeId = model.ServiceTypeId;
                emp.OfficeTypeId = model.OfficeTypeId;
                emp.ShiftId = model.ShiftId;
                emp.GradeId = model.GradeId;
                emp.PresentAddress = model.PresentAddress;
                emp.PermanentAddress = model.PermanentAddress;
                emp.CountryId = model.CountryId;
                emp.DivisionId = model.DivisionId;
                emp.DistrictId = model.DistrictId;
                emp.UpazilaId = model.UpazilaId;
                emp.MobileNo = model.MobileNo;
                emp.Email = model.Email;
                
                emp.SignUrl = model.SignUrl;
                emp.PhotoUrl = model.PhotoUrl;
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
