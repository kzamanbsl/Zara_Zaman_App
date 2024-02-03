using app.EntityModel.AppModels;
using app.Infrastructure;
using app.Infrastructure.Auth;
using app.Infrastructure.Repository;

namespace app.Services.AssembleWorkCategoryServices
{
    public class AssembleWorkCategoryService : IAssembleWorkCategoryService
    {
        private readonly IEntityRepository<AssembleWorkCategory> _iEntityRepository;
        private readonly InventoryDbContext _dbContext;
        private readonly IWorkContext _iWorkContext;
        public AssembleWorkCategoryService(IEntityRepository<AssembleWorkCategory> iEntityRepository, InventoryDbContext dbContext, IWorkContext iWorkContext)
        {
            _iEntityRepository = iEntityRepository;
            _dbContext = dbContext;
            _iWorkContext = iWorkContext;
        }

        public async Task<bool> AddRecord(AssembleWorkCategoryViewModel viewModel)
        {
            var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Name.Trim() == viewModel.Name.Trim() && f.IsActive == true);
            if (checkName == null)
            {
                AssembleWorkCategory data = new AssembleWorkCategory();
                data.Name = viewModel.Name;
                data.Description = viewModel.Description;
                var response = await _iEntityRepository.AddAsync(data);
                viewModel.Id = response.Id;
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<bool> UpdateRecord(AssembleWorkCategoryViewModel vm)
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
        public async Task<AssembleWorkCategoryViewModel> GetRecordById(long id)
        {
            var result = await _iEntityRepository.GetByIdAsync(id);
            AssembleWorkCategoryViewModel model = new AssembleWorkCategoryViewModel();
            model.Id = result.Id;
            model.Name = result.Name;
            model.Description = result.Description;
            return model;
        }
        public async Task<AssembleWorkCategoryViewModel> GetAllRecord()
        {
            AssembleWorkCategoryViewModel model = new AssembleWorkCategoryViewModel();
            model.AssembleWorkCategoryList = await Task.Run(() => (from t1 in _dbContext.AssembleWorkCategory
                                                                where t1.IsActive == true
                                                                select new AssembleWorkCategoryViewModel
                                                                {
                                                                    Id = t1.Id,
                                                                    Name = t1.Name,
                                                                    Description = t1.Description,
                                                                }).AsQueryable());
            return model;
        }

    }
}
