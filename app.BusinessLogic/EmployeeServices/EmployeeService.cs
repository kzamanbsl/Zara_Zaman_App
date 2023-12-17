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
            try
            {
                var existingEmployee = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.EmployeeCode == vm.EmployeeCode && f.IsActive == true);
                if (existingEmployee == null)
                {
                    Employee emp = new Employee();
                    emp.Name = vm.Name;
                    emp.EmployeeCode = vm.EmployeeCode;
                    emp.ShortName = vm.ShortName;
                    emp.EmployeeOrder = vm.EmployeeOrder;
                    emp.ManagerId = vm.ManagerId > 0 ? vm.ManagerId : null;
                    emp.Remarks = vm.Remarks;


                    emp.FatherName = vm.FatherName;
                    emp.MotherName = vm.MotherName;
                    emp.DateOfMarriage = vm.DateOfMarriage;
                    emp.MaritalTypeId = vm.MaritalTypeId > 0 ? vm.MaritalTypeId : null;
                    emp.SpouseName = vm.SpouseName;
                    emp.DateOfBirth = vm.DateOfBirth;
                    emp.NationalIdNo = vm.NationalIdNo;
                    emp.GenderId = vm.GenderId > 0 ? vm.GenderId : null;
                    emp.BloodGroupId = vm.BloodGroupId > 0 ? vm.BloodGroupId : null;
                    emp.ReligionId = vm.ReligionId > 0 ? vm.ReligionId : null;
                    emp.TinNo = vm.TinNo;


                    emp.JoiningDate = vm.JoiningDate;
                    emp.ProbationEndDate = vm.ProbationEndDate;
                    emp.DepartmentId = vm.DepartmentId > 0 ? vm.DepartmentId : null;
                    emp.DesignationId = vm.DesignationId > 0 ? vm.DesignationId : null;
                    emp.EmployeeCategoryId = vm.EmployeeCategoryId > 0 ? vm.EmployeeCategoryId : null;
                    emp.JobStatusId = vm.JobStatusId > 0 ? vm.JobStatusId : null;
                    emp.ServiceTypeId = vm.ServiceTypeId > 0 ? vm.ServiceTypeId : null;
                    emp.OfficeTypeId = vm.OfficeTypeId > 0 ? vm.OfficeTypeId : null;
                    emp.ShiftId = vm.ShiftId > 0 ? vm.ShiftId : null;
                    emp.EmployeeGradeId = vm.EmployeeGradeId > 0 ? vm.EmployeeGradeId : null;
                    emp.PresentAddress = vm.PresentAddress;
                    emp.PermanentAddress = vm.PermanentAddress;
                    emp.CountryId = vm.CountryId > 0 ? vm.CountryId : null;
                    emp.DivisionId = vm.DivisionId > 0 ? vm.DivisionId : null;
                    emp.DistrictId = vm.DistrictId > 0 ? vm.DistrictId : null;
                    emp.UpazilaId = vm.UpazilaId > 0 ? vm.UpazilaId : null;
                    emp.MobileNo = vm.MobileNo;
                    emp.Email = vm.Email;

                    emp.SignUrl = vm.SignUrl;
                    emp.PhotoUrl = vm.PhotoUrl;

                    var res = await _iEntityRepository.AddAsync(emp);

                    vm.Id = res?.Id ?? 0;
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {

                throw;
            }
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
