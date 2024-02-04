using app.EntityModel.AppModels.ATMAssemble;
using app.Infrastructure;
using app.Infrastructure.Auth;
using app.Infrastructure.Repository;
using app.Services.ATMAssemble.AssembleWorkServices;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;

namespace app.Services.ATMAssemble.AssembleWorkServices
{
    public class AssembleWorkService : IAssembleWorkService
    {
        private readonly IEntityRepository<AssembleWork> _iEntityRepository;
        private readonly InventoryDbContext _dbContext;
        private readonly IWorkContext _iWorkContext;
        public AssembleWorkService(IEntityRepository<AssembleWork> iEntityRepository, InventoryDbContext dbContext, IWorkContext iWorkContext)
        {
            _iEntityRepository = iEntityRepository;
            _dbContext = dbContext;
            _iWorkContext = iWorkContext;
        }

        public async Task<bool> AddRecord(AssembleWorkViewModel viewModel)
        {
            AssembleWork data = new AssembleWork();
            data.AssembleDate = viewModel.AssembleDate;
            data.AssembleWorkCategoryId = viewModel.AssembleWorkCategoryId;
            data.Description = viewModel.Description;
            var response = await _iEntityRepository.AddAsync(data);
            viewModel.Id = response.Id;
            return true;
        }

        public async Task<bool> UpdateRecord(AssembleWorkViewModel viewModel)
        {
            //var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Name.Trim() == viewModel.Name.Trim() && f.Id != viewModel.Id && f.IsActive == true);

            //if (checkName == null)
            //{
            var result = await _iEntityRepository.GetByIdAsync(viewModel.Id);
            //result.Name = viewModel.Name;
            result.Description = viewModel.Description;
            result.AssembleWorkCategoryId = viewModel.AssembleWorkCategoryId;
            await _iEntityRepository.UpdateAsync(result);
            return true;
            //}
            //else
            //{
            //    return false;
            //}
        }

        public async Task<bool> DeleteRecord(long id)
        {
            var result = await _iEntityRepository.GetByIdAsync(id);
            result.IsActive = false;
            await _iEntityRepository.UpdateAsync(result);
            return true;
        }

        public async Task<AssembleWorkViewModel> GetRecordById(long id)
        {
            var result = await _iEntityRepository.GetByIdAsync(id);
            AssembleWorkViewModel model = new AssembleWorkViewModel();
            model.Id = result.Id;
            //model.Name = result.Name;
            model.Description = result.Description;
            model.AssembleWorkCategoryId = result.AssembleWorkCategoryId;
            model.AssembleWorkCategoryName = result.AssembleWorkCategory?.Name;
            return model;
        }

        public async Task<AssembleWorkViewModel> GetAllRecord()
        {
            AssembleWorkViewModel model = new AssembleWorkViewModel();
            model.AssembleWorkList = await Task.Run(() => (from t1 in _dbContext.AssembleWork
                                                           where t1.IsActive == true
                                                           select new AssembleWorkViewModel
                                                           {
                                                               Id = t1.Id,
                                                               //Name = t1.Name,
                                                               Description = t1.Description,
                                                               AssembleWorkCategoryId = t1.AssembleWorkCategoryId,
                                                               AssembleWorkCategoryName = t1.AssembleWorkCategory.Name,
                                                           }).AsQueryable());
            return model;
        }

    }
}