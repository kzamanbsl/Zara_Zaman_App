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

        public async Task<bool> AddRecord(AttendanceLogViewModel vm)
        {
            
            var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Id==vm.Id && f.AttendanceId==vm.AttendanceId);
            if (checkName == null)
            {
                AttendanceLog model = new AttendanceLog();
                model.AttendanceId = vm.AttendanceId;
                model.LoginTime = vm.LoginTime;
                model.LogoutTime = vm.LogoutTime;
                model.Remarks = vm.Remarks;

                var res = await _iEntityRepository.AddAsync(model);
                vm.Id=res.Id;
                return true;
            }
            return false ;
        }
        public async Task<bool> UpdateRecord(AttendanceLogViewModel vm)
        {

            var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Id == vm.Id && f.AttendanceId == vm.AttendanceId);
            if (checkName == null)
            {
                var result = await _iEntityRepository.GetByIdAsync(vm.Id);
                result.AttendanceId = vm.AttendanceId;
                result.LoginTime = vm.LoginTime;
                result.LogoutTime = vm.LogoutTime;
                result.Remarks = vm.Remarks;
                await _iEntityRepository.UpdateAsync(result);
                return true;
            }
            return false;
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
                                                                    LoginTime = t1.LoginTime,
                                                                    LogoutTime= t1.LogoutTime,
                                                                    Remarks= t1.Remarks,
                                                                  
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
