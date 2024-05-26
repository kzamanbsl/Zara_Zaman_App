using app.EntityModel.AppModels.BankModels;
using app.EntityModel.AppModels.SupplierModels;
using app.EntityModel.DataTablePaginationModels;
using app.Infrastructure;
using app.Infrastructure.Repository;
using app.Services.DepartmentServices;
using app.Services.SupplierServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Services.BankBranchServices
{
    public class BankBranchService : IBankBranchService
    {
        private readonly IEntityRepository<BankBranch> _iEntityRepository;
        private readonly InventoryDbContext _dbContext;

        public BankBranchService(IEntityRepository<BankBranch> IEntityRepository,InventoryDbContext inventoryDbContext)
        {
            _iEntityRepository= IEntityRepository;
            _dbContext= inventoryDbContext;
        }
        public async  Task<bool> AddRecord(BankBranchViewModel vm)
        {

            var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Name.Trim() == vm.Name.Trim() && f.BankId== vm.BankId && f.IsActive == true);
            if (checkName == null)
            {
                BankBranch com = new BankBranch();
                com.Name = vm.Name;
                com.BankId=vm.BankId;
                com.Address = vm.Address;
                var res = await _iEntityRepository.AddAsync(com);
                vm.Id = res.Id;
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateRecord(BankBranchViewModel vm)
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
        public async Task<BankBranchViewModel> GetRecordById(long id)
        {
            var result = await _iEntityRepository.GetByIdAsync(id);
            BankBranchViewModel model = new BankBranchViewModel();
            model.Id = result.Id;
            model.Name = result.Name;
            model.Address = result.Address;
            model.BankId= result.BankId;
            return model;
        }
        public async Task<bool> DeleteRecord(long id)
        {
            var result = await _iEntityRepository.GetByIdAsync(id);
            result.IsActive = false;
            await _iEntityRepository.UpdateAsync(result);
            return true;
        }
        public async Task<BankBranchViewModel> GetAllRecord()
        {
            BankBranchViewModel model = new BankBranchViewModel();
            model.BranchList = await Task.Run(() => (from t1 in _dbContext.BankBranch
                                                         where t1.IsActive == true
                                                         select new BankBranchViewModel
                                                         {
                                                             Id = t1.Id,
                                                             Name = t1.Name,
                                                         }).AsEnumerable());
            return model;
        }
        public async  Task<DataTablePagination<BankBranchSearchDto>> SearchAsync(DataTablePagination<BankBranchSearchDto> searchDto)
        {
            var searchResult = _dbContext.BankBranch.Where(c => c.IsActive == true).Include(c => c.Bank).AsNoTracking();

            var searchModel = searchDto.SearchVm;
            var filter = searchDto?.Search?.Value?.Trim();
            //if (searchModel?.CountryId is > 0)
            //{
            //    searchResult = searchResult.Where(c => c.CountryId == searchModel.CountryId);
            //}
            //if (searchModel?.DivisionId is > 0)
            //{
            //    searchResult = searchResult.Where(c => c.DivisionId == searchModel.DivisionId);
            //}
            //if (searchModel?.DistrictId is > 0)
            //{
            //    searchResult = searchResult.Where(c => c.DistrictId == searchModel.DistrictId);
            //}
            //if (searchModel?.UpazilaId is > 0)
            //{
            //    searchResult = searchResult.Where(c => c.UpazilaId == searchModel.UpazilaId);
            //}
            if (!string.IsNullOrEmpty(filter))
            {
                filter = filter.ToLower();
                searchResult = searchResult.Where(c =>
                    c.Bank.Name.ToLower().Contains(filter)
                    || c.Name.ToLower().Contains(filter)
                    || c.Address.ToLower().Contains(filter)
                );
            }

            var pageSize = searchDto.Length ?? 0;
            var skip = searchDto.Start ?? 0;

            var totalRecords = searchResult.Count();
            if (totalRecords <= 0) return searchDto;

            searchDto.RecordsTotal = totalRecords;
            searchDto.RecordsFiltered = totalRecords;
            List<BankBranch> filteredDataList = await searchResult.OrderByDescending(c => c.Id).Skip(skip).Take(pageSize).ToListAsync();

            var sl = searchDto.Start ?? 0;
            searchDto.Data = filteredDataList.Select(c => new BankBranchSearchDto()
            {
                SerialNo = ++sl,
                Id = c.Id,
                BankName = c.Bank.Name,
                BranchName = c.Name,
                Address = c.Address,
            }).ToList();

            return searchDto;
        }

       
    }
}
