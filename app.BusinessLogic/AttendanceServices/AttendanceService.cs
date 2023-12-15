using app.EntityModel.AppModels;
using app.Infrastructure;
using app.Infrastructure.Auth;
using app.Infrastructure.Repository;

namespace app.Services.AttendanceServices
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IEntityRepository<Attendance> _iEntityRepository;
        private readonly InventoryDbContext _dbContext;
        private readonly IWorkContext _iWorkContext;
        public AttendanceService(IEntityRepository<Attendance> iEntityRepository, InventoryDbContext dbContext, IWorkContext iWorkContext)
        {
            _iEntityRepository = iEntityRepository;
            _dbContext = dbContext;
            _iWorkContext = iWorkContext;
        }

        public async Task<bool> AddRecord(AttendanceViewModel vm)
        {
            var user = await _iWorkContext.GetCurrentAdminUserAsync();
            var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Id==vm.Id && f.EmployeeId==vm.EmployeeId);
            if (checkName == null)
            {
                Attendance model = new Attendance();
                model.EmployeeId = vm.EmployeeId;
                //model.AttendanceLogId = model.AttendanceLogId;
                model.AttendanceDate= vm.AttendanceDate;
                model.LoginTime = vm.LoginTime;
                model.LogoutTime = vm.LogoutTime;
                model.Remarks = vm.Remarks;
                var res = await _iEntityRepository.AddAsync(model);
                vm.Id = res.Id;
                return true;
            }
            return false;
        }
        public async Task<bool> UpdateRecord(AttendanceViewModel vm)
        {

            var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Id == vm.Id && f.EmployeeId == vm.EmployeeId);
            if (checkName == null)
            {
                var result = await _iEntityRepository.GetByIdAsync(vm.Id);
                result.EmployeeId = vm.EmployeeId;
                //result.AttendanceLogId = model.AttendanceLogId;
                result.AttendanceDate = vm.AttendanceDate;
                result.LoginTime = vm.LoginTime;
                result.LogoutTime = vm.LogoutTime;
                result.Remarks = vm.Remarks;
                var res = await _iEntityRepository.UpdateAsync(result);
                return true;
            }
            return false;
        }
        public async Task<AttendanceViewModel> GetRecordById(long id)
        {
            var result = await _iEntityRepository.GetByIdAsync(id);
            AttendanceViewModel model = new AttendanceViewModel();
            model.Id = result.Id;
            model.EmployeeId = result.EmployeeId;
            //model.AttendanceLogId = result.AttendanceLogId;
            model.AttendanceDate = result.AttendanceDate;
            model.LoginTime = result.LoginTime;
            model.LogoutTime = result.LogoutTime;
            model.Remarks = result.Remarks;
            return model;
        }
        public async Task<AttendanceViewModel> GetAllRecord()
        {
            AttendanceViewModel model = new AttendanceViewModel();
            model.AttendanceList = await Task.Run(() => (from t1 in _dbContext.Attendance
                where t1.IsActive == true
                select new AttendanceViewModel
                {
                    Id = t1.Id,
                    AttendanceDate = t1.AttendanceDate,
                    LoginTime = t1.LoginTime,
                    LogoutTime = t1.LogoutTime,
                    Remarks = t1.Remarks,
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
