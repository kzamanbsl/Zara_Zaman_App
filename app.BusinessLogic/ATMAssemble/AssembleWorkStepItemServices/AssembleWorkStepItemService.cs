using app.EntityModel.AppModels.ATMAssemble;
using app.Infrastructure;
using app.Infrastructure.Auth;
using app.Infrastructure.Repository;

namespace app.Services.ATMAssemble.AssembleWorkStepItemServices
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

        public async Task<bool> AddRecord(AssembleWorkStepItemViewModel viewModel)
        {
            var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Name.Trim() == viewModel.Name.Trim() && f.IsActive == true);
            if (checkName == null)
            {
                AssembleWorkStepItem data = new AssembleWorkStepItem();
                data.Name = viewModel.Name;
                data.Description = viewModel.Description;
                data.AssembleWorkStepId = viewModel.AssembleWorkStepId;
                var response = await _iEntityRepository.AddAsync(data);
                viewModel.Id = response.Id;
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> UpdateRecord(AssembleWorkStepItemViewModel viewModel)
        {
            var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Name.Trim() == viewModel.Name.Trim() && f.Id != viewModel.Id && f.IsActive == true);

            if (checkName == null)
            {
                var result = await _iEntityRepository.GetByIdAsync(viewModel.Id);
                result.Name = viewModel.Name;
                result.Description = viewModel.Description;
                result.AssembleWorkStepId = viewModel.AssembleWorkStepId;
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

        public async Task<AssembleWorkStepItemViewModel> GetRecordById(long id)
        {
            var result = await _iEntityRepository.GetByIdAsync(id);
            AssembleWorkStepItemViewModel model = new AssembleWorkStepItemViewModel();
            model.Id = result.Id;
            model.Name = result.Name;
            model.Description = result.Description;
            model.AssembleWorkStepId = result.AssembleWorkStepId;
            model.AssembleWorkStepName = result.AssembleWorkStep?.Name;
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
                                                                       AssembleWorkStepId = t1.AssembleWorkStepId,
                                                                       AssembleWorkStepName = t1.AssembleWorkStep.Name,
                                                                   }).AsQueryable());
            return model;
        }

    }
}