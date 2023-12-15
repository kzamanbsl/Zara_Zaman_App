using app.EntityModel.AppModels;
using app.Infrastructure.Auth;
using app.Infrastructure.Repository;
using app.Infrastructure;
using app.Utility;

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
                com.StatusId = (int)LeaveApplicationStatusEnum.Draft ;
                var res = await _iEntityRepository.AddAsync(com);
                vm.Id=res.Id;
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateRecord(LeaveApplicationViewModel vm)
        {

            var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Id == vm.Id);
            if (checkName == null)
            {
                var result = await _iEntityRepository.GetByIdAsync(vm.Id);
                result.EmployeeId = vm.EmployeeId;
                result.Employee.Name = vm.EmployeeName;
                result.ManagerId = vm.ManagerId;
                result.Manager.Name = vm.ManagerName;
                result.LeaveCategoryId = vm.LeaveCategoryId;
                result.LeaveCategory.Name = vm.LeaveCategoryName;
                result.StartDate = vm.StartDate;
                result.EndDate = vm.EndDate;
                result.LeaveDays = vm.LeaveDays;
                result.StayDuringLeave = vm.StayDuringLeave;
                result.Reason = vm.Reason;
                result.Remarks = vm.Remarks;
                result.StatusId = vm.StatusId;
                result.Employee.Name = vm.StatusName;
                await _iEntityRepository.UpdateAsync(result);
                return true;
            }
            return false;
        }
        public async Task<LeaveApplicationViewModel> GetRecordById(long id)
        {
            var result = await _iEntityRepository.GetByIdAsync(id);
            LeaveApplicationViewModel model = new LeaveApplicationViewModel();
            model.Id = result.Id;
            model.EmployeeId = result.EmployeeId;
            model.ManagerId = result.ManagerId;
            model.LeaveCategoryId = result.LeaveCategoryId;
            model.StartDate = result.StartDate;
            model.EndDate = result.EndDate;
            model.LeaveDays = result.LeaveDays;
            model.StayDuringLeave = result.StayDuringLeave;
            model.Reason = result.Reason;
            model.Remarks = result.Remarks;
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
                        ManagerId = t1.ManagerId,
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
                    };

                return query.AsQueryable();
            });

            return model;
        }

        public async Task<bool> ConfirmRecord(long id)
        {
            var result = await _iEntityRepository.GetByIdAsync(id);
            if (result == null)
            {
                throw new Exception("Sorry! No Data Found.");
            }

            result.StatusId = (int)LeaveApplicationStatusEnum.Confirm;
            await _iEntityRepository.UpdateAsync(result);
            return true;
        }

        public async Task<bool> ApproveRecord(long id)
        {
            var result = await _iEntityRepository.GetByIdAsync(id);
            if (result == null)
            {
                throw new Exception("Sorry! No Data Found.");
            }

            result.StatusId = (int)LeaveApplicationStatusEnum.Approve;
            await _iEntityRepository.UpdateAsync(result);
            return true;
        }
       
        public async Task<bool> RejectRecord(long id)
        {
            var result = await _iEntityRepository.GetByIdAsync(id);
            if (result == null)
            {
                throw new Exception("Sorry! No Data Found.");
            }

            result.StatusId = (int)LeaveApplicationStatusEnum.Reject;
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

    }
}
