using app.EntityModel.AppModels;
using app.Infrastructure;
using app.Infrastructure.Auth;
using app.Infrastructure.Repository;

namespace app.Services.SupplierServices
{
    public class SupplierService : ISupplierService
    {
        private readonly IEntityRepository<Supplier> _iEntityRepository;
        private readonly InventoryDbContext _dbContext;
        private readonly IWorkContext _iWorkContext;
        public SupplierService(IEntityRepository<Supplier> iEntityRepository, InventoryDbContext dbContext, IWorkContext iWorkContext)
        {
            _iEntityRepository = iEntityRepository;
            _dbContext = dbContext;
            _iWorkContext = iWorkContext;
        }

        public async Task<bool> AddRecord(SupplierViewModel vm)
        {
            var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Id==vm.Id && f.LeaveCategoryId ==vm.LeaveCategoryId);
            if (checkName == null)
            {
                Supplier com = new Supplier();
                com.LeaveCategoryId = vm.LeaveCategoryId;
                com.LeaveQty = vm.LeaveQty;
                com.Description=vm.Description;
                var res = await _iEntityRepository.AddAsync(com);
                vm.Id = res.Id;
                return true;
            }

            return false;
        }
        public async Task<bool> UpdateRecord(SupplierViewModel vm)
        {
            var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Id == vm.Id && f.LeaveCategoryId == vm.LeaveCategoryId);
            if (checkName == null)
            {
                var result = await _iEntityRepository.GetByIdAsync(vm.Id);
                result.LeaveCategoryId = vm.LeaveCategoryId;
                result.LeaveQty = vm.LeaveQty;
                result.Description = vm.Description;
                await _iEntityRepository.UpdateAsync(result);
                return true;
            }
            return false;
        }
       
        public async Task<SupplierViewModel> GetRecordById(long id)
        {
            var result = await _iEntityRepository.GetByIdAsync(id);
            SupplierViewModel model = new SupplierViewModel();
            model.Id = result.Id;
            model.LeaveCategoryId = result.LeaveCategoryId;
            model.LeaveQty = result.LeaveQty;
            model.Description = result.Description;
            return model;
        }
        public async Task<SupplierViewModel> GetAllRecord()
        {
            SupplierViewModel model = new SupplierViewModel();
            model.SupplierList = await Task.Run(() => (from t1 in _dbContext.Supplier
                                                                where t1.IsActive == true
                                                                select new SupplierViewModel
                                                                {
                                                                    Id = t1.Id,
                                                                    LeaveCategoryId=t1.LeaveCategoryId,
                                                                    LeaveCategoryName= t1.LeaveCategory.Name,
                                                                    LeaveQty = t1.LeaveQty,
                                                                    Description=t1.Description,
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
