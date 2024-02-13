using app.EntityModel.AppModels;
using app.Infrastructure.Auth;
using app.Infrastructure.Repository;
using app.Infrastructure;

namespace app.Services.SalesTermsAndConditonServices
{
    public class SalesTermsAndConditionService : ISalesTermsAndConditionService
    {
        private readonly IEntityRepository<SalesTermsAndCondition> _iEntityRepository;
        private readonly InventoryDbContext _dbContext;
        private readonly IWorkContext _iWorkContext;
        public SalesTermsAndConditionService(IEntityRepository<SalesTermsAndCondition> iEntityRepository, InventoryDbContext dbContext, IWorkContext iWorkContext)
        {
            _iEntityRepository = iEntityRepository;
            _dbContext = dbContext;
            _iWorkContext = iWorkContext;
        }

        public async Task<bool> AddRecord(SalesTermsAndConditionViewModel vm)
        {
           var check = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Id == vm.Id && f.IsActive == true);
            if (check == null)
            {
                SalesTermsAndCondition com = new SalesTermsAndCondition();
                com.Key = vm.Key;
                com.Value = vm.Value;
                var res = await _iEntityRepository.AddAsync(com);
                vm.Id=res.Id;
                return true;
            }
            return false;
        }
        public async Task<bool> UpdateRecord(SalesTermsAndConditionViewModel vm)
        {

            var check = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Key.Trim() == vm.Key.Trim() && f.Id != vm.Id && f.IsActive == true);
            if (check == null)
            {
                var result = await _iEntityRepository.GetByIdAsync(vm.Id);
                result.Key = vm.Key;
                result.Value = vm.Value;
                await _iEntityRepository.UpdateAsync(result);
                return true;
            }
            return false;
        }
       
        public async Task<SalesTermsAndConditionViewModel> GetRecordById(long id)
        {
            var result = await _iEntityRepository.GetByIdAsync(id);
            SalesTermsAndConditionViewModel model = new SalesTermsAndConditionViewModel();
            model.Id = result.Id;
            model.Key = result.Key;
            model.Value = result.Value;
            return model;
        }
        public async Task<SalesTermsAndConditionViewModel> GetAllRecord()
        {
            SalesTermsAndConditionViewModel model = new SalesTermsAndConditionViewModel();
            model.SalesTermsAndConditionList = await Task.Run(() => (from t1 in _dbContext.SalesTermsAndCondition
                                                          where t1.IsActive == true
                                                          select new SalesTermsAndConditionViewModel
                                                          {
                                                              Id = t1.Id,
                                                              Key = t1.Key,
                                                              Value = t1.Value,
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
