using app.EntityModel.AppModels;
using app.Infrastructure.Auth;
using app.Infrastructure.Repository;
using app.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using app.Utility;
using app.Services.AssetItemServices;
using app.EntityModel.DataTablePaginationModels;
using app.Services.ProductServices;
using Microsoft.EntityFrameworkCore;

namespace app.Services.AssetItemServices
{
    public class AssetItemService : IAssetItemService
    {
        private readonly IEntityRepository<Product> _iEntityRepository;
        private readonly InventoryDbContext _dbContext;
        private readonly IWorkContext _iWorkContext;
        public AssetItemService(IEntityRepository<Product> iEntityRepository, InventoryDbContext dbContext, IWorkContext iWorkContext)
        {
            _iEntityRepository = iEntityRepository;
            _dbContext = dbContext;
            _iWorkContext = iWorkContext;
        }
        
        public async Task<bool> AddRecord(AssetItemViewModel vm)
        {
            //var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Name.Trim() == vm.Name.Trim());
            var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Name.Trim() == vm.Name.Trim() && f.IsActive == true);
            if (checkName == null)
            {
                Product com = new Product();
                com.Id = vm.Id;
                com.Name = vm.Name;
                com.Description = vm.Description;
                com.TradePrice = vm.TP;
                com.UnitId = vm.UnitId;
                com.CategoryId = vm.CategoryId;
                com.ProductTypeId = (int)ProductTypeEnum.Asset;
                var res = await _iEntityRepository.AddAsync(com);
                return true;
            }
            return false;
        }
        public async Task<bool> UpdateRecord(AssetItemViewModel vm)
        {

            //var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Name.Trim() == vm.Name.Trim());
            var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Name.Trim() == vm.Name.Trim() && f.Id != vm.Id && f.IsActive == true);
            if (checkName == null)
            {
                var result = await _iEntityRepository.GetByIdAsync(vm.Id);
                result.Id = vm.Id;
                result.Name = vm.Name;
                result.Description = vm.Description;
                result.TradePrice = vm.TP;
                result.UnitId = vm.UnitId;
                result.CategoryId = vm.CategoryId;
                result.ProductTypeId = (int)ProductTypeEnum.Asset;
                await _iEntityRepository.UpdateAsync(result);
                return true;
            }
            return false;
        }
        public async Task<AssetItemViewModel> GetRecordById(long id)
        {
            var result = await _iEntityRepository.GetByIdAsync(id);
            AssetItemViewModel model = new AssetItemViewModel();
            model.Id = result.Id;
            model.Name = result.Name;
            model.Description = result.Description;
            model.TP = result.TradePrice;
            model.UnitId = result.UnitId;
            model.CategoryId = result.CategoryId;
            return model;
        }
        public async Task<bool> DeleteRecord(long id)
        {
            var result = await _iEntityRepository.GetByIdAsync(id);
            result.IsActive = false;
            await _iEntityRepository.UpdateAsync(result);
            return true;
        }
        public async Task<AssetItemViewModel> GetAllRecord()
        {
            AssetItemViewModel model = new AssetItemViewModel();
            model.AssetItemList = await Task.Run(() => (from t1 in _dbContext.Product.Where(x => x.IsActive)
                                                        select new AssetItemViewModel
                                                        {
                                                            Id = t1.Id,
                                                            ProductTypeId = t1.ProductTypeId,
                                                            Name = t1.Name,
                                                            Description = t1.Description,
                                                            TP = t1.TradePrice,
                                                            UnitId = t1.UnitId,
                                                            UnitName = t1.Unit.Name,
                                                            CategoryId = t1.CategoryId,
                                                            CategoryName = t1.Category.Name,
                                                        }).AsEnumerable());
            return model;
        }
        public async Task<DataTablePagination<AssetItemSearchDto>> SearchAsync(DataTablePagination<AssetItemSearchDto> searchDto)
        {
            var searchResult = _dbContext.Product.Include(c => c.Category).Include(c => c.Unit).AsNoTracking();

            var searchModel = searchDto.SearchVm;
            var filter = searchDto?.Search?.Value?.Trim();
            if (searchModel?.CategoryId is > 0)
            {
                searchResult = searchResult.Where(c => c.CategoryId == searchModel.CategoryId);
            }
            if (searchModel?.UnitId is > 0)
            {
                searchResult = searchResult.Where(c => c.UnitId == searchModel.UnitId);
            }
            if (!string.IsNullOrEmpty(filter))
            {
                filter = filter.ToLower();
                searchResult = searchResult.Where(c =>
                    c.Name.ToLower().Contains(filter)
                    || c.TradePrice.ToString().Contains(filter)
                    || c.Unit.Name.ToLower().Contains(filter)
                    || c.Description.ToLower().Contains(filter)
                );
            }

            var pageSize = searchDto.Length ?? 0;
            var skip = searchDto.Start ?? 0;

            var totalRecords = await searchResult.CountAsync();
            if (totalRecords <= 0) return searchDto;

            searchDto.RecordsTotal = totalRecords;
            searchDto.RecordsFiltered = totalRecords;
            List<Product> filteredDataList = await searchResult.OrderByDescending(c => c.Id).Skip(skip).Take(pageSize).ToListAsync();

            var sl = searchDto.Start ?? 0;
            searchDto.Data = filteredDataList.Select(c => new AssetItemSearchDto()
            {
                SerialNo = ++sl,
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
                TP = c.TradePrice,
                UnitId = c.UnitId,
                UnitName = c.Unit.Name,
                CategoryId = c.CategoryId,
                CategoryName = c.Category.Name,
                ProductTypeId = c.ProductTypeId,
            }).ToList();

            return searchDto;
        }
    }
}
