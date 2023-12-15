using app.EntityModel.AppModels;
using app.Infrastructure.Auth;
using app.Infrastructure.Repository;
using app.Infrastructure;

namespace app.Services.LeaveCategoryServices
{
    public class LeaveCategoryService : ILeaveCategoryService
    {
        private readonly IEntityRepository<LeaveCategory> _iEntityRepository;
        private readonly InventoryDbContext _dbContext;
        private readonly IWorkContext _iWorkContext;

        public LeaveCategoryService(IEntityRepository<LeaveCategory> iEntityRepository, InventoryDbContext dbContext,
            IWorkContext iWorkContext)
        {
            _iEntityRepository = iEntityRepository;
            _dbContext = dbContext;
            _iWorkContext = iWorkContext;
        }

        public async Task<bool> AddRecord(LeaveCategoryViewModel vm)
        {
            var checkName = _iEntityRepository.AllIQueryableAsync()
                .FirstOrDefault(f => f.Name.Trim() == vm.Name.Trim());
            if (checkName == null)
            {
                LeaveCategory com = new LeaveCategory();
                com.Name = vm.Name;
                var res = await _iEntityRepository.AddAsync(com);
                vm.Id = res.Id;
                return true;
            }

            return false;
        }
        public async Task<bool> UpdateRecord(LeaveCategoryViewModel vm)
        {

            var checkName = _iEntityRepository.AllIQueryableAsync()
                .FirstOrDefault(f => f.Name.Trim() == vm.Name.Trim());
            if (checkName == null)
            {
                var result = await _iEntityRepository.GetByIdAsync(vm.Id);
                result.Name = vm.Name;
                await _iEntityRepository.UpdateAsync(result);
                return true;
            }

            return false;
        }
        public async Task<LeaveCategoryViewModel> GetRecordById(long id)
        {
            var result = await _iEntityRepository.GetByIdAsync(id);
            LeaveCategoryViewModel model = new LeaveCategoryViewModel();
            model.Id = result.Id;
            model.Name = result.Name;
            return model;
        }
        public async Task<LeaveCategoryViewModel> GetAllRecord()
        {
            LeaveCategoryViewModel model = new LeaveCategoryViewModel();
            model.LeaveCategoryList = await Task.Run(() => (from t1 in _dbContext.LeaveCategory
                where t1.IsActive == true
                select new LeaveCategoryViewModel
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
