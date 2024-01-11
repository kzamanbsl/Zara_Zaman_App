using app.EntityModel.AppModels;
using app.Infrastructure.Auth;
using app.Infrastructure.Repository;
using app.Infrastructure;
using app.Services.ProductServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<ProductViewModel> GetRecordById(long id)
        {
            var result = await _iEntityRepository.GetByIdAsync(id);
            ProductViewModel model = new ProductViewModel();
            model.Id = result.Id;
            model.Name = result.Name;
            model.Description = result.Description;
            model.TP = result.TP;
            model.SalePrice = result.SalePrice;
            model.UnitId = result.UnitId;
            model.UnitName = result.Unit?.Name;
            model.CategoryId = result.CategoryId;
            model.CategoryName = result.Category?.Name;
            model.ProductTypeId = result.ProductTypeId;
            return model;
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
                                                          TP = t1.TP,
                                                          SalePrice = t1.SalePrice,
                                                          UnitId = t1.UnitId,
                                                          UnitName = t1.Unit.Name,
                                                          CategoryId = t1.CategoryId,
                                                          CategoryName = t1.Category.Name,
                                                          ProductTypeId = t1.ProductTypeId,
                                                      }).AsQueryable());
            return model;
        }
        public async Task<bool> AddRecord(ProductViewModel vm)
        {
            var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Name.Trim() == vm.Name.Trim());
            if (checkName == null)
            {
                Product com = new Product();
                com.Name = vm.Name;
                com.Description = vm.Description;
                com.TP = vm.TP;
                com.SalePrice = vm.SalePrice;
                com.UnitId = vm.UnitId;
                com.CategoryId = vm.CategoryId;
                com.ProductTypeId = vm.ProductTypeId;           
                var res = await _iEntityRepository.AddAsync(com);
                vm.Id = res.Id;
                return true;
            }
            return false;
        }
        public async Task<bool> UpdateRecord(ProductViewModel vm)
        {

            var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Name.Trim() == vm.Name.Trim());
            if (checkName != null)
            {
                var result = await _iEntityRepository.GetByIdAsync(vm.Id);
                result.Name = vm.Name;
                result.Description = vm.Description;
                result.TP = vm.TP;
                result.SalePrice = vm.SalePrice;
                result.UnitId = vm.UnitId;
                result.CategoryId = vm.CategoryId;
                result.ProductTypeId = vm.ProductTypeId;
                await _iEntityRepository.UpdateAsync(result);
                return true;
            }
            return false;
        }
        public async Task<bool> DeleteRecord(long id)
        {
            var result = await _iEntityRepository.GetByIdAsync(id);
            result.IsActive = false;
            await _iEntityRepository.UpdateAsync(result);
            return true;
        }

    }
}
