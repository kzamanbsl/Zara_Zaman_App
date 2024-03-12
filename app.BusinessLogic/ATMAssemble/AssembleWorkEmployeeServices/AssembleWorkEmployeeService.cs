using app.EntityModel.AppModels.ATMAssemble;
using app.Infrastructure;
using app.Infrastructure.Auth;
using app.Infrastructure.Repository;
using app.Services.ATMAssemble.AssembleWorkStepServices;

namespace app.Services.ATMAssemble.AssembleWorkEmployeeServices
{
    public class AssembleWorkEmployeeService : IAssembleWorkEmployeeService
    {
        private readonly IEntityRepository<AssembleWorkEmployee> _iEntityRepository;
        private readonly InventoryDbContext _dbContext;
        private readonly IWorkContext _iWorkContext;
        public AssembleWorkEmployeeService(IEntityRepository<AssembleWorkEmployee> iEntityRepository, InventoryDbContext dbContext, IWorkContext iWorkContext)
        {
            _iEntityRepository = iEntityRepository;
            _dbContext = dbContext;
            _iWorkContext = iWorkContext;
        }

        public async Task<bool> AddRecord(AssembleWorkEmployeeViewModel viewModel)
        {
            AssembleWorkEmployee data = new AssembleWorkEmployee();
            data.AssembleWorkId = viewModel.AssembleWorkId;
            data.EmployeeId = viewModel.EmployeeId;
            var res = await _iEntityRepository.AddAsync(data);
            viewModel.Id = res.Id;
            return true;
        }

        public async Task<bool> UpdateRecord(AssembleWorkEmployeeViewModel viewModel)
        {
            
            var result = await _iEntityRepository.GetByIdAsync(viewModel.Id);
            result.AssembleWorkId = viewModel.AssembleWorkId;
            result.EmployeeId = viewModel.EmployeeId;
            await _iEntityRepository.UpdateAsync(result);
            return true;
        }

        public async Task<bool> DeleteRecord(long id)
        {
            var result = await _iEntityRepository.GetByIdAsync(id);
            result.IsActive = false;
            await _iEntityRepository.UpdateAsync(result);
            return true;
        }

        public async Task<AssembleWorkEmployeeViewModel> GetRecordById(long id)
        {
            var result = await _iEntityRepository.GetByIdAsync(id);
            AssembleWorkEmployeeViewModel model = new AssembleWorkEmployeeViewModel();
            model.Id = result.Id;
            model.AssembleWorkId = result.AssembleWorkId;
            model.EmployeeId = result.EmployeeId;
            model.EmployeeName = result.Employee?.Name;
            return model;
        }

        public async Task<AssembleWorkEmployeeViewModel> GetAllRecord()
        {
            AssembleWorkEmployeeViewModel model = new AssembleWorkEmployeeViewModel();
            model.AssembleWorkEmployeeList = await Task.Run(() => (from t1 in _dbContext.AssembleWorkEmployee
                                                                   where t1.IsActive == true
                                                                   select new AssembleWorkEmployeeViewModel
                                                                   {
                                                                       Id = t1.Id,
                                                                       AssembleWorkId = t1.AssembleWorkId,
                                                                       EmployeeId = t1.EmployeeId,
                                                                       EmployeeName = t1.Employee.Name
                                                                   }).AsEnumerable());
            return model;
        }

    }
}