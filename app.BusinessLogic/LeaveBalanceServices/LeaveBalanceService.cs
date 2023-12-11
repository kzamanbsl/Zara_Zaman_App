using app.EntityModel.AppModels;
using app.EntityModel.CoreModel;
using app.Infrastructure;
using app.Infrastructure.Auth;
using app.Infrastructure.Repository;

namespace app.Services.LeaveBalanceServices
{
    public class LeaveBalanceService : ILeaveBalanceService
    {
        private readonly IEntityRepository<LeaveBalance> _iEntityRepository;
        private readonly InventoryDbContext _dbContext;
        private readonly IWorkContext _iWorkContext;
        public LeaveBalanceService(IEntityRepository<LeaveBalance> iEntityRepository, InventoryDbContext dbContext, IWorkContext iWorkContext)
        {
            _iEntityRepository = iEntityRepository;
            _dbContext = dbContext;
            _iWorkContext = iWorkContext;
        }

        public async Task<int> AddRecord(LeaveBalanceViewModel model)
        {
            var user = await _iWorkContext.GetCurrentAdminUserAsync();
            var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Id==model.Id && f.LeaveCategoryId ==model.LeaveCategoryId);
            if (checkName == null)
            {
                LeaveBalance com = new LeaveBalance();
                com.LeaveCategoryId = model.LeaveCategoryId;
                com.LeaveQty = model.LeaveQty;
                com.Description=model.Description;
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

        public async Task<LeaveBalanceViewModel> GetAllRecord()
        {
            LeaveBalanceViewModel model = new LeaveBalanceViewModel();
            model.LeaveBalanceList = await Task.Run(() => (from t1 in _dbContext.LeaveBalance
                                                                where t1.IsActive == true
                                                                select new LeaveBalanceViewModel
                                                                {
                                                                    Id = t1.Id,
                                                                    LeaveCategoryId=t1.LeaveCategoryId,
                                                                    LeaveQty = t1.LeaveQty,
                                                                    Description=t1.Description,
                                                                }).AsQueryable());
            return model;
        }

        public async Task<LeaveBalanceViewModel> GetRecordById(long id)
        {
            var result = await _iEntityRepository.GetByIdAsync(id);
            LeaveBalanceViewModel model = new LeaveBalanceViewModel();
            model.Id = result.Id;
            model.LeaveCategoryId = result.LeaveCategoryId;
            model.LeaveQty = result.LeaveQty;
            model.Description = result.Description;
            return model;
        }

        public async Task<int> UpdateRecord(LeaveBalanceViewModel model)
        {

            var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Id == model.Id && f.LeaveCategoryId == model.LeaveCategoryId);
            if (checkName == null)
            {
                var result = await _iEntityRepository.GetByIdAsync(model.Id);
                result.LeaveCategoryId = model.LeaveCategoryId;
                result.LeaveQty = model.LeaveQty;
                result.Description = model.Description;
                await _iEntityRepository.UpdateAsync(result);
                return 2;
            }
            return 1;
        }
    }
}
