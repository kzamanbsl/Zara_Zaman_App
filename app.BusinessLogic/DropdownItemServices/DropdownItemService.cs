
using app.EntityModel.AppModels;
using app.Infrastructure.Auth;
using app.Infrastructure.Repository;
using app.Infrastructure;

namespace app.Services.DropdownItemServices
{
    public class DropdownItemService:IDropdownItemService
    {
        private readonly IEntityRepository<DropdownItem> _iEntityRepository;
        private readonly InventoryDbContext _dbContext;
        private readonly IWorkContext _iWorkContext;
        public DropdownItemService(IEntityRepository<DropdownItem> iEntityRepository, InventoryDbContext dbContext, IWorkContext iWorkContext)
        {
            _iEntityRepository = iEntityRepository;
            _dbContext = dbContext;
            _iWorkContext = iWorkContext;
        }

        public async Task<bool> AddRecord(DropdownItemViewModel vm)
        {
            var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Name.Trim() == vm.Name.Trim());
            if (checkName == null)
            {
                DropdownItem com = new DropdownItem();
                com.Name = vm.Name;
                com.DropdownTypeId = vm.DropdownTypeId;
                var res = await _iEntityRepository.AddAsync(com);
                vm.Id=res.Id;
                return true;
            }
            return false;
        }
        public async Task<bool> UpdateRecord(DropdownItemViewModel vm)
        {

            var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Name.Trim() == vm.Name.Trim());
            if (checkName == null)
            {
                var result = await _iEntityRepository.GetByIdAsync(vm.Id);
                result.Name = vm.Name;
                result.DropdownTypeId = vm.DropdownTypeId;
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
        public async Task<DropdownItemViewModel> GetRecordById(long id)
        {
            var result = await _iEntityRepository.GetByIdAsync(id);
            DropdownItemViewModel model = new DropdownItemViewModel();
            model.Id = result.Id;
            model.Name = result.Name;
            model.DropdownTypeId = result.DropdownTypeId;
            return model;
        }
        public async Task<DropdownItemViewModel> GetAllRecord()
        {
            DropdownItemViewModel model = new DropdownItemViewModel();
            model.DropdownItemList = await Task.Run(() => (from t1 in _dbContext.DropdownItem
                                                         where t1.IsActive == true
                                                         select new DropdownItemViewModel
                                                         {
                                                             Id = t1.Id,
                                                             Name = t1.Name,
                                                             DropdownTypeId = t1.DropdownTypeId,
                                                         }).AsQueryable());
            return model;
        }

    }
}
