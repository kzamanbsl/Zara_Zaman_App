using app.EntityModel.AppModels;
using app.Infrastructure.Auth;
using app.Infrastructure.Repository;
using app.Infrastructure;
using app.Services.LeaveBalanceServices;
using Microsoft.EntityFrameworkCore;
using app.Services.ShiftServices;
using app.Utility;
using app.Services.LeaveApplicationServices;
using app.EntityModel.DataTablePaginationModels;
using app.Services.ProductServices;

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
        public async Task<bool> UpdateRecord(EmployeeViewModel vm)
        {
            var existingEmployee = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.EmployeeCode == vm.EmployeeCode && f.IsActive == true);
            if (existingEmployee != null)
            {
                var emp = await _iEntityRepository.GetByIdAsync(vm.Id);
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
                await _iEntityRepository.UpdateAsync(emp);
                return true;
            }
            return false;
        }
        public async Task<EmployeeViewModel> GetRecordById(long id)
        {
            var emp = await _iEntityRepository.GetByIdAsync(id);
            EmployeeViewModel vm = new EmployeeViewModel();
            vm.Name = emp.Name;
            vm.UserName = emp.UserName;
            vm.EmployeeCode = emp.EmployeeCode;
            vm.ShortName = emp.ShortName;
            vm.EmployeeOrder = emp.EmployeeOrder;
            vm.ManagerId = emp.ManagerId;
            vm.Remarks = emp.Remarks;


            vm.FatherName = emp.FatherName;
            vm.MotherName = emp.MotherName;
            vm.DateOfMarriage = emp.DateOfMarriage;
            vm.MaritalTypeId = emp.MaritalTypeId;

            vm.SpouseName = emp.SpouseName;
            vm.DateOfBirth = emp.DateOfBirth;
            vm.NationalIdNo = emp.NationalIdNo;
            vm.GenderId = (int?)(emp.GenderId > 0 ? emp.GenderId : null);
            vm.BloodGroupId = (int?)(emp.BloodGroupId > 0 ? emp.BloodGroupId : null);
            vm.ReligionId = (int?)(emp.ReligionId > 0 ? emp.ReligionId : null);
            vm.TinNo = emp.TinNo;


            vm.JoiningDate = emp.JoiningDate;
            vm.ProbationEndDate = emp.ProbationEndDate;
            vm.DepartmentId = emp.DepartmentId > 0 ? emp.DepartmentId : null;
            vm.DesignationId = emp.DesignationId > 0 ? emp.DesignationId : null;
            vm.EmployeeCategoryId = (emp.EmployeeCategoryId > 0 ? emp.EmployeeCategoryId : null);
            vm.JobStatusId = emp.JobStatusId > 0 ? emp.JobStatusId : null;
            vm.ServiceTypeId = emp.ServiceTypeId > 0 ? emp.ServiceTypeId : null;
            vm.OfficeTypeId = emp.OfficeTypeId > 0 ? emp.OfficeTypeId : null;
            vm.ShiftId = emp.ShiftId > 0 ? emp.ShiftId : null;
            vm.EmployeeGradeId = (emp.EmployeeGradeId > 0 ? emp.EmployeeGradeId : null);
            vm.PresentAddress = emp.PresentAddress;
            vm.PermanentAddress = emp.PermanentAddress;
            vm.CountryId = emp.CountryId > 0 ? emp.CountryId : null;
            vm.DivisionId = emp.DivisionId > 0 ? emp.DivisionId : null;
            vm.DistrictId = emp.DistrictId > 0 ? emp.DistrictId : null;
            vm.UpazilaId = emp.UpazilaId > 0 ? emp.UpazilaId : null;
            vm.MobileNo = emp.MobileNo;
            vm.Email = emp.Email;

            vm.SignUrl = emp.SignUrl;
            vm.PhotoUrl = emp.PhotoUrl;
            return vm;
        }
        public async Task<EmployeeViewModel> GetDetailsById(long id)
        {

            //var result = await _iEntityRepository.GetByIdAsync(id);
            var result = await _dbContext.Employee.Include(c => c.Manager).Include(c => c.MaritalType)
                .Include(c => c.Gender).Include(c => c.BloodGroup).Include(c => c.Religion).Include(c => c.Department)
                .Include(c => c.Designation).Include(c => c.EmployeeCategory).Include(c => c.EmployeeGrade)
                .Include(c => c.OfficeType).Include(c => c.ServiceType).Include(c => c.Country).Include(c => c.Division)
                .Include(c => c.District).Include(c => c.Upazila).Include(employee => employee.JobStatus)
                .Include(employee => employee.Shift).FirstOrDefaultAsync(c => c.Id == id);

            EmployeeViewModel model = new EmployeeViewModel();
            model.Id = result.Id;
            model.Name = result.Name;
            model.EmployeeCode = result.EmployeeCode;
            model.ShortName = result.ShortName;
            model.EmployeeOrder = result.EmployeeOrder;
            model.ManagerId = result.ManagerId;
            model.ManagerName = result.Manager?.Name;
            model.Remarks = result.Remarks;


            model.FatherName = result.FatherName;
            model.MotherName = result.MotherName;
            model.DateOfMarriage = result.DateOfMarriage;
            model.MaritalTypeId = result.MaritalTypeId;
            model.MaritalTypeName = result.MaritalType?.Name;

            model.SpouseName = result.SpouseName;
            model.DateOfBirth = result.DateOfBirth;
            model.NationalIdNo = result.NationalIdNo;
            model.GenderId = (int?)(result.GenderId > 0 ? result.GenderId : null);
            model.GenderName = result.Gender?.Name;
            model.BloodGroupId = (int?)(result.BloodGroupId > 0 ? result.BloodGroupId : null);
            model.BloodGroupName = result.BloodGroup?.Name;
            model.ReligionId = (int?)(result.ReligionId > 0 ? result.ReligionId : null);
            model.ReligionName = result.Religion?.Name;
            model.TinNo = result.TinNo;


            model.JoiningDate = result.JoiningDate;
            model.ProbationEndDate = result.ProbationEndDate;
            model.DepartmentId = result.DepartmentId > 0 ? result.DepartmentId : null;
            model.DepartmentName = result.Department?.Name;
            model.DesignationId = result.DesignationId > 0 ? result.DesignationId : null;
            model.DesignationName = result.Designation?.Name;
            model.EmployeeCategoryId = (result.EmployeeCategoryId > 0 ? result.EmployeeCategoryId : null);
            model.EmployeeCategoryName = result.EmployeeCategory?.Name;
            model.JobStatusId = result.JobStatusId > 0 ? result.JobStatusId : null;
            model.JobStatusName = result.JobStatus?.Name;
            model.ServiceTypeId = result.ServiceTypeId > 0 ? result.ServiceTypeId : null;
            model.ServiceTypeName = result.ServiceType?.Name;
            model.OfficeTypeId = result.OfficeTypeId > 0 ? result.OfficeTypeId : null;
            model.OfficeTypeName = result.OfficeType?.Name;
            model.ShiftId = result.ShiftId > 0 ? result.ShiftId : null;
            model.ShiftName = result.Shift?.Name;
            model.EmployeeGradeId = (result.EmployeeGradeId > 0 ? result.EmployeeGradeId : null);
            model.EmployeeGradeName = result.EmployeeGrade?.Name;
            model.PresentAddress = result.PresentAddress;
            model.PermanentAddress = result.PermanentAddress;
            model.CountryId = result.CountryId > 0 ? result.CountryId : null;
            model.CountryName = result.Country?.Name;
            model.DivisionId = result.DivisionId > 0 ? result.DivisionId : null;
            model.DivisionName = result.Division?.Name;
            model.DistrictId = result.DistrictId > 0 ? result.DistrictId : null;
            model.DistrictName = result.District?.Name;
            model.UpazilaId = result.UpazilaId > 0 ? result.UpazilaId : null;
            model.UpazilaName = result.Upazila?.Name;
            model.MobileNo = result.MobileNo;
            model.Email = result.Email;

            model.SignUrl = result.SignUrl;
            model.PhotoUrl = result.PhotoUrl;
            return model;
        }
        public async Task<EmployeeViewModel> GetAllRecord()
        {
            EmployeeViewModel model = new EmployeeViewModel();
            model.EmployeeList = await Task.Run(() => (from t1 in _dbContext.Employee
                                                       where t1.IsActive == true
                                                       select new EmployeeViewModel
                                                       {
                                                           Id = t1.Id,
                                                           EmployeeCode = t1.EmployeeCode,
                                                           Name = t1.Name,
                                                           UserName = t1.UserName,
                                                           DepartmentId = t1.DepartmentId,
                                                           DepartmentName = t1.Department.Name,
                                                           DesignationName = t1.Designation.Name,
                                                           MobileNo = t1.MobileNo,
                                                           JoiningDate = t1.JoiningDate,
                                                           Email = t1.Email,

                                                       }).AsEnumerable());
            return model;
        }
        public async Task<DataTablePagination<EmployeeSearchDto>> SearchAsync(DataTablePagination<EmployeeSearchDto> searchDto)
        {
            var searchResult = _dbContext.Employee.Include(c => c.Department).Include(c => c.Designation).Where(c=>c.IsActive==true).AsNoTracking();

            var searchModel = searchDto.SearchVm;
            var filter = searchDto?.Search?.Value?.Trim();
            if (searchModel?.DepartmentId is > 0)
            {
                searchResult = searchResult.Where(c => c.DepartmentId == searchModel.DepartmentId);
            }
            if (searchModel?.DesignationId is > 0)
            {
                searchResult = searchResult.Where(c => c.DesignationId == searchModel.DesignationId);
            }
            if (!string.IsNullOrEmpty(filter))
            {
                filter = filter.ToLower();
                searchResult = searchResult.Where(c =>
                    c.Name.ToLower().Contains(filter)
                    || c.Department.Name.ToLower().Contains(filter)
                    || c.Designation.Name.ToLower().Contains(filter)
                    || c.EmployeeCode.ToLower().Contains(filter)
                    || c.MobileNo.ToLower().Contains(filter)
                    || c.Email.ToLower().Contains(filter)    
                );
            }

            var pageSize = searchDto.Length ?? 0;
            var skip = searchDto.Start ?? 0;

            var totalRecords = searchResult.Count();
            if (totalRecords <= 0) return searchDto;

            searchDto.RecordsTotal = totalRecords;
            searchDto.RecordsFiltered = totalRecords;
            List<Employee> filteredDataList = await searchResult.OrderByDescending(c => c.Id).Skip(skip).Take(pageSize).ToListAsync();

            var sl = searchDto.Start ?? 0;
            searchDto.Data = filteredDataList.Select(c => new EmployeeSearchDto()
            {
                SerialNo = ++sl,
                Id = c.Id,
                Name = c.Name,
                EmployeeCode = c.EmployeeCode,
                DepartmentId = c.DepartmentId,
                DepartmentName = c.Department?.Name,
                DesignationId = c.DesignationId,
                DesignationName = c.Designation?.Name,
                MobileNo = c.MobileNo,
                Email = c.Email,
                JoiningDate = c.JoiningDate,
                
            }).ToList();

            return searchDto;
        }
    }
}

