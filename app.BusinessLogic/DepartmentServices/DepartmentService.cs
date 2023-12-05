using app.EntityModel.AppModels;
using app.EntityModel.CoreModel;
using app.Infrastructure;
using app.Infrastructure.Auth;
using app.Infrastructure.Repository;

namespace app.Services.DepartmentServices
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IEntityRepository<Department> _iEntityRepository;
        private readonly InventoryDbContext _dbContext;
        private readonly IWorkContext _iWorkContext;
        public DepartmentService(IEntityRepository<Department> iEntityRepository, InventoryDbContext dbContext, IWorkContext iWorkContext)
        {
            _iEntityRepository = iEntityRepository;
            _dbContext = dbContext;
            _iWorkContext = iWorkContext;
        }

        public async Task<int> AddRecord(DepartmentViewModel model)
        {
            var user = await _iWorkContext.GetCurrentAdminUserAsync();
            var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Name.Trim() == model.Name.Trim());
            if (checkName == null)
            {
                Department com = new Department();
                com.Name = model.Name;
                var res = await _iEntityRepository.AddAsync(com);
                return 2;
            }
            return 1;
        }

        public async Task<bool> DeleteRecord(long id)
        {
            var result = await _iEntityRepository.GetByIdAsync(id);
            result.IsActive = false;
            await _iEntityRepository.UpdateAsync(result);
            return true;
        }

        public async Task<DepartmentViewModel> GetAllRecord()
        {
            DepartmentViewModel model = new DepartmentViewModel();
            model.DepartmentList = await Task.Run(() => (from t1 in _dbContext.Department
                                                                where t1.IsActive == true
                                                                select new DepartmentViewModel
                                                                {
                                                                    Id = t1.Id,
                                                                    Name = t1.Name,
                                                                }).AsQueryable());
            return model;
        }

        public async Task<DepartmentViewModel> GetRecordById(long id)
        {
            var result = await _iEntityRepository.GetByIdAsync(id);
            DepartmentViewModel model = new DepartmentViewModel();
            model.Id = result.Id;
            model.Name = result.Name;
            return model;
        }

        public async Task<int> UpdateRecord(DepartmentViewModel model)
        {

            var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Name.Trim() == model.Name.Trim());
            if (checkName == null)
            {
                var result = await _iEntityRepository.GetByIdAsync(model.Id);
                result.Name = model.Name;
                await _iEntityRepository.UpdateAsync(result);
                return 2;
            }
            return 1;
        }
    }
}
