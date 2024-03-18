using app.EntityModel.AppModels;
using app.Infrastructure.Auth;
using app.Infrastructure.Repository;
using app.Infrastructure;
using app.EntityModel.DataTablePaginationModels;
using Microsoft.EntityFrameworkCore;
using app.Utility;

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
                com.UnitId = vm.UnitId;
                com.CategoryId = vm.CategoryId;
                com.ProductTypeId = (int)ProductTypeEnum.Product;
                com.HasModelNo = vm.HasModelNo;
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
                result.UnitId = vm.UnitId;
                result.CategoryId = vm.CategoryId;
                result.ProductTypeId = (int)ProductTypeEnum.Product;
                result.HasModelNo = vm.HasModelNo;
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
            model.UnitId = result.UnitId;
            model.UnitName = result.Unit?.Name;
            model.CategoryId = result.CategoryId;
            model.CategoryName = result.Category?.Name;
            model.ProductTypeId = (int)ProductTypeEnum.Product;
            model.HasModelNo = result.HasModelNo;
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
            var searchResult = _dbContext.Product.Include(c => c.Category).Include(c => c.Unit).Where(c => c.IsActive == true && c.ProductTypeId == (int)ProductTypeEnum.Product).AsNoTracking();

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
                    || c.Unit.Name.ToLower().Contains(filter)
                    || c.Description.ToLower().Contains(filter)
                );
            }

            var pageSize = searchDto.Length ?? 0;
            var skip = searchDto.Start ?? 0;

            var totalRecords = searchResult.Count();
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
                HasModelNo = c.HasModelNo,
                Description = c.Description,                
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
