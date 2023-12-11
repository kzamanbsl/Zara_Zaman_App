using app.EntityModel.AppModels;
using app.EntityModel.CoreModel;
using app.Infrastructure;
using app.Infrastructure.Auth;
using app.Infrastructure.Repository;

namespace app.Services.EmployeeServiceTypeServices
{
    public class EmployeeServiceTypeService : IEmployeeServiceTypeService
    {
        private readonly IEntityRepository<EmployeeServiceType> _iEntityRepository;
        private readonly InventoryDbContext _dbContext;
        private readonly IWorkContext _iWorkContext;
        public EmployeeServiceTypeService(IEntityRepository<EmployeeServiceType> iEntityRepository, InventoryDbContext dbContext, IWorkContext iWorkContext)
        {
            _iEntityRepository = iEntityRepository;
            _dbContext = dbContext;
            _iWorkContext = iWorkContext;
        }

        public async Task<int> AddRecord(EmployeeServiceTypeViewModel model)
        {
            var user = await _iWorkContext.GetCurrentAdminUserAsync();
            var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Name.Trim() == model.Name.Trim());
            if (checkName == null)
            {
                EmployeeServiceType com = new EmployeeServiceType();
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

        public async Task<EmployeeServiceTypeViewModel> GetAllRecord()
        {
            EmployeeServiceTypeViewModel model = new EmployeeServiceTypeViewModel();
            model.EmployeeServiceTypeList = await Task.Run(() => (from t1 in _dbContext.EmployeeServiceType
                                                                where t1.IsActive == true
                                                                select new EmployeeServiceTypeViewModel
                                                                {
                                                                    Id = t1.Id,
                                                                    Name = t1.Name,
                                                                }).AsQueryable());
            return model;
        }

        public async Task<EmployeeServiceTypeViewModel> GetRecordById(long id)
        {
            var result = await _iEntityRepository.GetByIdAsync(id);
            EmployeeServiceTypeViewModel model = new EmployeeServiceTypeViewModel();
            model.Id = result.Id;
            model.Name = result.Name;
            return model;
        }

        public async Task<int> UpdateRecord(EmployeeServiceTypeViewModel model)
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
