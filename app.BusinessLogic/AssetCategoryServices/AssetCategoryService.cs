using app.EntityModel.AppModels;
using app.Infrastructure.Auth;
using app.Infrastructure.Repository;
using app.Infrastructure;
using app.Services.AssetCategoryServices;
using app.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using app.EntityModel.DataTablePaginationModels;
using app.Services.SaleCenterServices;
using Microsoft.EntityFrameworkCore;

namespace app.Services.AssetCategoryServices
{
    public class AssetCategoryService : IAssetCategoryService
    {
        private readonly IEntityRepository<ProductCategory> _iEntityRepository;
        private readonly InventoryDbContext _dbContext;
        private readonly IWorkContext _iWorkContext;
        public AssetCategoryService(IEntityRepository<ProductCategory> iEntityRepository, InventoryDbContext dbContext, IWorkContext iWorkContext)
        {
            _iEntityRepository = iEntityRepository;
            _dbContext = dbContext;
            _iWorkContext = iWorkContext;
        }

        public async Task<bool> AddRecord(AssetCategoryViewModel vm)
        {
            var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Name.Trim() == vm.Name.Trim() && f.IsActive==true);
            if (checkName == null)
            {
                ProductCategory com = new ProductCategory();
                com.Name = vm.Name;
                com.ProductCategoryTypeId = (int)ProductCategoryTypeEnum.AssetCategory;
                var res = await _iEntityRepository.AddAsync(com);
                vm.Id = res.Id;
                return true;
            }
            return false;
        }
        public async Task<bool> UpdateRecord(AssetCategoryViewModel vm)
        {

            var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Name.Trim() == vm.Name.Trim() && f.Id != vm.Id && f.ProductCategoryTypeId==(int)ProductCategoryTypeEnum.AssetCategory && f.IsActive==true);

            if (checkName == null)
            {
                var result = await _iEntityRepository.GetByIdAsync(vm.Id);
                result.Name = vm.Name;
                result.ProductCategoryTypeId = (int)ProductCategoryTypeEnum.AssetCategory;
                await _iEntityRepository.UpdateAsync(result);
                return true;
            }
            return false;
        }
        public async Task<AssetCategoryViewModel> GetRecordById(long id)
        {
            var result = await _iEntityRepository.GetByIdAsync(id);
            AssetCategoryViewModel model = new AssetCategoryViewModel();
            model.Id = result.Id;
            model.Name = result.Name;
            model.AssetCategoryTypeId = result.ProductCategoryTypeId;
            return model;
        }
        public async Task<bool> DeleteRecord(long id)
        {
            var result = await _iEntityRepository.GetByIdAsync(id);
            result.IsActive = false;
            await _iEntityRepository.UpdateAsync(result);
            return true;
        }
        public async Task<AssetCategoryViewModel> GetAllRecord()
        {
            AssetCategoryViewModel model = new AssetCategoryViewModel();
            model.AssetCategoryList = await Task.Run(() => (from t1 in _dbContext.ProductCategory
                                                              where t1.ProductCategoryTypeId == (int)ProductCategoryTypeEnum.AssetCategory && t1.IsActive == true
                                                              select new AssetCategoryViewModel
                                                              {
                                                                  Id = t1.Id,
                                                                  Name = t1.Name,
                                                                  AssetCategoryTypeId = t1.ProductCategoryTypeId,
                                                              }).AsEnumerable());
            return model;
        }

        public async Task<DataTablePagination<AssetCategorySearchDto>> SearchAsync(DataTablePagination<AssetCategorySearchDto> searchDto)
        {
            var searchResult = _dbContext.ProductCategory.Where(c => c.IsActive == true).AsNoTracking();

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
            List<ProductCategory> filteredDataList = await searchResult.OrderByDescending(c => c.Id).Skip(skip).Take(pageSize).ToListAsync();

            var sl = searchDto.Start ?? 0;
            searchDto.Data = filteredDataList.Select(c => new AssetCategorySearchDto()
            {
                SerialNo = ++sl,
                Id = c.Id,
                Name = c.Name,
               
            }).ToList();

            return searchDto;
        }
    }
}
