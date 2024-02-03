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

        public async Task<bool> AddRecord(AssembleWorkStepViewModel viewModel)
        {
            var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Name.Trim() == viewModel.Name.Trim() && f.IsActive == true);
            if (checkName == null)
            {
                AssembleWorkStep data = new AssembleWorkStep();
                data.Name = viewModel.Name;
                data.Description = viewModel.Description;
                data.AssembleWorkCategoryId = viewModel.AssembleWorkCategoryId;
                var res = await _iEntityRepository.AddAsync(data);
                viewModel.Id=res.Id;
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> UpdateRecord(AssembleWorkStepViewModel viewModel)
        {
            var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Name.Trim() == viewModel.Name.Trim() && f.Id != viewModel.Id && f.IsActive == true);

            if (checkName == null)
            {
                var result = await _iEntityRepository.GetByIdAsync(viewModel.Id);
                result.Name = viewModel.Name;
                result.Description = viewModel.Description;
                result.AssembleWorkCategoryId = viewModel.AssembleWorkCategoryId;
                await _iEntityRepository.UpdateAsync(result);
                return true;
            }
            else
            {
                return false;
            }
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