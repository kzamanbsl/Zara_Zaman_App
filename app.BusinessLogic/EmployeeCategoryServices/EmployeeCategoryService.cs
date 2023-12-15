using app.EntityModel.AppModels;
using app.Infrastructure.Auth;
using app.Infrastructure.Repository;
using app.Infrastructure;

namespace app.Services.EmployeeCategoryServices
{
    public class EmployeeCategoryService : IEmployeeCategoryService
    {
        private readonly IEntityRepository<EmployeeCategory> _iEntityRepository;
        private readonly InventoryDbContext _dbContext;
        private readonly IWorkContext _iWorkContext;
        public EmployeeCategoryService(IEntityRepository<EmployeeCategory> iEntityRepository, InventoryDbContext dbContext, IWorkContext iWorkContext)
        {
            _iEntityRepository = iEntityRepository;
            _dbContext = dbContext;
            _iWorkContext = iWorkContext;
        }

        public async Task<bool> AddRecord(EmployeeCategoryViewModel vm)
        {
            var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Name.Trim() == vm.Name.Trim());
            if (checkName == null)
            {
                EmployeeCategory com = new EmployeeCategory();
                com.Name = vm.Name;
                var res = await _iEntityRepository.AddAsync(com);
                vm.Id=res.Id;
                return true;
            }
            return false;
        }
        public async Task<bool> UpdateRecord(EmployeeCategoryViewModel vm)
        {

            var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Name.Trim() == vm.Name.Trim());
            if (checkName == null)
            {
                var result = await _iEntityRepository.GetByIdAsync(vm.Id);
                result.Name = vm.Name;
                await _iEntityRepository.UpdateAsync(result);
                return true;
            }
            return false;
        }
        public async Task<EmployeeCategoryViewModel> GetRecordById(long id)
        {
            var result = await _iEntityRepository.GetByIdAsync(id);
            EmployeeCategoryViewModel model = new EmployeeCategoryViewModel();
            model.Id = result.Id;
            model.Name = result.Name;
            return model;
        }
        public async Task<EmployeeCategoryViewModel> GetAllRecord()
        {
            EmployeeCategoryViewModel model = new EmployeeCategoryViewModel();
            model.EmployeeCategoryList = await Task.Run(() => (from t1 in _dbContext.EmployeeCategory
                                                          where t1.IsActive == true
                                                          select new EmployeeCategoryViewModel
                                                          {
                                                              Id = t1.Id,
                                                              Name = t1.Name,
                                                          }).AsQueryable());
            return model;
        }
        public async Task<bool> DeleteRecord(long id)
        {
            var result = await _iEntityRepository.GetByIdAsync(id);
            result.IsActive = false;
            await _iEntityRepository.UpdateAsync(result);
            return true;
        }

    }
}
