using app.EntityModel.AppModels;
using app.Infrastructure.Auth;
using app.Infrastructure.Repository;
using app.Infrastructure;
using app.Services.UnitServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using app.Utility;
using app.EntityModel.DataTablePaginationModels;
using app.Services.JobStatusServices;
using Microsoft.EntityFrameworkCore;

namespace app.Services.UnitServices
{
    public class UnitService : IUnitService
    {
        private readonly IEntityRepository<Unit> _iEntityRepository;
        private readonly InventoryDbContext _dbContext;
        private readonly IWorkContext _iWorkContext;
        public UnitService(IEntityRepository<Unit> iEntityRepository, InventoryDbContext dbContext, IWorkContext iWorkContext)
        {
            _iEntityRepository = iEntityRepository;
            _dbContext = dbContext;
            _iWorkContext = iWorkContext;
        }

        public async Task<bool> AddRecord(UnitViewModel vm)
        {
            var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Name.Trim() == vm.Name.Trim() && f.IsActive == true);
            if (checkName == null)
            {
                Unit com = new Unit();
                com.Name = vm.Name;
                var res = await _iEntityRepository.AddAsync(com);
                vm.Id = res.Id;
                return true;
            }
            return false;
        }
        public async Task<bool> UpdateRecord(UnitViewModel vm)
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
        public async Task<UnitViewModel> GetRecordById(long id)
        {
            var result = await _iEntityRepository.GetByIdAsync(id);
            UnitViewModel model = new UnitViewModel();
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
        public async Task<UnitViewModel> GetAllRecord()
        {
            UnitViewModel model = new UnitViewModel();
            model.UnitList = await Task.Run(() => (from t1 in _dbContext.Unit
                                                         where t1.IsActive == true
                                                         select new UnitViewModel
                                                         {
                                                             Id = t1.Id,
                                                             Name = t1.Name,
                                                         }).AsEnumerable());
            return model;
        }

        public async Task<DataTablePagination<UnitSearchDto>> SearchAsync(DataTablePagination<UnitSearchDto> searchDto)
        {
            var searchResult = _dbContext.Unit.Where(c => c.IsActive == true).AsNoTracking();

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
            List<Unit> filteredDataList = await searchResult.OrderByDescending(c => c.Id).Skip(skip).Take(pageSize).ToListAsync();

            var sl = searchDto.Start ?? 0;
            searchDto.Data = filteredDataList.Select(c => new UnitSearchDto()
            {
                SerialNo = ++sl,
                Id = c.Id,
                Name = c.Name,
            }).ToList();

            return searchDto;
        }
    }
}
