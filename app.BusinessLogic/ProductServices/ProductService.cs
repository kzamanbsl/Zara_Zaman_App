using app.EntityModel.AppModels;
using app.Infrastructure.Auth;
using app.Infrastructure.Repository;
using app.Infrastructure;
using app.EntityModel.DataTablePaginationModels;
using Microsoft.EntityFrameworkCore;

namespace app.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IEntityRepository<Product> _iEntityRepository;
        private readonly InventoryDbContext _dbContext;
        private readonly IWorkContext _iWorkContext;
        public ProductService(IEntityRepository<Product> iEntityRepository, InventoryDbContext dbContext, IWorkContext iWorkContext)
        {
            _iEntityRepository = iEntityRepository;
            _dbContext = dbContext;
            _iWorkContext = iWorkContext;
        }

        public async Task<bool> AddRecord(ProductViewModel vm)
        {
            var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.CategoryId == vm.CategoryId && f.Id == vm.Id && f.IsActive == true);
            if (checkName == null)
            {
                Product com = new Product();
                com.Name = vm.Name;
                com.Description = vm.Description;
                com.TradePrice = vm.TradePrice;
                com.SalePrice = vm.SalePrice;
                com.UnitId = vm.UnitId;
                com.CategoryId = vm.CategoryId;
                com.ProductTypeId = vm.ProductTypeId;
                com.HasModelNo = vm.HasModelNo;
                com.HasSerialNo = vm.HasSerialNo;
                com.HasWarranty = vm.HasWarranty;
                var res = await _iEntityRepository.AddAsync(com);
                vm.Id = res.Id;
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateRecord(ProductViewModel vm)
        {
            var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.CategoryId == vm.CategoryId && f.Name.Trim() == vm.Name.Trim() && f.Id != vm.Id && f.IsActive == true);
            if (checkName == null)
            {
                var result = await _iEntityRepository.GetByIdAsync(vm.Id);
                result.Name = vm.Name;
                result.Description = vm.Description;
                result.TradePrice = vm.TradePrice;
                result.SalePrice = vm.SalePrice;
                result.UnitId = vm.UnitId;
                result.CategoryId = vm.CategoryId;
                result.ProductTypeId = vm.ProductTypeId;
                result.HasModelNo = vm.HasModelNo;
                result.HasSerialNo = vm.HasSerialNo;
                result.HasWarranty = vm.HasWarranty;
                await _iEntityRepository.UpdateAsync(result);
                return true;
            }
            return false;
        }

        public async Task<ProductViewModel> GetRecordById(long id)
        {
            var result = await _iEntityRepository.GetByIdAsync(id);
            ProductViewModel model = new ProductViewModel();
            model.Id = result.Id;
            model.Name = result.Name;
            model.Description = result.Description;
            model.TradePrice = result.TradePrice;
            model.SalePrice = result.SalePrice;
            model.UnitId = result.UnitId;
            model.UnitName = result.Unit?.Name;
            model.CategoryId = result.CategoryId;
            model.CategoryName = result.Category?.Name;
            model.ProductTypeId = result.ProductTypeId;
            model.HasModelNo = result.HasModelNo;
            model.HasSerialNo = result.HasSerialNo;
            model.HasWarranty = result.HasWarranty;
            return model;
        }

        public async Task<bool> DeleteRecord(long id)
        {
            var result = await _iEntityRepository.GetByIdAsync(id);
            result.IsActive = false;
            await _iEntityRepository.UpdateAsync(result);
            return true;
        }

        public async Task<ProductViewModel> GetAllRecord()
        {
            ProductViewModel model = new ProductViewModel();
            model.ProductList = await Task.Run(() => (from t1 in _dbContext.Product
                                                      where t1.IsActive == true
                                                      select new ProductViewModel
                                                      {
                                                          Id = t1.Id,
                                                          Name = t1.Name,
                                                          Description = t1.Description,
                                                          TradePrice = t1.TradePrice,
                                                          SalePrice = t1.SalePrice,
                                                          UnitId = t1.UnitId,
                                                          UnitName = t1.Unit.Name,
                                                          CategoryId = t1.CategoryId,
                                                          CategoryName = t1.Category.Name,
                                                          ProductTypeId = t1.ProductTypeId,
                                                      }).AsEnumerable());
            return model;
        }

        public async Task<DataTablePagination<ProductSearchDto>> SearchAsync(DataTablePagination<ProductSearchDto> searchDto)
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
                    || c.SalePrice.ToString().Contains(filter)
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
            searchDto.Data = filteredDataList.Select(c => new ProductSearchDto()
            {
                SerialNo = ++sl,
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
                TradePrice = c.TradePrice,
                SalePrice = c.SalePrice,
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
