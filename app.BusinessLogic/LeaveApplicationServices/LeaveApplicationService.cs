using app.EntityModel.AppModels;
using app.Infrastructure.Auth;
using app.Infrastructure.Repository;
using app.Infrastructure;
using app.Services.LeaveApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<int> AddRecord(LeaveApplicationViewModel model)
        {
            var user = await _iWorkContext.GetCurrentAdminUserAsync();
            var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Id == model.Id);
            if (checkName == null)
            {
                LeaveApplication com = new LeaveApplication();
                com.Id = model.Id;
                com.ManagerName = model.ManagerName;
                com.LeaveCategory = model.LeaveCategory;
                com.StartDate = model.StartDate;
                com.EndDate = model.EndDate;
                com.LeaveDays = model.LeaveDays;
                com.LeaveDue = model.LeaveDue;
                com.Reason = model.Reason;
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

        public async Task<LeaveApplicationViewModel> GetAllRecord()
        {
            LeaveApplicationViewModel model = new LeaveApplicationViewModel();
            model.LeaveApplicationList = await Task.Run(() => (from t1 in _dbContext.LeaveApplication
                                                               where t1.IsActive == true
                                                               select new LeaveApplicationViewModel
                                                               {
                                                                   Id = t1.Id,
                                                                   ManagerName = t1.ManagerName,
                                                                   LeaveCategory = t1.LeaveCategory,
                                                                   StartDate = t1.StartDate,
                                                                   EndDate = t1.EndDate,
                                                                   LeaveDays = t1.LeaveDays,
                                                                   LeaveDue = t1.LeaveDue,
                                                                   Reason = t1.Reason,
                                                                   Remarks = t1.Remarks
                                                               }).AsQueryable());
            return model;
        }

        public async Task<LeaveApplicationViewModel> GetRecordById(long id)
        {
            var result = await _iEntityRepository.GetByIdAsync(id);
            LeaveApplicationViewModel model = new LeaveApplicationViewModel();
            model.Id = result.Id;
            model.ManagerName = result.ManagerName;
            model.LeaveCategory = result.LeaveCategory;
            model.StartDate = result.StartDate;
            model.EndDate = result.EndDate;
            model.LeaveDays = result.LeaveDays;
            model.LeaveDue = result.LeaveDue;
            model.Reason = result.Reason;
            model.Remarks = result.Remarks;
            return model;
        }

        public async Task<int> UpdateRecord(LeaveApplicationViewModel model)
        {

            var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Id == model.Id);
            if (checkName == null)
            {
                var result = await _iEntityRepository.GetByIdAsync(model.Id);
                result.ManagerName = model.ManagerName;
                result.LeaveCategory = model.LeaveCategory;
                result.StartDate = model.StartDate;
                result.EndDate = model.EndDate;
                result.LeaveDays = model.LeaveDays;
                result.LeaveDue = model.LeaveDue;
                result.Reason = model.Reason;
                result.Remarks = model.Remarks;
                await _iEntityRepository.UpdateAsync(result);
                return 2;
            }
            return 1;
        }
    }
}
