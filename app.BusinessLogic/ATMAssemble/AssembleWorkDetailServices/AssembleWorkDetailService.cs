using app.EntityModel.AppModels.ATMAssemble;
using app.Infrastructure;
using app.Infrastructure.Auth;
using app.Infrastructure.Repository;
using app.Services.ATMAssemble.AssembleWorkStepServices;
namespace app.Services.ATMAssemble.AssembleWorkDetailServices
{
    public class AssembleWorkDetailService : IAssembleWorkDetailService
    {
        private readonly IEntityRepository<AssembleWorkDetail> _iEntityRepository;
        private readonly InventoryDbContext _dbContext;
        private readonly IWorkContext _iWorkContext;
        public AssembleWorkDetailService(IEntityRepository<AssembleWorkDetail> iEntityRepository, InventoryDbContext dbContext, IWorkContext iWorkContext)
        {
            _iEntityRepository = iEntityRepository;
            _dbContext = dbContext;
            _iWorkContext = iWorkContext;
        }

        public async Task<bool> AddRecord(AssembleWorkDetailViewModel viewModel)
        {
            //var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Name.Trim() == viewModel.Name.Trim() && f.IsActive == true);
            //if (checkName == null)
            //{
            AssembleWorkDetail data = new AssembleWorkDetail();
            data.AssembleWorkId = viewModel.AssembleWorkId;
            data.AssembleWorkStepItemId = viewModel.AssembleWorkStepItemId;
            data.Remarks = viewModel.Remarks;
            data.IsComplete = viewModel.IsComplete;
            data.IsActive = viewModel.IsActive;
            //data.AssembleWorkItemName = viewModel.AssembleWorkItemName;
            var res = await _iEntityRepository.AddAsync(data);
            viewModel.Id = res.Id;
            return true;
            //}
            //else
            //{
            //    return false;
            //}
        }

        public async Task<bool> UpdateRecord(AssembleWorkDetailViewModel viewModel)
        {
            //var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Name.Trim() == viewModel.Name.Trim() && f.Id != viewModel.Id && f.IsActive == true);

            //if (checkName == null)
            //{
            var result = await _iEntityRepository.GetByIdAsync(viewModel.Id);
            result.AssembleWorkId = viewModel.AssembleWorkId;
            result.AssembleWorkStepItemId = viewModel.AssembleWorkStepItemId;
            result.Remarks = viewModel.Remarks;
            result.IsComplete = viewModel.IsComplete;
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

        public async Task<AssembleWorkDetailViewModel> GetRecordById(long id)
        {
            var result = await _iEntityRepository.GetByIdAsync(id);
            AssembleWorkDetailViewModel model = new AssembleWorkDetailViewModel();
            model.Id = result.Id;
            model.AssembleWorkId = result.AssembleWorkId;
            model.AssembleWorkStepItemId = result.AssembleWorkStepItemId;
            model.Remarks = result.Remarks;
            model.IsComplete = result.IsComplete;
            return model;
        }

        public async Task<AssembleWorkDetailViewModel> GetAllRecord()
        {
            AssembleWorkDetailViewModel model = new AssembleWorkDetailViewModel();
            model.AssembleWorkDetailList = await Task.Run(() => (from t1 in _dbContext.AssembleWorkDetail
                                                                 where t1.IsActive == true
                                                                 select new AssembleWorkDetailViewModel
                                                                 {
                                                                     Id = t1.Id,
                                                                     AssembleWorkId = t1.AssembleWorkId,
                                                                     AssembleWorkStepItemId = t1.AssembleWorkStepItemId,
                                                                     AssembleWorkStepItemName = t1.AssembleWorkStepItem.Name,
                                                                 }).AsQueryable());
            return model;
        }

    }
}