﻿using app.EntityModel.AppModels.Attendance;
using app.Infrastructure.Auth;
using app.Infrastructure.Repository;
using app.Infrastructure;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using app.EntityModel.AppModels.BankManage;
using app.EntityModel.DataTablePaginationModels;
using app.EntityModel.AppModels.Office;
using app.Services.DepartmentServices;
using Microsoft.EntityFrameworkCore;
using app.EntityModel.AppModels;
namespace app.Services.BankServices
{
    public class BankService : IBankService
    {
        private readonly IEntityRepository<EntityModel.AppModels.BankManage.Bank> _iEntityRepository;
        private readonly InventoryDbContext _dbContext;
        private readonly IWorkContext _iWorkContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BankService(IEntityRepository<EntityModel.AppModels.BankManage.Bank> iEntityRepository, InventoryDbContext dbContext, IHttpContextAccessor httpContextAccessor, IWorkContext iWorkContext)
        {
            _iEntityRepository = iEntityRepository;
            _dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;
            _iWorkContext = iWorkContext;
        }

        public async Task<bool> AddRecord(BankViewModel vm)
        {
            var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Name.Trim() == vm.Name.Trim() && f.IsActive == true);
            if (checkName == null)
            {
                var com = new Bank();
                com.Name = vm.Name;
                var res = await _iEntityRepository.AddAsync(com);
                vm.Id = res.Id;
                return true;
            }
            return false;
        }
        public async Task<bool> UpdateRecord(BankViewModel vm)
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
        public async Task<BankViewModel> GetRecordById(long id)
        {
            var result = await _iEntityRepository.GetByIdAsync(id);
            BankViewModel model = new BankViewModel();
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
        public async Task<BankViewModel> GetAllRecord()
        {
            BankViewModel model = new BankViewModel();
            //model.DepartmentList = await Task.Run(() => (from t1 in _dbContext.Department
            //                                             where t1.IsActive == true
            //                                             select new DepartmentViewModel
            //                                             {
            //                                                 Id = t1.Id,
            //                                                 Name = t1.Name,
            //                                             }).AsEnumerable());
            return model;
        }

        public async Task<DataTablePagination<BankSearchDto>> SearchAsync(DataTablePagination<BankSearchDto> searchDto)
        {
            var searchResult = _dbContext.Department.Where(c => c.IsActive == true).AsNoTracking();

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
            List<Department> filteredDataList = await searchResult.OrderByDescending(c => c.Id).Skip(skip).Take(pageSize).ToListAsync();

            var sl = searchDto.Start ?? 0;
            searchDto.Data = filteredDataList.Select(c => new BankSearchDto()
            {
                SerialNo = ++sl,
                Id = c.Id,
                Name = c.Name,

            }).ToList();

            return searchDto;
        }
    }
}