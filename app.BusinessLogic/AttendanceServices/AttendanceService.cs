using app.EntityModel.AppModels;
using app.Infrastructure;
using app.Infrastructure.Auth;
using app.Infrastructure.Repository;
using app.Services.AttendanceLogServices;
using Microsoft.EntityFrameworkCore;

namespace app.Services.AttendanceServices
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IEntityRepository<Attendance> _iEntityRepository;
        private readonly InventoryDbContext _dbContext;
        private readonly IWorkContext _iWorkContext;
        private readonly IAttendanceLogService _attendanceLogService;

        public AttendanceService(IEntityRepository<Attendance> iEntityRepository, InventoryDbContext dbContext, IWorkContext iWorkContext,IAttendanceLogService attendanceLogService)
        {
            _iEntityRepository = iEntityRepository;
            _dbContext = dbContext;
            _iWorkContext = iWorkContext;
            _attendanceLogService = attendanceLogService;
        }



        public async Task<bool> AddRecord(AttendanceViewModel vm)
        {
            var user = await _iWorkContext.GetCurrentAdminUserAsync();
            var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Id == vm.Id && f.EmployeeId == vm.EmployeeId);

            bool result = false;

            if (checkName == null)
            {
                bool IsPresentToday = await IsExist((int)vm.EmployeeId);

                if (IsPresentToday)
                {
                    AttendanceLog models = new AttendanceLog();
                    models.AttendanceId = _dbContext.Attendance
                        .Where(c => c.LoginTime.Date == DateTime.Today && c.EmployeeId == vm.EmployeeId && c.IsActive).FirstOrDefault().Id;
                    models.LogoutTime = vm.LogoutTime;
                    models.Remarks = vm.Remarks;
                    var atLog = await _dbContext.AttendanceLog.AddAsync(models);
                    await _dbContext.SaveChangesAsync();
                    result = true;
                    
                }
                else
                {
                    Attendance model = new Attendance();
                    model.EmployeeId = vm.EmployeeId;
                    model.ShiftId = vm.ShiftId;
                    model.AttendanceDate = vm.AttendanceDate;
                    model.LoginTime = vm.LoginTime;
                    model.LogoutTime = vm.LogoutTime;
                    model.Remarks = vm.Remarks;
                    var res = await _iEntityRepository.AddAsync(model);
                    vm.Id = res.Id;

                    if(vm.Id > 0)
                    {
                        AttendanceLogViewModel models = new AttendanceLogViewModel();
                        models.AttendanceId = vm.Id;
                        models.LoginTime = vm.LoginTime;
                        models.LogoutTime = vm.LogoutTime;
                        models.Remarks = vm.Remarks;
                        var atLog = await _attendanceLogService.AddRecord(models);
                        result = true;
                    }
                }
            }
            return result;
        }

        public async Task<bool> IsExist(int id)
        {
            bool result = false;

            if(id > 0)
            {   
                if(await _dbContext.Attendance.Where(c => c.EmployeeId == id && c.AttendanceDate.Date == DateTime.Today).AnyAsync())
                {
                    result = true;
                }
            }

            return result;
        }
        public async Task<bool> UpdateRecord(AttendanceViewModel vm)
        {

            var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Id == vm.Id && f.EmployeeId == vm.EmployeeId);
            if (checkName == null)
            {
                var result = await _iEntityRepository.GetByIdAsync(vm.Id);
                result
                    .EmployeeId = vm.EmployeeId;
                //result.AttendanceLogId = model.AttendanceLogId;
                result.ShiftId = vm.ShiftId;
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
            model.ShiftId = result.ShiftId;
            model.AttendanceDate = result.AttendanceDate;
            model.LoginTime = result.LoginTime;
            model.LogoutTime = (DateTime)result.LogoutTime;
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
                                                             EmployeeId=t1.EmployeeId,
                                                             EmployeeName=t1.Employee.Name,
                                                             ShiftId=t1.ShiftId,
                                                             ShiftName=t1.Shift.Name,
                                                             AttendanceDate = t1.AttendanceDate,
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
