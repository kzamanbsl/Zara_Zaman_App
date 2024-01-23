using app.EntityModel.AppModels;
using app.Infrastructure;
using app.Infrastructure.Auth;
using app.Infrastructure.Repository;

namespace app.Services.EmployeeGradeServices
{
    public class EmployeeGradeService : IEmployeeGradeService
    {
        private readonly IEntityRepository<EmployeeGrade> _iEntityRepository;
        private readonly InventoryDbContext _dbContext;
        private readonly IWorkContext _iWorkContext;
        public EmployeeGradeService(IEntityRepository<EmployeeGrade> iEntityRepository, InventoryDbContext dbContext, IWorkContext iWorkContext)
        {
            _iEntityRepository = iEntityRepository;
            _dbContext = dbContext;
            _iWorkContext = iWorkContext;
        }

        public async Task<bool> AddRecord(EmployeeGradeViewModel vm)
        {
            var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Name.Trim() == vm.Name.Trim() && f.IsActive == true);
            if (checkName == null)
            {
                EmployeeGrade com = new EmployeeGrade();
                com.Name = vm.Name;
                var res = await _iEntityRepository.AddAsync(com);
                vm.Id=res.Id;
                return true;
            }
            return false;
        }
        public async Task<bool> UpdateRecord(EmployeeGradeViewModel vm)
        {

            var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Name.Trim() == vm.Name.Trim() && f.Id != vm.Id && f.IsActive == true);
            if (checkName == null)
            {
                var result = await _iEntityRepository.GetByIdAsync(vm.Id);
                result.Name = vm.Name;
                await _iEntityRepository.UpdateAsync(result);
                return true;
            }
            return false;
        }
        public async Task<EmployeeGradeViewModel> GetRecordById(long id)
        {
            var result = await _iEntityRepository.GetByIdAsync(id);
            EmployeeGradeViewModel model = new EmployeeGradeViewModel();
            model.Id = result.Id;
            model.Name = result.Name;
            return model;
        }
        public async Task<EmployeeGradeViewModel> GetAllRecord()
        {
            EmployeeGradeViewModel model = new EmployeeGradeViewModel();
            model.EmployeeGradeList = await Task.Run(() => (from t1 in _dbContext.EmployeeGrade
                                                                where t1.IsActive == true
                                                                select new EmployeeGradeViewModel
                                                                {
                                                                    Id = t1.Id,
                                                                    Name = t1.Name,
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
