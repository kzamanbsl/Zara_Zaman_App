using app.EntityModel.AppModels;
using app.EntityModel.CoreModel;
using app.Infrastructure;
using app.Infrastructure.Auth;
using app.Infrastructure.Repository;

namespace app.Services.ShiftServices
{
    public class ShiftService : IShiftService
    {
        private readonly IEntityRepository<Shift> _iEntityRepository;
        private readonly InventoryDbContext _dbContext;
        private readonly IWorkContext _iWorkContext;
        public ShiftService(IEntityRepository<Shift> iEntityRepository, InventoryDbContext dbContext, IWorkContext iWorkContext)
        {
            _iEntityRepository = iEntityRepository;
            _dbContext = dbContext;
            _iWorkContext = iWorkContext;
        }

        public async Task<int> AddRecord(ShiftViewModel model)
        {
            var user = await _iWorkContext.GetCurrentAdminUserAsync();
            var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Name.Trim() == model.Name.Trim());
            if (checkName == null)
            {
                Shift com = new Shift();
                com.Name = model.Name;
                com.StartAt = model.StartAt;
                com.EndAt = model.EndAt;
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

        public async Task<ShiftViewModel> GetAllRecord()
        {
            ShiftViewModel model = new ShiftViewModel();
            model.ShiftList = await Task.Run(() => (from t1 in _dbContext.Shift
                                                                where t1.IsActive == true
                                                                select new ShiftViewModel
                                                                {
                                                                    Id = t1.Id,
                                                                    Name = t1.Name,
                                                                    StartAt = t1.StartAt,
                                                                    EndAt = t1.EndAt,
                                                                }).AsQueryable());
            return model;
        }

        public async Task<ShiftViewModel> GetRecordById(long id)
        {
            var result = await _iEntityRepository.GetByIdAsync(id);
            ShiftViewModel model = new ShiftViewModel();
            model.Id = result.Id;
            model.Name = result.Name;
            model.StartAt = result.StartAt;
            model.EndAt = result.EndAt;
            return model;
        }

        public async Task<int> UpdateRecord(ShiftViewModel model)
        {

            var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Name.Trim() == model.Name.Trim());
            if (checkName == null)
            {
                var result = await _iEntityRepository.GetByIdAsync(model.Id);
                result.Name = model.Name;
                result.StartAt = model.StartAt;
                result.EndAt = model.EndAt;
                await _iEntityRepository.UpdateAsync(result);
                return 2;
            }
            return 1;
        }
    }
}
