using app.Infrastructure.Auth;
using app.Infrastructure.Repository;
using app.Infrastructure;
using app.Utility;
using app.EntityModel.DataTablePaginationModels;
using app.Services.ProductServices;
using Microsoft.EntityFrameworkCore;
using app.EntityModel.AppModels.LeaveModels;

namespace app.Services.LeaveCategoryServices
{
    public class LeaveCategoryService : ILeaveCategoryService
    {
        private readonly IEntityRepository<LeaveCategory> _iEntityRepository;
        private readonly InventoryDbContext _dbContext;
        private readonly IWorkContext _iWorkContext;

        public LeaveCategoryService(IEntityRepository<LeaveCategory> iEntityRepository, InventoryDbContext dbContext,
            IWorkContext iWorkContext)
        {
            _iEntityRepository = iEntityRepository;
            _dbContext = dbContext;
            _iWorkContext = iWorkContext;
        }

        public async Task<bool> AddRecord(LeaveCategoryViewModel vm)
        {
            var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Id == vm.Id && f.IsActive == true);
            if (checkName == null)
            {
                LeaveCategory com = new LeaveCategory();
                com.Name = vm.Name;
                var res = await _iEntityRepository.AddAsync(com);
                vm.Id = res.Id;
                return true;
            }

            return false;
        }
        public async Task<bool> UpdateRecord(LeaveCategoryViewModel vm)
        {
            var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Name.Trim() == vm.Name.Trim() && f.Id != vm.Id && f.IsActive == true);
            if (checkName == null)
            {
                var result = await _iEntityRepository.GetByIdAsync(vm.Id);
                result.Name = vm.Name;
                await _iEntityRepository.UpdateAsync(result);
                return true;
            }

            return false;
        }
        public async Task<LeaveCategoryViewModel> GetRecordById(long id)
        {
            var result = await _iEntityRepository.GetByIdAsync(id);
            LeaveCategoryViewModel model = new LeaveCategoryViewModel();
            model.Id = result.Id;
            model.Name = result.Name;
            return model;
        }
        public async Task<bool> DeleteRecord(long id)
        {
            var result = await _iEntityRepository.GetByIdAsync(id);
            result.IsActive = false;
            await _iEntityRepository.UpdateAsync(result);
            return true;
        }
        public async Task<LeaveCategoryViewModel> GetAllRecord()
        {
            LeaveCategoryViewModel model = new LeaveCategoryViewModel();
            model.LeaveCategoryList = await Task.Run(() => (from t1 in _dbContext.LeaveCategory
                                                            where t1.IsActive == true
                                                            select new LeaveCategoryViewModel
                                                            {
                                                                Id = t1.Id,
                                                                Name = t1.Name,
                                                            }).AsEnumerable());
            return model;
        }

        public async Task<DataTablePagination<LeaveCategorySearchDto>> SearchAsync(DataTablePagination<LeaveCategorySearchDto> searchDto)
        {
            var searchResult = _dbContext.LeaveCategory.Where(c => c.IsActive == true).AsNoTracking();

            var searchModel = searchDto.SearchVm;
            var filter = searchDto?.Search?.Value?.Trim();

            if (!string.IsNullOrEmpty(filter))
            {
                filter = filter.ToLower();
                searchResult = searchResult.Where(c =>
                    c.Name.ToLower().Contains(filter)
                   
                );
            }

            var pageSize = searchDto.Length ?? 0;
            var skip = searchDto.Start ?? 0;

            var totalRecords = searchResult.Count();
            if (totalRecords <= 0) return searchDto;

            searchDto.RecordsTotal = totalRecords;
            searchDto.RecordsFiltered = totalRecords;
            List<LeaveCategory> filteredDataList = await searchResult.OrderByDescending(c => c.Id).Skip(skip).Take(pageSize).ToListAsync();

            var sl = searchDto.Start ?? 0;
            searchDto.Data = filteredDataList.Select(c => new LeaveCategorySearchDto()
            {
                SerialNo = ++sl,
                Id = c.Id,
                Name = c.Name,
            }).ToList();

            return searchDto;
        }
    }
}
