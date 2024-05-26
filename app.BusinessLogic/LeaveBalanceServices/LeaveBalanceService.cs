using app.EntityModel.AppModels.LeaveModels;
using app.EntityModel.DataTablePaginationModels;
using app.Infrastructure;
using app.Infrastructure.Auth;
using app.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace app.Services.LeaveBalanceServices
{
    public class LeaveBalanceService : ILeaveBalanceService
    {
        private readonly IEntityRepository<LeaveBalance> _iEntityRepository;
        private readonly InventoryDbContext _dbContext;
        private readonly IWorkContext _iWorkContext;
        public LeaveBalanceService(IEntityRepository<LeaveBalance> iEntityRepository, InventoryDbContext dbContext, IWorkContext iWorkContext)
        {
            _iEntityRepository = iEntityRepository;
            _dbContext = dbContext;
            _iWorkContext = iWorkContext;
        }

        public async Task<bool> AddRecord(LeaveBalanceViewModel vm)
        {
            var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Id==vm.Id && f.IsActive==true && f.LeaveCategoryId ==vm.LeaveCategoryId);
            if (checkName == null)
            {
                LeaveBalance com = new LeaveBalance();
                com.LeaveCategoryId = vm.LeaveCategoryId;
                com.LeaveQty = vm.LeaveQty;
                com.Description=vm.Description;
                var res = await _iEntityRepository.AddAsync(com);
                vm.Id = res.Id;
                return true;
            }

            return false;
        }

        public async Task<bool> UpdateRecord(LeaveBalanceViewModel vm)
        {
            var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Id != vm.Id && f.IsActive==true && f.LeaveCategoryId == vm.LeaveCategoryId);
            if (checkName == null)
            {
                var result = await _iEntityRepository.GetByIdAsync(vm.Id);
                result.LeaveCategoryId = vm.LeaveCategoryId;
                result.LeaveQty = vm.LeaveQty;
                result.Description = vm.Description;
                await _iEntityRepository.UpdateAsync(result);
                return true;
            }
            return false;
        }
       
        public async Task<LeaveBalanceViewModel> GetRecordById(long id)
        {
            var result = await _iEntityRepository.GetByIdAsync(id);
            LeaveBalanceViewModel model = new LeaveBalanceViewModel();
            model.Id = result.Id;
            model.LeaveCategoryId = result.LeaveCategoryId;
            model.LeaveQty = result.LeaveQty;
            model.Description = result.Description;
            return model;
        }

        public async Task<bool> DeleteRecord(long id)
        {
            var result = await _iEntityRepository.GetByIdAsync(id);
            result.IsActive = false;
            await _iEntityRepository.UpdateAsync(result);
            return true;
        }

        public async Task<LeaveBalanceViewModel> GetAllRecord()
        {
            LeaveBalanceViewModel model = new LeaveBalanceViewModel();
            model.LeaveBalanceList = await Task.Run(() => (from t1 in _dbContext.LeaveBalance
                                                           where t1.IsActive == true
                                                           select new LeaveBalanceViewModel
                                                           {
                                                               Id = t1.Id,
                                                               LeaveCategoryId = t1.LeaveCategoryId,
                                                               LeaveCategoryName = t1.LeaveCategory.Name,
                                                               LeaveQty = t1.LeaveQty,
                                                               Description = t1.Description,
                                                           }).AsEnumerable());
            return model;
        }

        public async Task<DataTablePagination<LeaveBalanceSearchDto>> SearchAsync(DataTablePagination<LeaveBalanceSearchDto> searchDto)
        {
            var searchResult = _dbContext.LeaveBalance.Include(c => c.LeaveCategory).Where(c => c.IsActive == true).AsNoTracking();

            var searchModel = searchDto.SearchVm;
            var filter = searchDto?.Search?.Value?.Trim();
            if (searchModel?.LeaveCategoryId is > 0)
            {
                searchResult = searchResult.Where(c => c.LeaveCategoryId == searchModel.LeaveCategoryId);
            }
            if (!string.IsNullOrEmpty(filter))
            {
                filter = filter.ToLower();
                searchResult = searchResult.Where(c =>
                    c.LeaveCategory.Name.ToLower().Contains(filter)
                    || c.LeaveQty.ToString().ToLower().Contains(filter)
                    || c.Description.ToLower().Contains(filter)
                );
            }

            var pageSize = searchDto.Length ?? 0;
            var skip = searchDto.Start ?? 0;

            var totalRecords = searchResult.Count();
            if (totalRecords <= 0) return searchDto;

            searchDto.RecordsTotal = totalRecords;
            searchDto.RecordsFiltered = totalRecords;
            List<LeaveBalance> filteredDataList = await searchResult.OrderByDescending(c => c.Id).Skip(skip).Take(pageSize).ToListAsync();

            var sl = searchDto.Start ?? 0;
            searchDto.Data = filteredDataList.Select(c => new LeaveBalanceSearchDto()
            {
                SerialNo = ++sl,
                Id = c.Id,
                LeaveCategoryId = c.LeaveCategoryId,
                LeaveCategoryName = c.LeaveCategory?.Name,
                LeaveQty = c.LeaveQty,
                Description = c.Description,
            }).ToList();

            return searchDto;
        }

    }
}
