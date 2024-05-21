using app.Infrastructure;
using app.Infrastructure.Auth;
using app.Utility;

namespace app.Services.DropdownServices
{
    public class DropdownService : IDropdownService
    {
        private readonly InventoryDbContext _dbContext;
        private readonly IWorkContext _iWorkContext;
        public DropdownService(InventoryDbContext dbContext, IWorkContext iWorkContext)
        {
            _dbContext = dbContext;
            _iWorkContext = iWorkContext;
        }

        public async Task<IEnumerable<DropdownViewModel>> EmptySelectionList()
        {
            IEnumerable<DropdownViewModel> dropDownViewModels = await Task.Run(() => new List<DropdownViewModel> { new DropdownViewModel
                                                                                      {
                                                                                          Id = 0,
                                                                                          Name = ""
                                                                                      }});
            return dropDownViewModels;
        }

        public async Task<IEnumerable<DropdownViewModel>> CompanySelectionList()
        {
            IEnumerable<DropdownViewModel> dropDownViewModels = await Task.Run(() => (from t1 in _dbContext.Company
                                                                                      where t1.IsActive==true
                                                                                      select new DropdownViewModel
                                                                                      {
                                                                                          Id = t1.Id,
                                                                                          Name = t1.Name
                                                                                      }).AsEnumerable());
            return dropDownViewModels;
        }
        public async Task<IEnumerable<DropdownViewModel>> DepartmentSelectionList()
        {
            IEnumerable<DropdownViewModel> dropDownViewModels = await Task.Run(() => (from t1 in _dbContext.Department
                                                                                      where t1.IsActive == true
                                                                                      select new DropdownViewModel
                                                                                      {
                                                                                          Id = t1.Id,
                                                                                          Name = t1.Name
                                                                                      }).AsEnumerable());
            return dropDownViewModels;
        }
        public async Task<IEnumerable<DropdownViewModel>> DesignationSelectionList()
        {
            IEnumerable<DropdownViewModel> dropDownViewModels = await Task.Run(() => (from t1 in _dbContext.Designation
                                                                                      where t1.IsActive == true
                                                                                      select new DropdownViewModel
                                                                                      {
                                                                                          Id = t1.Id,
                                                                                          Name = t1.Name
                                                                                      }).AsEnumerable());
            return dropDownViewModels;
        }

        public async Task<IEnumerable<DropdownViewModel>> ShiftSelectionList()
        {
            IEnumerable<DropdownViewModel> dropDownViewModels = await Task.Run(() => (from t1 in _dbContext.Shift
                                                                                      where t1.IsActive == true
                                                                                      select new DropdownViewModel
                                                                                      {
                                                                                          Id = t1.Id,
                                                                                          Name = t1.Name
                                                                                      }).AsEnumerable());
            return dropDownViewModels;
        }

        public async Task<IEnumerable<DropdownViewModel>> LeaveCategorySelectionList()
        {
            IEnumerable<DropdownViewModel> dropDownViewModels = await Task.Run(() => (from t1 in _dbContext.LeaveCategory
                                                                                      where t1.IsActive == true
                                                                                      select new DropdownViewModel
                                                                                      {
                                                                                          Id = t1.Id,
                                                                                          Name = t1.Name
                                                                                      }).AsEnumerable());
            return dropDownViewModels;
        }
        public async Task<IEnumerable<DropdownViewModel>> EmployeeSelectionList(long managerId = 0)
        {
            IEnumerable<DropdownViewModel> dropDownViewModels = await Task.Run(() => (from t1 in _dbContext.Employee
                                                                                      where t1.IsActive == true
                                                                                      select new DropdownViewModel
                                                                                      {
                                                                                          Id = t1.Id,
                                                                                          Name = t1.Name
                                                                                      }).AsEnumerable());
            return dropDownViewModels;
        }
        public async Task<IEnumerable<DropdownViewModel>> CountrySelectionList()
        {
            IEnumerable<DropdownViewModel> dropDownViewModels = await Task.Run(() => (from t1 in _dbContext.Country
                                                                                      select new DropdownViewModel
                                                                                      {
                                                                                          Id = t1.Id,
                                                                                          Name = t1.Name
                                                                                      }).AsEnumerable());
            return dropDownViewModels;
        }
        public async Task<IEnumerable<DropdownViewModel>> DivisionSelectionList()
        {
            IEnumerable<DropdownViewModel> dropDownViewModels = await Task.Run(() => (from t1 in _dbContext.Division
                                                                                      select new DropdownViewModel
                                                                                      {
                                                                                          Id = t1.Id,
                                                                                          Name = t1.Name
                                                                                      }).AsEnumerable());
            return dropDownViewModels;
        }
        public async Task<IEnumerable<DropdownViewModel>> DistrictSelectionList(int divisionId = 0)
        {
            IEnumerable<DropdownViewModel> dropDownViewModels = await Task.Run(() => (from t1 in _dbContext.District
                                                                                      where divisionId > 0 ? t1.DivisionId == divisionId : t1.Id > 0
                                                                                      select new DropdownViewModel
                                                                                      {
                                                                                          Id = t1.Id,
                                                                                          Name = t1.Name
                                                                                      }).AsEnumerable());
            return dropDownViewModels;
        }
        public async Task<IEnumerable<DropdownViewModel>> UpazilaSelectionList(int divisionId = 0, int districtsId = 0)
        {
            IEnumerable<DropdownViewModel> dropDownViewModels = await Task.Run(() => (from t1 in _dbContext.Upazila
                                                                                      join t2 in _dbContext.District on t1.DistrictId equals t2.Id
                                                                                      where (divisionId > 0 && districtsId > 0) ? t2.DivisionId == divisionId && t1.DistrictId == districtsId
                                                                                      : (divisionId == 0 && districtsId > 0) ? t1.DistrictId == districtsId
                                                                                      : t1.Id > 0
                                                                                      select new DropdownViewModel
                                                                                      {
                                                                                          Id = t1.Id,
                                                                                          Name = t1.Name
                                                                                      }).AsEnumerable());
            return dropDownViewModels;
        }
        public async Task<IEnumerable<DropdownViewModel>> BloodGroupSelectionList()
        {
            IEnumerable<DropdownViewModel> dropDownViewModels = await Task.Run(() => (from t1 in _dbContext.DropdownItem
                                                                                      where t1.DropdownTypeId == (int)DropdownTypeEnum.BloodGroup && t1.IsActive == true
                                                                                      select new DropdownViewModel
                                                                                      {
                                                                                          Id = t1.Id,
                                                                                          Name = t1.Name

                                                                                      }).AsEnumerable());
            return dropDownViewModels;
        }
        public async Task<IEnumerable<DropdownViewModel>> MaritalStatusSelectionList()
        {
            IEnumerable<DropdownViewModel> dropDownViewModels = await Task.Run(() => (from t1 in _dbContext.DropdownItem
                                                                                      where t1.DropdownTypeId == (int)DropdownTypeEnum.MaritalStatus && t1.IsActive == true
                                                                                      select new DropdownViewModel
                                                                                      {
                                                                                          Id = t1.Id,
                                                                                          Name = t1.Name

                                                                                      }).AsEnumerable());
            return dropDownViewModels;
        }
        public async Task<IEnumerable<DropdownViewModel>> GenderSelectionList()
        {
            IEnumerable<DropdownViewModel> dropDownViewModels = await Task.Run(() => (from t1 in _dbContext.DropdownItem
                                                                                      where t1.DropdownTypeId == (int)DropdownTypeEnum.Gender && t1.IsActive == true
                                                                                      select new DropdownViewModel
                                                                                      {
                                                                                          Id = t1.Id,
                                                                                          Name = t1.Name

                                                                                      }).AsEnumerable());
            return dropDownViewModels;
        }
        public async Task<IEnumerable<DropdownViewModel>> ReligionSelectionList()
        {
            IEnumerable<DropdownViewModel> dropDownViewModels = await Task.Run(() => (from t1 in _dbContext.DropdownItem
                                                                                      where t1.DropdownTypeId == (int)DropdownTypeEnum.Religion && t1.IsActive == true
                                                                                      select new DropdownViewModel
                                                                                      {
                                                                                          Id = t1.Id,
                                                                                          Name = t1.Name

                                                                                      }).AsEnumerable());
            return dropDownViewModels;
        }
        public async Task<IEnumerable<DropdownViewModel>> EmployeeCategorySelectionList()
        {
            IEnumerable<DropdownViewModel> dropDownViewModels = await Task.Run(() => (from t1 in _dbContext.EmployeeCategory
                                                                                      where t1.IsActive == true
                                                                                      select new DropdownViewModel
                                                                                      {
                                                                                          Id = t1.Id,
                                                                                          Name = t1.Name

                                                                                      }).AsEnumerable());
            return dropDownViewModels;
        }
        public async Task<IEnumerable<DropdownViewModel>> EmployeeServiceTypeSelectionList()
        {
            IEnumerable<DropdownViewModel> dropDownViewModels = await Task.Run(() => (from t1 in _dbContext.EmployeeServiceType
                                                                                      where t1.IsActive == true
                                                                                      select new DropdownViewModel
                                                                                      {
                                                                                          Id = t1.Id,
                                                                                          Name = t1.Name

                                                                                      }).AsEnumerable());
            return dropDownViewModels;
        }
        public async Task<IEnumerable<DropdownViewModel>> OfficeTypeSelectionList()
        {
            IEnumerable<DropdownViewModel> dropDownViewModels = await Task.Run(() => (from t1 in _dbContext.OfficeType
                                                                                      where t1.IsActive == true
                                                                                      select new DropdownViewModel
                                                                                      {
                                                                                          Id = t1.Id,
                                                                                          Name = t1.Name

                                                                                      }).AsEnumerable());
            return dropDownViewModels;
        }

        public async Task<IEnumerable<DropdownViewModel>> EmployeeGradeSelectionList()
        {
            IEnumerable<DropdownViewModel> dropDownViewModels = await Task.Run(() => (from t1 in _dbContext.EmployeeGrade
                                                                                      where t1.IsActive == true
                                                                                      select new DropdownViewModel
                                                                                      {
                                                                                          Id = t1.Id,
                                                                                          Name = t1.Name

                                                                                      }).AsEnumerable());
            return dropDownViewModels;
        }

        public async Task<IEnumerable<DropdownViewModel>> JobStatusSelectionList()
        {
            IEnumerable<DropdownViewModel> dropDownViewModels = await Task.Run(() => (from t1 in _dbContext.JobStatus
                                                                                      where t1.IsActive == true
                                                                                      select new DropdownViewModel
                                                                                      {
                                                                                          Id = t1.Id,
                                                                                          Name = t1.Name

                                                                                      }).AsEnumerable());
            return dropDownViewModels;
        }
        public async Task<IEnumerable<DropdownViewModel>> UnitSelectionList()
        {
            IEnumerable<DropdownViewModel> dropDownViewModels = await Task.Run(() => (from t1 in _dbContext.Unit
                                                                                      where t1.IsActive == true
                                                                                      select new DropdownViewModel
                                                                                      {
                                                                                          Id = t1.Id,
                                                                                          Name = t1.Name

                                                                                      }).AsEnumerable());
            return dropDownViewModels;
        }
        public async Task<IEnumerable<DropdownViewModel>> ProductCategorySelectionList()
        {
            IEnumerable<DropdownViewModel> dropDownViewModels = await Task.Run(() => (from t1 in _dbContext.ProductCategory
                                                                                      where t1.ProductCategoryTypeId == (int)ProductCategoryTypeEnum.ProductCategory && t1.IsActive == true
                                                                                      select new DropdownViewModel
                                                                                      {
                                                                                          Id = t1.Id,
                                                                                          Name = t1.Name

                                                                                      }).AsEnumerable());
            return dropDownViewModels;
        }
        public async Task<IEnumerable<DropdownViewModel>> AssetCategorySelectionList()
        {
            IEnumerable<DropdownViewModel> dropDownViewModels = await Task.Run(() => (from t1 in _dbContext.ProductCategory
                                                                                      where t1.ProductCategoryTypeId == (int)ProductCategoryTypeEnum.AssetCategory && t1.IsActive == true
                                                                                      select new DropdownViewModel
                                                                                      {
                                                                                          Id = t1.Id,
                                                                                          Name = t1.Name

                                                                                      }).AsEnumerable());
            return dropDownViewModels;
        }

        public async Task<IEnumerable<DropdownViewModel>> SupplierSelectionList()
        {
            IEnumerable<DropdownViewModel> dropDownViewModels = await Task.Run(() => (from t1 in _dbContext.Supplier
                                                                                      where t1.IsActive == true
                                                                                      select new DropdownViewModel
                                                                                      {
                                                                                          Id = t1.Id,
                                                                                          Name = t1.Name

                                                                                      }).AsEnumerable());
            return dropDownViewModels;
        }
        public async Task<IEnumerable<DropdownViewModel>> StorehouseSelectionList()
        {
            IEnumerable<DropdownViewModel> dropDownViewModels = await Task.Run(() => (from t1 in _dbContext.BusinessCenter
                                                                                      where t1.BusinessCenterTypeId == (int)BusinessCenterEnum.Storehouse && t1.IsActive == true
                                                                                      select new DropdownViewModel
                                                                                      {
                                                                                          Id = t1.Id,
                                                                                          Name = t1.Name

                                                                                      }).AsEnumerable());
            return dropDownViewModels;
        }

        public async Task<IEnumerable<DropdownViewModel>> ProductSelectionList()
        {
            IEnumerable<DropdownViewModel> dropDownViewModels = await Task.Run(() => (from t1 in _dbContext.Product
                                                                                      where t1.ProductTypeId == (int)ProductTypeEnum.Product && t1.IsActive == true
                                                                                      select new DropdownViewModel
                                                                                      {
                                                                                          Id = t1.Id,
                                                                                          Name = t1.Name

                                                                                      }).AsEnumerable());
            return dropDownViewModels;
        }
        public async Task<IEnumerable<DropdownViewModel>> AssetSelectionList()
        {
            IEnumerable<DropdownViewModel> dropDownViewModels = await Task.Run(() => (from t1 in _dbContext.Product
                                                                                      where t1.ProductTypeId == (int)ProductTypeEnum.Asset && t1.IsActive == true
                                                                                      select new DropdownViewModel
                                                                                      {
                                                                                          Id = t1.Id,
                                                                                          Name = t1.Name

                                                                                      }).AsEnumerable());
            return dropDownViewModels;
        }

        public async Task<IEnumerable<DropdownViewModel>> AssembleWorkCategorySelectionList()
        {
            IEnumerable<DropdownViewModel> dropDownViewModels = await Task.Run(() => (from t1 in _dbContext.AssembleWorkCategory
                                                                                      where t1.IsActive == true
                                                                                      select new DropdownViewModel
                                                                                      {
                                                                                          Id = t1.Id,
                                                                                          Name = t1.Name

                                                                                      }).AsEnumerable());
            return dropDownViewModels;
        }

        public async Task<IEnumerable<DropdownViewModel>> AssembleWorkStepSelectionList()
        {
            IEnumerable<DropdownViewModel> dropDownViewModels = await Task.Run(() => (from t1 in _dbContext.AssembleWorkStep
                                                                                      where t1.IsActive == true
                                                                                      select new DropdownViewModel
                                                                                      {
                                                                                          Id = t1.Id,
                                                                                          Name = t1.Name + " (" + t1.AssembleWorkCategory.Name + ")",

                                                                                      }).AsEnumerable());
            return dropDownViewModels;
        }

        public async Task<IEnumerable<DropdownViewModel>> CustomerSelectionList()
        {
            IEnumerable<DropdownViewModel> dropDownViewModels = await Task.Run(() => (from t1 in _dbContext.Customer
                                                                                      where t1.IsActive == true
                                                                                      select new DropdownViewModel
                                                                                      {
                                                                                          Id = t1.Id,
                                                                                          Name = t1.Name,

                                                                                      }).AsEnumerable());
            return dropDownViewModels;
        }

        public async Task<IEnumerable<DropdownViewModel>> TermsAndConditionsSelectionList()
        {
            IEnumerable<DropdownViewModel> dropDownViewModels = await Task.Run(() => (from t1 in _dbContext.SalesTermsAndCondition
                                                                                      where t1.IsActive == true
                                                                                      select new DropdownViewModel
                                                                                      {
                                                                                          Id = t1.Id,
                                                                                          Name = t1.Key,

                                                                                      }).AsEnumerable());
            return dropDownViewModels;
        }
        public async Task<IEnumerable<DropdownViewModel>> SupplierCategorySelectionList()
        {
            IEnumerable<DropdownViewModel> dropDownViewModels = await Task.Run(() => (from t1 in _dbContext.SupplierCategory
                                                                                      where t1.IsActive == true
                                                                                      select new DropdownViewModel
                                                                                      {
                                                                                          Id = t1.Id,
                                                                                          Name = t1.Name,

                                                                                      }).AsEnumerable());
            return dropDownViewModels;
        }
    }
}
