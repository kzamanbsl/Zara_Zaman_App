using app.EntityModel.AppModels;
using app.Infrastructure;
using app.Infrastructure.Auth;
using app.Infrastructure.Repository;

namespace app.Services.AssembleWorkStepServices
{
    public class AssembleWorkStepService : IAssembleWorkStepService
    {
        private readonly IEntityRepository<AssembleWorkStep> _iEntityRepository;
        private readonly InventoryDbContext _dbContext;
        private readonly IWorkContext _iWorkContext;
        public AssembleWorkStepService(IEntityRepository<AssembleWorkStep> iEntityRepository, InventoryDbContext dbContext, IWorkContext iWorkContext)
        {
            _iEntityRepository = iEntityRepository;
            _dbContext = dbContext;
            _iWorkContext = iWorkContext;
        }

        public async Task<bool> AddRecord(AssembleWorkStepViewModel vm)
        {
            var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Name.Trim() == vm.Name.Trim() && f.IsActive == true);
            if (checkName == null)
            {
                AssembleWorkStep com = new AssembleWorkStep();
                com.Name = vm.Name;
                com.Description = vm.Description;
                com.AssembleWorkCategoryId = vm.AssembleWorkCategoryId;
                var res = await _iEntityRepository.AddAsync(com);
                vm.Id=res.Id;
                return true;
            }
            return false;
        }
        public async Task<bool> UpdateRecord(AssembleWorkStepViewModel vm)
        {

            //var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Name.Trim() == vm.Name.Trim());
            var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Name.Trim() == vm.Name.Trim() && f.Id != vm.Id && f.IsActive == true);

            if (checkName == null)
            {
                var result = await _iEntityRepository.GetByIdAsync(vm.Id);
                result.Name = vm.Name;
                result.Description = vm.Description;
                result.AssembleWorkCategoryId = vm.AssembleWorkCategoryId;
                await _iEntityRepository.UpdateAsync(result);
                return true;
            }
            return false;
        }
        public async Task<bool> DeleteRecord(long id)
        {
            var result = await _iEntityRepository.GetByIdAsync(id);
            result.IsActive = false;
            await _iEntityRepository.UpdateAsync(result);
            return true;
        }
        public async Task<AssembleWorkStepViewModel> GetRecordById(long id)
        {
            var result = await _iEntityRepository.GetByIdAsync(id);
            AssembleWorkStepViewModel model = new AssembleWorkStepViewModel();
            model.Id = result.Id;
            model.Name = result.Name;
            model.Description = result.Description;
            model.AssembleWorkCategoryId = result.AssembleWorkCategoryId;
            model.AssembleWorkCategoryName = result.AssembleWorkCategory?.Name;
            return model;
        }
        public async Task<AssembleWorkStepViewModel> GetAllRecord()
        {
            AssembleWorkStepViewModel model = new AssembleWorkStepViewModel();
            model.AssembleWorkStepList = await Task.Run(() => (from t1 in _dbContext.AssembleWorkStep
                                                                where t1.IsActive == true
                                                                select new AssembleWorkStepViewModel
                                                                {
                                                                    Id = t1.Id,
                                                                    Name = t1.Name,
                                                                    Description = t1.Description,
                                                                    AssembleWorkCategoryId = t1.AssembleWorkCategoryId,
                                                                    AssembleWorkCategoryName = t1.AssembleWorkCategory.Name,
                                                                }).AsQueryable());
            return model;
        }

    }
}
