using app.EntityModel.AppModels;
using app.Infrastructure;
using app.Infrastructure.Auth;

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

        public async Task<IEnumerable<DropdownViewModel>> CompanySelectionList()
        {
            //var user = await _iWorkContext.GetCurrentAdminUserAsync();
            IEnumerable<DropdownViewModel> dropDownViewModels = await Task.Run(() => (from t1 in _dbContext.Company
                                                                                      select new DropdownViewModel
                                                                                      {
                                                                                          Id = t1.Id,
                                                                                          Name = t1.Name
                                                                                      }).AsQueryable());
            return dropDownViewModels;
        }


        public async Task<IEnumerable<DropdownViewModel>> DepartmentSelectionList()
        {
            IEnumerable<DropdownViewModel> dropDownViewModels = await Task.Run(() => (from t1 in _dbContext.Department
                                                                                      select new DropdownViewModel
                                                                                      {
                                                                                          Id = t1.Id,
                                                                                          Name = t1.Name
                                                                                      }).AsQueryable());
            return dropDownViewModels;
        }

        public async Task<IEnumerable<DropdownViewModel>> DesignationSelectionList()
        {
            IEnumerable<DropdownViewModel> dropDownViewModels = await Task.Run(() => (from t1 in _dbContext.Designation
                                                                                      select new DropdownViewModel
                                                                                      {
                                                                                          Id = t1.Id,
                                                                                          Name = t1.Name
                                                                                      }).AsQueryable());
            return dropDownViewModels;
        }



        public async Task<IEnumerable<DropdownViewModel>> LeaveCategorySelectionList()
        {
            IEnumerable<DropdownViewModel> dropDownViewModels = await Task.Run(() => (from t1 in _dbContext.LeaveCategory
                                                                                      select new DropdownViewModel
                                                                                      {
                                                                                          Id = t1.Id,
                                                                                          Name = t1.Name
                                                                                      }).AsQueryable());
            return dropDownViewModels;
        }
        public async Task<IEnumerable<DropdownViewModel>> CountrySelectionList()
        {
            IEnumerable<DropdownViewModel> dropDownViewModels = await Task.Run(() => (from t1 in _dbContext.Country
                                                                                      select new DropdownViewModel
                                                                                      {
                                                                                          Id = t1.Id,
                                                                                          Name = t1.Name
                                                                                      }).AsQueryable());
            return dropDownViewModels;
        }

        public async Task<IEnumerable<DropdownViewModel>> DivisionSelectionList()
        {
            IEnumerable<DropdownViewModel> dropDownViewModels = await Task.Run(() => (from t1 in _dbContext.Division
                                                                                      select new DropdownViewModel
                                                                                      {
                                                                                          Id = t1.Id,
                                                                                          Name = t1.Name
                                                                                      }).AsQueryable());
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
                                                                                      }).AsQueryable());
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
                                                                                      }).AsQueryable());
            return dropDownViewModels;
        }

        public async Task<IEnumerable<DropdownViewModel>> EmployeeSelectionList(long managerId = 0)
        {
            IEnumerable<DropdownViewModel> dropDownViewModels = await Task.Run(() => (from t1 in _dbContext.Employee
                                                                                      where (managerId > 0) ? t1.ManagerId == managerId && t1.IsActive == true : t1.IsActive==true
                                                                                      select new DropdownViewModel
                                                                                      {
                                                                                          Id = t1.Id,
                                                                                          Name = t1.Name
                                                                                      }).AsQueryable());
            return dropDownViewModels;
        }
    }
}
