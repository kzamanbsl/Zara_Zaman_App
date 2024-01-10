using app.EntityModel.AppModels;
using app.Infrastructure;
using app.Infrastructure.Auth;
using app.Infrastructure.Repository;
using Microsoft.AspNetCore.Http;
namespace app.Services.AttendanceLogServices
{
    public class AttendanceLogService : IAttendanceLogService
    {
        private readonly IEntityRepository<AttendanceLog> _iEntityRepository;
        private readonly InventoryDbContext _dbContext;
        private readonly IWorkContext _iWorkContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AttendanceLogService(IEntityRepository<AttendanceLog> iEntityRepository, InventoryDbContext dbContext, IWorkContext iWorkContext, IHttpContextAccessor httpContextAccessor)
        {
            _iEntityRepository = iEntityRepository;
            _dbContext = dbContext;
            _iWorkContext = iWorkContext;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> AddRecord(AttendanceLogViewModel vm)
        {

            if (vm != null)
            {

                AttendanceLog model = new AttendanceLog();
                model.AttendanceId = vm.AttendanceId;
                model.LoginTime = (DateTime)vm.LoginTime;
                model.LogoutTime = null;
                model.Remarks = vm.Remarks;
                model.CreatedBy = _httpContextAccessor.HttpContext.User.Identity.Name;
                model.CreatedOn = DateTime.Now;
                model.IsActive = true;
                var res = await _iEntityRepository.AddAsync(model);
                vm.Id = res.Id;
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateRecord(AttendanceLogViewModel vm)
        {
            var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Id == vm.Id && f.AttendanceId == vm.AttendanceId);
            if (checkName == null)
            {
                var result = await _iEntityRepository.GetByIdAsync(vm.Id);
                result.AttendanceId = vm.AttendanceId;
                result.LoginTime = (DateTime)vm.LoginTime;
                result.LogoutTime = vm.LogoutTime;
                result.Remarks = vm.Remarks;
                await _iEntityRepository.UpdateAsync(result);
                return true;
            }
            return false;
        }

        public async Task<AttendanceLogViewModel> GetRecordById(long id)
        {
            //var DataTranfer = _dbContext.AttendanceLog.Include(x => x.Attendance).ToListAsync();
            var result = await _iEntityRepository.GetByIdAsync(id);
            AttendanceLogViewModel model = new AttendanceLogViewModel();
            model.Id = result.Id;
            model.AttendanceId = result.AttendanceId;
            model.LoginTime = result.LoginTime;
            model.LogoutTime = (DateTime)result.LogoutTime;
            model.Remarks = result.Remarks;
            return model;
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
                                                                AttendanceDate = t1.Attendance.AttendanceDate,
                                                                EmployeeId = t1.Attendance.EmployeeId,
                                                                ShiftId = t1.Attendance.ShiftId,
                                                                LoginTime = t1.LoginTime,
                                                                LogoutTime = (DateTime)t1.LogoutTime,
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
