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

        public async Task<IEnumerable<DropdownViewModel>> DesignatinSelectionList()
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
        public async Task<IEnumerable<DropdownViewModel>> EmployeeSelectionList()
        {
            IEnumerable<DropdownViewModel> dropDownViewModels = await Task.Run(() => (from t1 in _dbContext.Employee
                                                                                      select new DropdownViewModel
                                                                                      {
                                                                                          Id = t1.Id,
                                                                                          Name = t1.Name
                                                                                      }).AsQueryable());
            return dropDownViewModels;
        }
        public async Task<IEnumerable<DropdownViewModel>> ShiftSelectionList()
        {
            IEnumerable<DropdownViewModel> dropDownViewModels = await Task.Run(() => (from t1 in _dbContext.Shift
                                                                                      select new DropdownViewModel
                                                                                      {
                                                                                          Id = t1.Id,
                                                                                          Name = t1.Name
                                                                                      }).AsQueryable());
            return dropDownViewModels;
        }
    }
}
