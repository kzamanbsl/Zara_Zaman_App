using app.EntityModel.AppModels;
using app.Infrastructure;
using app.Infrastructure.Auth;
using app.Infrastructure.Repository;

namespace app.Services.AssembleWorkStepItemServices
{
    public class AssembleWorkStepItemService : IAssembleWorkStepItemService
    {
        private readonly IEntityRepository<AssembleWorkStepItem> _iEntityRepository;
        private readonly InventoryDbContext _dbContext;
        private readonly IWorkContext _iWorkContext;
        public AssembleWorkStepItemService(IEntityRepository<AssembleWorkStepItem> iEntityRepository, InventoryDbContext dbContext, IWorkContext iWorkContext)
        {
            _iEntityRepository = iEntityRepository;
            _dbContext = dbContext;
            _iWorkContext = iWorkContext;
        }

        public async Task<bool> AddRecord(AssembleWorkStepItemViewModel vm)
        {
            var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Name.Trim() == vm.Name.Trim() && f.IsActive == true);
            if (checkName == null)
            {
                AssembleWorkStepItem com = new AssembleWorkStepItem();
                com.Name = vm.Name;
                com.Description = vm.Description;
                var res = await _iEntityRepository.AddAsync(com);
                vm.Id=res.Id;
                return true;
            }
            return false;
        }
        public async Task<bool> UpdateRecord(AssembleWorkStepItemViewModel vm)
        {

            //var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Name.Trim() == vm.Name.Trim());
            var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Name.Trim() == vm.Name.Trim() && f.Id != vm.Id && f.IsActive == true);

            if (checkName == null)
            {
                var result = await _iEntityRepository.GetByIdAsync(vm.Id);
                result.Name = vm.Name;
                result.Description = vm.Description;
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
        public async Task<AssembleWorkStepItemViewModel> GetRecordById(long id)
        {
            var result = await _iEntityRepository.GetByIdAsync(id);
            AssembleWorkStepItemViewModel model = new AssembleWorkStepItemViewModel();
            model.Id = result.Id;
            model.Name = result.Name;
            model.Description = result.Description;
            return model;
        }
        public async Task<AssembleWorkStepItemViewModel> GetAllRecord()
        {
            AssembleWorkStepItemViewModel model = new AssembleWorkStepItemViewModel();
            model.AssembleWorkStepItemList = await Task.Run(() => (from t1 in _dbContext.AssembleWorkStepItem
                                                                where t1.IsActive == true
                                                                select new AssembleWorkStepItemViewModel
                                                                {
                                                                    Id = t1.Id,
                                                                    Name = t1.Name,
                                                                    Description = t1.Description,
                                                                }).AsQueryable());
            return model;
        }

    }
}
