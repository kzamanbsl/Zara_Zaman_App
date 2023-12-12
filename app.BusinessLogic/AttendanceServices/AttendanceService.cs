using app.EntityModel.AppModels;
using app.EntityModel.CoreModel;
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

        public async Task<int> AddRecord(AttendanceViewModel model)
        {
            var user = await _iWorkContext.GetCurrentAdminUserAsync();
            var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Id==model.Id && f.EmployeeId==model.EmployeeId);
            if (checkName == null)
            {
                Attendance com = new Attendance();
                com.EmployeeId = model.EmployeeId;
                //com.AttendanceLogId = model.AttendanceLogId;
                com.AttendanceDate= model.AttendanceDate;
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

        public async Task<AttendanceViewModel> GetAllRecord()
        {
            AttendanceViewModel model = new AttendanceViewModel();
            model.AttendanceList = await Task.Run(() => (from t1 in _dbContext.Attendance
                                                                where t1.IsActive == true
                                                                select new AttendanceViewModel
                                                                {
                                                                    Id = t1.Id,
                                                                    AttendanceDate = t1.AttendanceDate,
                                                                    LoginTime= t1.LoginTime,
                                                                    LogoutTime= t1.LogoutTime,
                                                                    Remarks= t1.Remarks,
                                                                    EmployeeCode = _dbContext.LeaveCategory.FirstOrDefault(f => f.Id == t1.EmployeeId).Name,
                                                                    //AttendanceLogId= t1.AttendanceLogId,
                                                                }).AsQueryable());
            return model;
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

        public async Task<int> UpdateRecord(AttendanceViewModel model)
        {

            var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Id==model.Id && f.EmployeeId==model.EmployeeId);
            if (checkName == null)
            {
                var result = await _iEntityRepository.GetByIdAsync(model.Id);
                result.EmployeeId = model.EmployeeId;
                //result.AttendanceLogId = model.AttendanceLogId;
                result.AttendanceDate= model.AttendanceDate;
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
