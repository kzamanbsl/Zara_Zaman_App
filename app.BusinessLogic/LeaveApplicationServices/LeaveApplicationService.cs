using app.EntityModel.AppModels;
using app.Infrastructure.Auth;
using app.Infrastructure.Repository;
using app.Infrastructure;
using app.Utility;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using app.Services.LeaveBalanceServices;

namespace app.Services.LeaveApplicationServices
{
    public class LeaveApplicationService : ILeaveApplicationService
    {
        private readonly IEntityRepository<LeaveApplication> _iEntityRepository;
        private readonly InventoryDbContext _dbContext;
        private readonly IWorkContext _iWorkContext;
        public LeaveApplicationService(IEntityRepository<LeaveApplication> iEntityRepository, InventoryDbContext dbContext, IWorkContext iWorkContext)
        {
            _iEntityRepository = iEntityRepository;
            _dbContext = dbContext;
            _iWorkContext = iWorkContext;
        }

        public async Task<bool> AddRecord(LeaveApplicationViewModel vm)
        {
            var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Id == vm.Id);
            if (checkName == null)
            {
                LeaveApplication com = new LeaveApplication();
                com.Id = vm.Id;
                com.EmployeeId = vm.EmployeeId;
                com.ManagerId = vm.ManagerId;
                com.LeaveCategoryId = vm.LeaveCategoryId;
                com.StartDate = vm.StartDate;
                com.EndDate = vm.EndDate;
                com.LeaveDays = vm.LeaveDays;
                com.StayDuringLeave = vm.StayDuringLeave;
                com.Reason = vm.Reason;
                com.Remarks = vm.Remarks;
                com.ApplicationDate = vm.ApplicationDate;
                com.StatusId = (int)LeaveApplicationStatusEnum.Draft;
                var res = await _iEntityRepository.AddAsync(com);
                vm.Id = res.Id;
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateRecord(LeaveApplicationViewModel vm)
        {

            var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Id == vm.Id);
            if (checkName != null)
            {
                var result = await _iEntityRepository.GetByIdAsync(vm.Id);
                result.EmployeeId = vm.EmployeeId;
                result.ManagerId = vm.ManagerId;
                result.LeaveCategoryId = vm.LeaveCategoryId;
                result.StartDate = vm.StartDate;
                result.EndDate = vm.EndDate;
                result.LeaveDays = vm.LeaveDays;
                result.StayDuringLeave = vm.StayDuringLeave;
                result.Reason = vm.Reason;
                result.Remarks = vm.Remarks;
                result.StatusId = (int)LeaveApplicationStatusEnum.Draft;
                //result.Employee.Name = vm.StatusName;
                result.ApplicationDate = vm.ApplicationDate;
                await _iEntityRepository.UpdateAsync(result);
                return true;
            }
            return false;
        }
        public async Task<LeaveApplicationViewModel> GetRecordById(long id)
        {
            //var result = await _iEntityRepository.GetByIdAsync(id);
            var result = await _dbContext.LeaveApplication.Include(c => c.Employee).Include(c => c.LeaveCategory).FirstOrDefaultAsync(c => c.Id == id);
            LeaveApplicationViewModel model = new LeaveApplicationViewModel();
            model.Id = result.Id;
            model.EmployeeId = result.EmployeeId;
            model.EmployeeName = result.Employee?.Name;
            model.ManagerId = result.ManagerId;
            model.ManagerName = result.Manager?.Name;
            model.LeaveCategoryId = result.LeaveCategoryId;
            model.LeaveCategoryName = result.LeaveCategory?.Name;
            model.StartDate = result.StartDate;
            model.EndDate = result.EndDate;
            model.LeaveDays = result.LeaveDays;
            model.StayDuringLeave = result.StayDuringLeave;
            model.Reason = result.Reason;
            model.Remarks = result.Remarks;
            model.ApplicationDate = result.ApplicationDate;
            model.StatusId = result.StatusId;
            return model;
        }
        public async Task<LeaveApplicationViewModel> GetAllRecord()
        {
            LeaveApplicationViewModel model = new LeaveApplicationViewModel();
            model.LeaveApplicationList = await Task.Run(() =>
            {
                var query = from t1 in _dbContext.LeaveApplication
                            where t1.IsActive == true
                            select new LeaveApplicationViewModel
                            {
                                Id = t1.Id,
                                EmployeeId = t1.EmployeeId,
                                EmployeeName = t1.Employee.Name,
                                ManagerName = t1.Manager.Name,
                                LeaveCategoryId = t1.LeaveCategoryId,
                                LeaveCategoryName = t1.LeaveCategory.Name,
                                StartDate = t1.StartDate,
                                EndDate = t1.EndDate,
                                LeaveDays = t1.LeaveDays,
                                StayDuringLeave = t1.StayDuringLeave,
                                Reason = t1.Reason,
                                Remarks = t1.Remarks,
                                StatusId = t1.StatusId,
                                ApplicationDate = t1.ApplicationDate,
                            };

                return query.AsQueryable();
            });

            return model;
        }
        public async Task<IEnumerable<LeaveBalanceCountViewModel>> GetLeaveBalanceByEmployeeId(long employeeId)
        {
            var result = new List<LeaveBalanceCountViewModel>();

            var leaveBalanceList = await _dbContext.LeaveBalance.Include(c=>c.LeaveCategory).Where(c => c.IsActive == true).ToListAsync();

            var leaveApplication = await _dbContext.LeaveApplication.Include(c => c.LeaveCategory).Where(c => c.EmployeeId == employeeId && c.StatusId == (int)LeaveApplicationStatusEnum.Approve).ToListAsync();

            if (leaveBalanceList?.Count <= 0) { return result; }

            foreach (var lb in leaveBalanceList)
            {
                int useLeaveQty = leaveApplication.Where(c => c.LeaveCategoryId == lb.LeaveCategoryId).Sum(s => s.LeaveDays);
                var obj = new LeaveBalanceCountViewModel()
                {
                    LeaveCategoryId = lb.LeaveCategoryId,
                    LeaveCategoryName = lb.LeaveCategory?.Name,
                    Description = lb.Description,
                    LeaveQty=lb.LeaveQty,
                    LeaveUsedQty= useLeaveQty,
                    LeaveRemainingQty=(lb.LeaveQty-useLeaveQty)
                };
                result.Add(obj);
            }

            return result;
        }
        public async Task<bool> ConfirmRecord(long id)
        {
            var leaveApplication = await _dbContext.LeaveApplication.FirstOrDefaultAsync(c => c.Id == id);

            if (leaveApplication != null && leaveApplication.StatusId == (int)LeaveApplicationStatusEnum.Draft)
            {
                leaveApplication.StatusId = (int)LeaveApplicationStatusEnum.Confirm; 
                await _iEntityRepository.UpdateAsync(leaveApplication);
                return true;
            }
            return false;
        }
        public async Task<bool> ApproveRecord(long id)
        {
            var leaveApplication = await _dbContext.LeaveApplication.FirstOrDefaultAsync(c => c.Id == id);

            if (leaveApplication != null && leaveApplication.StatusId == (int)LeaveApplicationStatusEnum.Confirm)
            {
                leaveApplication.StatusId = (int)LeaveApplicationStatusEnum.Approve;
                await _iEntityRepository.UpdateAsync(leaveApplication);
                return true;
            }
            return false;
        }
        public async Task<bool> RejectRecord(long id)
        {
            var leaveApplication = await _dbContext.LeaveApplication.FirstOrDefaultAsync(c => c.Id == id);

            if (leaveApplication != null && (leaveApplication.StatusId != (int)LeaveApplicationStatusEnum.Approve|| leaveApplication.StatusId != (int)LeaveApplicationStatusEnum.Reject))
            {
                leaveApplication.StatusId = (int)LeaveApplicationStatusEnum.Reject;
                await _iEntityRepository.UpdateAsync(leaveApplication);
                return true;
            }
            return false;
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
