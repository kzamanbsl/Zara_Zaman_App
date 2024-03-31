using app.EntityModel.AppModels;
using app.EntityModel.DataTablePaginationModels;
using app.Infrastructure;
using app.Infrastructure.Auth;
using app.Infrastructure.Repository;
using app.Services.UnitServices;
using app.Utility;
using Microsoft.EntityFrameworkCore;

namespace app.Services.SupplierCategoryServices
{
    public class SupplierCategoryService : ISupplierCategoryService
    {
        private readonly IEntityRepository<SupplierCategory> _iEntityRepository;
        private readonly InventoryDbContext _dbContext;
        private readonly IWorkContext _iWorkContext;
        public SupplierCategoryService(IEntityRepository<SupplierCategory> iEntityRepository, InventoryDbContext dbContext, IWorkContext iWorkContext)
        {
            _iEntityRepository = iEntityRepository;
            _dbContext = dbContext;
            _iWorkContext = iWorkContext;
        }

        public async Task<bool> AddRecord(SupplierCategoryViewModel vm)
        {
            var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Id == vm.Id && f.IsActive == true);
            if (checkName == null)
            {
                SupplierCategory com = new SupplierCategory();
                com.Name = vm.Name;
                var res = await _iEntityRepository.AddAsync(com);
                vm.Id=res.Id;
                return true;
            }
            return false;
        }
        public async Task<bool> UpdateRecord(SupplierCategoryViewModel vm)
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
        public async Task<SupplierCategoryViewModel> GetRecordById(long id)
        {
            var result = await _iEntityRepository.GetByIdAsync(id);
            SupplierCategoryViewModel model = new SupplierCategoryViewModel();
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
        public async Task<SupplierCategoryViewModel> GetAllRecord()
        {
            SupplierCategoryViewModel model = new SupplierCategoryViewModel();
            model.SupplierCategoryList = await Task.Run(() => (from t1 in _dbContext.SupplierCategory
                                                                where t1.IsActive == true
                                                                select new SupplierCategoryViewModel
                                                                {
                                                                    Id = t1.Id,
                                                                    Name = t1.Name,
                                                                }).AsEnumerable());
            return model;
        }

        public async Task<DataTablePagination<SupplierCategorySearchDto>> SearchAsync(DataTablePagination<SupplierCategorySearchDto> searchDto)
        {
            var searchResult = _dbContext.SupplierCategory.Where(c=>c.IsActive==true).AsNoTracking();

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
            List<SupplierCategory> filteredDataList = await searchResult.OrderByDescending(c => c.Id).Skip(skip).Take(pageSize).ToListAsync();

            var sl = searchDto.Start ?? 0;
            searchDto.Data = filteredDataList.Select(c => new SupplierCategorySearchDto()
            {
                SerialNo = ++sl,
                Id = c.Id,
                Name = c.Name,
            }).ToList();

            return searchDto;
        }
    }
}
