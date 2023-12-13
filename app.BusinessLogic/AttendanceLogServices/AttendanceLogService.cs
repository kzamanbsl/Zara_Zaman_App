using app.EntityModel.AppModels;
using app.EntityModel.CoreModel;
using app.Infrastructure;
using app.Infrastructure.Auth;
using app.Infrastructure.Repository;

namespace app.Services.AttendanceLogServices
{
    public class AttendanceLogService : IAttendanceLogService
    {
        private readonly IEntityRepository<AttendanceLog> _iEntityRepository;
        private readonly InventoryDbContext _dbContext;
        private readonly IWorkContext _iWorkContext;
        public AttendanceLogService(IEntityRepository<AttendanceLog> iEntityRepository, InventoryDbContext dbContext, IWorkContext iWorkContext)
        {
            _iEntityRepository = iEntityRepository;
            _dbContext = dbContext;
            _iWorkContext = iWorkContext;
        }

        public async Task<int> AddRecord(AttendanceLogViewModel model)
        {
            var user = await _iWorkContext.GetCurrentAdminUserAsync();
            var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Id==model.Id && f.AttendanceId==model.AttendanceId);
            if (checkName == null)
            {
                AttendanceLog com = new AttendanceLog();
                com.AttendanceId = model.AttendanceId;
                com.EmployeeId = model.EmployeeId;
                com.LoginTime = model.LoginTime;
                com.LogoutTime = model.LogoutTime;
                com.Remarks = model.Remarks;
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

        public async Task<AttendanceLogViewModel> GetAllRecord()
        {
            AttendanceLogViewModel model = new AttendanceLogViewModel();
            model.AttendanceLogList = await Task.Run(() => (from t1 in _dbContext.AttendanceLog
                                                                where t1.IsActive == true
                                                                select new AttendanceLogViewModel
                                                                {
                                                                    Id = t1.Id,
                                                                    AttendanceId = t1.AttendanceId,
                                                                    AttendanceDate = _dbContext.Attendance.FirstOrDefault(f => f.Id == t1.AttendanceId).AttendanceDate,
                                                                    EmployeeId = t1.EmployeeId,
                                                                    EmployeeCode = _dbContext.Employee.FirstOrDefault(f => f.Id == t1.AttendanceId).Name,
                                                                    LoginTime = t1.LoginTime,
                                                                    LogoutTime= t1.LogoutTime,
                                                                    Remarks= t1.Remarks,
                                                                  
                                                                }).AsQueryable());
            return model;
        }

        public async Task<AttendanceLogViewModel> GetRecordById(long id)
        {
            var result = await _iEntityRepository.GetByIdAsync(id);
            AttendanceLogViewModel model = new AttendanceLogViewModel();
            model.Id = result.Id;
            model.AttendanceId = result.AttendanceId;
            model.LoginTime = result.LoginTime;
            model.LogoutTime = result.LogoutTime;
            model.Remarks = result.Remarks;
            return model;
        }

        public async Task<int> UpdateRecord(AttendanceLogViewModel model)
        {

            var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Id==model.Id && f.AttendanceId==model.AttendanceId);
            if (checkName == null)
            {
                var result = await _iEntityRepository.GetByIdAsync(model.Id);
                result.AttendanceId = model.AttendanceId;
                result.EmployeeId = model.EmployeeId;
                result.LoginTime = model.LoginTime;
                result.LogoutTime = model.LogoutTime;
                result.Remarks = model.Remarks;
                await _iEntityRepository.UpdateAsync(result);
                return 2;
            }
            return 1;
        }
    }
}
