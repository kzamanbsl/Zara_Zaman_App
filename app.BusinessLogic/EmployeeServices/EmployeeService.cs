using app.EntityModel.AppModels;
using app.Infrastructure.Auth;
using app.Infrastructure.Repository;
using app.Infrastructure;

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

        public async Task<bool> AddRecord(EmployeeViewModel vm)
        {
            var existingEmployee = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Id == vm.Id && f.EmployeeCode == vm.EmployeeCode);
            if (existingEmployee == null)
            {
                Employee emp = new Employee();
                emp.Name = vm.Name;
                emp.EmployeeCode = vm.EmployeeCode;
                emp.ShortName = vm.ShortName;
                emp.EmployeeOrder = vm.EmployeeOrder;
                emp.ManagerId = vm.ManagerId;
                emp.Remarks = vm.Remarks;


                emp.FatherName = vm.FatherName;
                emp.MotherName = vm.MotherName;
                emp.DateOfMarriage = vm.DateOfMarriage;
                emp.MaritalTypeId = vm.MaritalTypeId;
                emp.SpouseName = vm.SpouseName;
                emp.DateOfBirth = vm.DateOfBirth;
                emp.NationalIdNo = vm.NationalIdNo;
                emp.GenderId = vm.GenderId;
                emp.BloodGroupId = vm.BloodGroupId;
                emp.ReligionId = vm.ReligionId;
                emp.TinNo = vm.TinNo;


                emp.JoiningDate = vm.JoiningDate;
                emp.ProbationEndDate = vm.ProbationEndDate;
                emp.DepartmentId = vm.DepartmentId;
                emp.DesignationId = vm.DesignationId;
                emp.EmployeeCategoryId = vm.EmployeeCategoryId;
                emp.JobStatusId = vm.JobStatusId;
                emp.ServiceTypeId = vm.ServiceTypeId;
                emp.OfficeTypeId = vm.OfficeTypeId;
                emp.ShiftId = vm.ShiftId;
                emp.EmployeeGradeId = vm.EmployeeGradeId;
                emp.PresentAddress = vm.PresentAddress;
                emp.PermanentAddress = vm.PermanentAddress;
                emp.CountryId = vm.CountryId;
                emp.DivisionId = vm.DivisionId;
                emp.DistrictId = vm.DistrictId;
                emp.UpazilaId = vm.UpazilaId;
                emp.MobileNo = vm.MobileNo;
                emp.Email = vm.Email;
                
                emp.SignUrl = vm.SignUrl;
                emp.PhotoUrl = vm.PhotoUrl;
                var res = await _iEntityRepository.AddAsync(emp);
                vm.Id=res.Id;
                return true;
            }
            return false;
        }
        public Task<bool> UpdateRecord(EmployeeViewModel model)
        {
            throw new NotImplementedException();
        }
        public Task<EmployeeViewModel> GetRecordById(long id)
        {
            throw new NotImplementedException();
        }
        public Task<EmployeeViewModel> GetAllRecord()
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteRecord(long id)
        {
            throw new NotImplementedException();
        }


    }
}
