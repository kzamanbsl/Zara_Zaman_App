using app.EntityModel.AppModels.AttendanceModels;
using app.EntityModel.DataTablePaginationModels;
using app.Infrastructure;
using app.Infrastructure.Auth;
using app.Infrastructure.Repository;
using app.Services.AttendanceLogServices;
using app.Services.ProductServices;
using Microsoft.EntityFrameworkCore;

namespace app.Services.AttendanceServices
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IEntityRepository<Attendance> _iEntityRepository;
        private readonly InventoryDbContext _dbContext;
        private readonly IWorkContext _iWorkContext;
        private readonly IAttendanceLogService _iAttendanceLogService;

        public AttendanceService(IEntityRepository<Attendance> iEntityRepository, InventoryDbContext dbContext, IWorkContext iWorkContext, IAttendanceLogService iAttendanceLogService)
        {
            _iEntityRepository = iEntityRepository;
            _dbContext = dbContext;
            _iWorkContext = iWorkContext;
            _iAttendanceLogService = iAttendanceLogService;
        }



        public async Task<bool> AddRecord(AttendanceViewModel vm)
        {
           
            bool result = false;

            Attendance model = new Attendance();
            model.Id = vm.Id;
            model.EmployeeId = vm.EmployeeId;
            model.ShiftId = vm.ShiftId;
            model.AttendanceDate = vm.AttendanceDate;
            model.LoginTime = vm.LoginTime;
            model.LogoutTime = null;
            model.Remarks = vm.Remarks;
            var res = await _iEntityRepository.AddAsync(model);
            result = true;

            if (res.Id > 0)
            {
                vm.Id = res.Id;
                AttendanceLogViewModel models = new AttendanceLogViewModel();
                models.AttendanceId = vm.Id;
                models.LoginTime = vm.LoginTime;
                models.Remarks = vm.Remarks;
                var logRes = await _iAttendanceLogService.AddRecord(models);
                result = true;
            }

            return result;
        }

        public async Task<bool> UpdateRecord(AttendanceViewModel vm)
        {
            bool result = false;

            if (vm.Id <= 0) { return false; }

            var response = await _iEntityRepository.GetByIdAsync(vm.Id);
            if (response == null || response.Id <= 0) { return false; }

            response.EmployeeId = vm.EmployeeId;
            response.ShiftId = vm.ShiftId;
            response.AttendanceDate = vm.AttendanceDate;
            if (vm.IsLogin)
            {
                response.LogoutTime = vm.LogoutTime;
            }
            else
            {
                response.LogoutTime = vm.LoginTime;
            }

            response.Remarks = vm.Remarks;
            var res = await _iEntityRepository.UpdateAsync(response);

            if (res == true)
            {

                AttendanceLogViewModel models = new AttendanceLogViewModel();
                models.AttendanceId = vm.Id;
                if (vm.IsLogin)
                {
                    models.LogoutTime = vm.LogoutTime;
                }
                else
                {
                    models.LogoutTime = vm.LoginTime;
                }
                models.Remarks = vm.Remarks;
                var logRes = await _iAttendanceLogService.AddRecord(models);
                result = true;
            }
            return result;

        }

        public async Task<AttendanceViewModel> GetRecordById(long id)
        {
            var result = await _iEntityRepository.GetByIdAsync(id);
            AttendanceViewModel model = new AttendanceViewModel();
            model.Id = result.Id;
            model.EmployeeId = result.EmployeeId;
            model.ShiftId = result.ShiftId;
            model.AttendanceDate = result.AttendanceDate;
            model.LoginTime = result.LoginTime;
            model.LogoutTime = result.LogoutTime;
            model.Remarks = result.Remarks;
            return model;
        }

        public async Task<AttendanceViewModel> CheckEmployeeTodaysAttendance(long employeeId, DateTime date)
        {
            AttendanceViewModel vm = new AttendanceViewModel();

            if (employeeId < 0)
            {
                return vm;
            }
            vm.EmployeeId = employeeId;
            vm.AttendanceDate = date;

            var result = await _dbContext.Attendance.FirstOrDefaultAsync(c => c.EmployeeId == employeeId && c.AttendanceDate.Date == date.Date);

            if (result != null && result.Id > 0)
            {
                var logResult = await _dbContext.AttendanceLog.Where(c => c.AttendanceId == result.Id && c.IsActive == true).OrderByDescending(c => c.AttendanceId).FirstOrDefaultAsync();
                vm.Id = result.Id;
                vm.EmployeeId = result.EmployeeId;
                vm.ShiftId = result.ShiftId;
                vm.AttendanceDate = result.AttendanceDate;
                vm.LoginTime = result.LoginTime;
                vm.LogoutTime = result.LogoutTime;
                vm.Remarks = result.Remarks;
                vm.IsLogin = logResult.LogoutTime != null ? true : false;
            }

            return vm;
        }
        
        public async Task<bool> DeleteRecord(long id)
        {
            var result = await _iEntityRepository.GetByIdAsync(id)
;
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
                                                             EmployeeId = t1.EmployeeId,
                                                             EmployeeName = t1.Employee.Name,
                                                             ShiftId = t1.ShiftId,
                                                             ShiftName = t1.Shift.Name,
                                                             AttendanceDate = t1.AttendanceDate,
                                                             LoginTime = t1.LoginTime,
                                                             LogoutTime = t1.LogoutTime,
                                                             Remarks = t1.Remarks,
                                                         }).AsEnumerable());
            return model;
        }

        public async Task<DataTablePagination<AttendanceSearchDto>> SearchAsync(DataTablePagination<AttendanceSearchDto> searchDto)
        {
            var searchResult = _dbContext.Attendance.Include(c => c.Employee).Include(c => c.Shift).Where(c => c.IsActive == true).AsNoTracking();

            var searchModel = searchDto.SearchVm;
            var filter = searchDto?.Search?.Value?.Trim();
            if (searchModel?.EmployeeId is > 0)
            {
                searchResult = searchResult.Where(c => c.EmployeeId == searchModel.EmployeeId);
            }
            if (searchModel?.ShiftId is > 0)
            {
                searchResult = searchResult.Where(c => c.ShiftId == searchModel.ShiftId);
            }
            if (!string.IsNullOrEmpty(filter))
            {
                filter = filter.ToLower();
                searchResult = searchResult.Where(c =>
                    c.Employee.Name.ToLower().Contains(filter)
                    || c.AttendanceDate.ToString().Contains(filter)
                    || c.LoginTime.ToString().Contains(filter)
                    || c.Shift.Name.ToLower().Contains(filter)
                );
            }

            var pageSize = searchDto.Length ?? 0;
            var skip = searchDto.Start ?? 0;

            var totalRecords = searchResult.Count();
            if (totalRecords <= 0) return searchDto;

            searchDto.RecordsTotal = totalRecords;
            searchDto.RecordsFiltered = totalRecords;
            List<Attendance> filteredDataList = await searchResult.OrderByDescending(c => c.Id).Skip(skip).Take(pageSize).ToListAsync();

            var sl = searchDto.Start ?? 0;
            searchDto.Data = filteredDataList.Select(c => new AttendanceSearchDto()
            {
                SerialNo = ++sl,
                Id = c.Id,
                EmployeeId = c.EmployeeId,
                EmployeeName = c.Employee.Name,
                ShiftId = c.ShiftId,
                ShiftName = c.Shift.Name,
                AttendanceDate = c.AttendanceDate,
                LoginTime = c.LoginTime,
                LogoutTime = c.LogoutTime,
                Remarks = c.Remarks,
            }).ToList();

            return searchDto;
        }
    }
}