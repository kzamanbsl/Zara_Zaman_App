using app.EntityModel.AppModels;
using app.Infrastructure.Auth;
using app.Infrastructure.Repository;
using app.Infrastructure;
using app.Utility;
using app.EntityModel.DataTablePaginationModels;
using app.Services.EmployeeCategoryServices;
using Microsoft.EntityFrameworkCore;

namespace app.Services.OfficeTypeServices
{
    public class OfficeTypeService : IOfficeTypeService
    {
        private readonly IEntityRepository<OfficeType> _iEntityRepository;
        private readonly InventoryDbContext _dbContext;
        private readonly IWorkContext _iWorkContext;
        public OfficeTypeService(IEntityRepository<OfficeType> iEntityRepository, InventoryDbContext dbContext, IWorkContext iWorkContext)
        {
            _iEntityRepository = iEntityRepository;
            _dbContext = dbContext;
            _iWorkContext = iWorkContext;
        }

        public async Task<bool> AddRecord(OfficeTypeViewModel vm)
        {
            //var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Name.Trim() == vm.Name.Trim());
            var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Id == vm.Id && f.IsActive == true);
            if (checkName == null)
            {
                OfficeType com = new OfficeType();
                com.Name = vm.Name;
                var res = await _iEntityRepository.AddAsync(com);
                vm.Id=res.Id;
                return true;
            }
            return false;
        }
        public async Task<bool> UpdateRecord(OfficeTypeViewModel vm)
        {

            //var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Name.Trim() == vm.Name.Trim());
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
       
        public async Task<OfficeTypeViewModel> GetRecordById(long id)
        {
            var result = await _iEntityRepository.GetByIdAsync(id);
            OfficeTypeViewModel model = new OfficeTypeViewModel();
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
        public async Task<OfficeTypeViewModel> GetAllRecord()
        {
            OfficeTypeViewModel model = new OfficeTypeViewModel();
            model.OfficeTypeList = await Task.Run(() => (from t1 in _dbContext.OfficeType
                                                         where t1.IsActive == true
                                                         select new OfficeTypeViewModel
                                                         {
                                                             Id = t1.Id,
                                                             Name = t1.Name,
                                                         }).AsEnumerable());
            return model;
        }

        public async Task<DataTablePagination<OfficeTypeSearchDto>> SearchAsync(DataTablePagination<OfficeTypeSearchDto> searchDto)
        {
            var searchResult = _dbContext.OfficeType.AsNoTracking();

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

            var totalRecords = await searchResult.CountAsync();
            if (totalRecords <= 0) return searchDto;

            searchDto.RecordsTotal = totalRecords;
            searchDto.RecordsFiltered = totalRecords;
            List<OfficeType> filteredDataList = await searchResult.OrderByDescending(c => c.Id).Skip(skip).Take(pageSize).ToListAsync();

            var sl = searchDto.Start ?? 0;
            searchDto.Data = filteredDataList.Select(c => new OfficeTypeSearchDto()
            {
                SerialNo = ++sl,
                Id = c.Id,
                Name = c.Name,

            }).ToList();

            return searchDto;
        }
    }
}
