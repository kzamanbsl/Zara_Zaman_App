using app.Infrastructure.Auth;
using app.Infrastructure.Repository;
using app.Infrastructure;
using app.EntityModel.DataTablePaginationModels;
using app.Services.ProductServices;
using Microsoft.EntityFrameworkCore;
using app.EntityModel.AppModels.Sales;

namespace app.Services.SalesTermsAndConditonServices
{
    public class SalesTermsAndConditionService : ISalesTermsAndConditionService
    {
        private readonly IEntityRepository<SalesTermsAndCondition> _iEntityRepository;
        private readonly InventoryDbContext _dbContext;
        private readonly IWorkContext _iWorkContext;
        public SalesTermsAndConditionService(IEntityRepository<SalesTermsAndCondition> iEntityRepository, InventoryDbContext dbContext, IWorkContext iWorkContext)
        {
            _iEntityRepository = iEntityRepository;
            _dbContext = dbContext;
            _iWorkContext = iWorkContext;
        }

        public async Task<bool> AddRecord(SalesTermsAndConditionViewModel vm)
        {
           var check = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Id == vm.Id && f.IsActive == true);
            if (check == null)
            {
                SalesTermsAndCondition com = new SalesTermsAndCondition();
                com.Key = vm.Key;
                com.Value = vm.Value;
                var res = await _iEntityRepository.AddAsync(com);
                vm.Id=res.Id;
                return true;
            }
            return false;
        }
        public async Task<bool> UpdateRecord(SalesTermsAndConditionViewModel vm)
        {

            var check = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Key.Trim() == vm.Key.Trim() && f.Id != vm.Id && f.IsActive == true);
            if (check == null)
            {
                var result = await _iEntityRepository.GetByIdAsync(vm.Id);
                result.Key = vm.Key;
                result.Value = vm.Value;
                await _iEntityRepository.UpdateAsync(result);
                return true;
            }
            return false;
        }
       
        public async Task<SalesTermsAndConditionViewModel> GetRecordById(long id)
        {
            var result = await _iEntityRepository.GetByIdAsync(id);
            SalesTermsAndConditionViewModel model = new SalesTermsAndConditionViewModel();
            model.Id = result.Id;
            model.Key = result.Key;
            model.Value = result.Value;
            return model;
        }
        public async Task<bool> DeleteRecord(long id)
        {
            var result = await _iEntityRepository.GetByIdAsync(id);
            result.IsActive = false;
            await _iEntityRepository.UpdateAsync(result);
            return true;
        }

        public async Task<SalesTermsAndConditionViewModel> GetAllRecord()
        {
            SalesTermsAndConditionViewModel model = new SalesTermsAndConditionViewModel();
            model.SalesTermsAndConditionList = await Task.Run(() => (from t1 in _dbContext.SalesTermsAndCondition
                                                                     where t1.IsActive == true
                                                                     select new SalesTermsAndConditionViewModel
                                                                     {
                                                                         Id = t1.Id,
                                                                         Key = t1.Key,
                                                                         Value = t1.Value,
                                                                     }).AsEnumerable());
            return model;
        }

        public async Task<DataTablePagination<SalesTermsAndConditionSearchDto>> SearchAsync(DataTablePagination<SalesTermsAndConditionSearchDto> searchDto)
        {
            var searchResult = _dbContext.SalesTermsAndCondition.Where(c=>c.IsActive==true).AsNoTracking();

            var searchModel = searchDto.SearchVm;
            var filter = searchDto?.Search?.Value?.Trim();
          
            if (!string.IsNullOrEmpty(filter))
            {
                filter = filter.ToLower();
                searchResult = searchResult.Where(c =>
                    c.Key.ToLower().Contains(filter)
                    || c.Value.ToLower().Contains(filter)
                    
                );
            }

            var pageSize = searchDto.Length ?? 0;
            var skip = searchDto.Start ?? 0;

            var totalRecords = searchResult.Count();
            if (totalRecords <= 0) return searchDto;

            searchDto.RecordsTotal = totalRecords;
            searchDto.RecordsFiltered = totalRecords;
            List<SalesTermsAndCondition> filteredDataList = await searchResult.OrderByDescending(c => c.Id).Skip(skip).Take(pageSize).ToListAsync();

            var sl = searchDto.Start ?? 0;
            searchDto.Data = filteredDataList.Select(c => new SalesTermsAndConditionSearchDto()
            {
                SerialNo = ++sl,
                Id = c.Id,
                Key = c.Key,
                Value = c.Value,
            }).ToList();

            return searchDto;
        }

    }
}
