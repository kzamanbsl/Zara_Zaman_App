using app.EntityModel.AppModels;
using app.EntityModel.DataTablePaginationModels;
using app.Infrastructure;
using app.Infrastructure.Auth;
using app.Infrastructure.Repository;
using app.Services.ProductCategoryServices;
using app.Utility;
using Microsoft.EntityFrameworkCore;

namespace app.Services.StorehouseServices
{
    public class StorehouseService : IStorehouseService
    {
        private readonly IEntityRepository<BusinessCenter> _iEntityRepository;
        private readonly InventoryDbContext _dbContext;
        private readonly IWorkContext _iWorkContext;
        public StorehouseService(IEntityRepository<BusinessCenter> iEntityRepository, InventoryDbContext dbContext, IWorkContext iWorkContext)
        {
            _iEntityRepository = iEntityRepository;
            _dbContext = dbContext;
            _iWorkContext = iWorkContext;
        }

        public async Task<bool> AddRecord(StorehouseViewModel vm)
        {
            //var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Name.Trim() == vm.Name.Trim());
            var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Name.Trim() == vm.Name.Trim() && f.IsActive == true);
            if (checkName == null)
            {
                BusinessCenter storehouse = new BusinessCenter();
                storehouse.Name = vm.Name;
                storehouse.Code = vm.Code;
                storehouse.Location = vm.Location;
                storehouse.Description = vm.Description;
                storehouse.BusinessCenterTypeId=(int)BusinessCenterEnum.Storehouse;
                var res = await _iEntityRepository.AddAsync(storehouse);
                vm.Id = res.Id;
                return true;
            }
            return false;
        }
        public async Task<bool> UpdateRecord(StorehouseViewModel vm)
        {

            // var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Id == vm.Id);
            var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Name.Trim() == vm.Name.Trim() && f.Id != vm.Id && f.IsActive == true);
            if (checkName == null)
            {
                var storehouse = await _iEntityRepository.GetByIdAsync(vm.Id);
                storehouse.Name = vm.Name;
                storehouse.Code = vm.Code;
                storehouse.Location = vm.Location;
                storehouse.Description = vm.Description;
                storehouse.BusinessCenterTypeId = (int)BusinessCenterEnum.Storehouse;
                await _iEntityRepository.UpdateAsync(storehouse);
                return true;
            }
            return false;
        }
        public async Task<StorehouseViewModel> GetRecordById(long id)
        {
            var result = await _iEntityRepository.GetByIdAsync(id);
            StorehouseViewModel model = new StorehouseViewModel();
            model.Id = result.Id;
            model.Code = result.Code;
            model.Name = result.Name;
            model.Location = result.Location;
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
        public async Task<StorehouseViewModel> GetAllRecord()
        {
            StorehouseViewModel model = new StorehouseViewModel();
            model.StorehouseList = await Task.Run(() => (from t1 in _dbContext.BusinessCenter
                                                         where t1.BusinessCenterTypeId == (int)BusinessCenterEnum.Storehouse && t1.IsActive == true
                                                         select new StorehouseViewModel
                                                         {
                                                             Id = t1.Id,
                                                             Name = t1.Name,
                                                             Code = t1.Code,
                                                             Location = t1.Location,
                                                             Description = t1.Description,
                                                         }).AsEnumerable());
            return model;
        }

        public async Task<DataTablePagination<StorehouseSearchDto>> SearchAsync(DataTablePagination<StorehouseSearchDto> searchDto)
        {
           var  searchResult = _dbContext.BusinessCenter.Where(c=>c.IsActive==true && c.BusinessCenterTypeId == (int)BusinessCenterEnum.Storehouse).AsNoTracking();

            var searchModel = searchDto.SearchVm;
            var filter = searchDto?.Search?.Value?.Trim();

            if (!string.IsNullOrEmpty(filter))
            {
                filter = filter.ToLower();
                searchResult = searchResult.Where(c =>
                    c.Name.ToLower().Contains(filter)
                    || c.Code.ToLower().Contains(filter)
                    || c.Location.ToLower().Contains(filter)
                    || c.Description.ToLower().Contains(filter)
                );
            }

            var pageSize = searchDto.Length ?? 0;
            var skip = searchDto.Start ?? 0;

            var totalRecords = searchResult.Count();
            if (totalRecords <= 0) return searchDto;

            searchDto.RecordsTotal = totalRecords;
            searchDto.RecordsFiltered = totalRecords;
            List<BusinessCenter> filteredDataList = await searchResult.OrderByDescending(c => c.Id).Skip(skip).Take(pageSize).ToListAsync();

            var sl = searchDto.Start ?? 0;
            searchDto.Data = filteredDataList.Select(c => new StorehouseSearchDto()
            {
                SerialNo = ++sl,
                Id = c.Id,
                Name = c.Name,
                Location = c.Location,
                Description = c.Description,
            }).ToList();

            return searchDto;
        }
    }
}
