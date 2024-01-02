using app.EntityModel.AppModels;
using app.Infrastructure;
using app.Infrastructure.Auth;
using app.Infrastructure.Repository;

namespace app.Services.StorehouseServices
{
    public class StorehouseService : IStorehouseService
    {
        private readonly IEntityRepository<Storehouse> _iEntityRepository;
        private readonly InventoryDbContext _dbContext;
        private readonly IWorkContext _iWorkContext;
        public StorehouseService(IEntityRepository<Storehouse> iEntityRepository, InventoryDbContext dbContext, IWorkContext iWorkContext)
        {
            _iEntityRepository = iEntityRepository;
            _dbContext = dbContext;
            _iWorkContext = iWorkContext;
        }

        public async Task<bool> AddRecord(StorehouseViewModel vm)
        {
            var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Name.Trim() == vm.Name.Trim());
            if (checkName == null)
            {
                Storehouse storehouse = new Storehouse();
                storehouse.Name = vm.Name;
                storehouse.Location = vm.Location;
                storehouse.Description = vm.Description;
                var res = await _iEntityRepository.AddAsync(storehouse);
                vm.Id = res.Id;
                return true;
            }
            return false;
        }
        public async Task<bool> UpdateRecord(StorehouseViewModel vm)
        {

            var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Name.Trim() == vm.Name.Trim());
            if (checkName == null)
            {
                var storehouse = await _iEntityRepository.GetByIdAsync(vm.Id);
                storehouse.Name = vm.Name;
                storehouse.Location = vm.Location;
                storehouse.Description = vm.Description;
                await _iEntityRepository.UpdateAsync(storehouse);
                return true;
            }
            return false;
        }
        public async Task<StorehouseViewModel> GetRecordById(long id)
        {
            var result = await _iEntityRepository.GetByIdAsync(id);
            StorehouseViewModel model = new StorehouseViewModel();
            model.Id = result.Id;
            model.Name = result.Name;
            model.Location = result.Location;
            model.Description = result.Description;
            return model;
        }
        public async Task<StorehouseViewModel> GetAllRecord()
        {
            StorehouseViewModel model = new StorehouseViewModel();
            model.StorehouseList = await Task.Run(() => (from t1 in _dbContext.Storehouse
                                                                where t1.IsActive == true
                                                                select new StorehouseViewModel
                                                                {
                                                                    Id = t1.Id,
                                                                    Name = t1.Name,
                                                                    Location = t1.Location,
                                                                    Description = t1.Description,
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
