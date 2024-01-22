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

        public async Task<AssetItemViewModel> GetRecordById(long id)
        {
            var result = await _iEntityRepository.GetByIdAsync(id);
            AssetItemViewModel model = new AssetItemViewModel();
            model.Id = result.Id;
            model.Name = result.Name;
            model.Description = result.Description;
            model.TP = result.TP;
            model.UnitId = result.UnitId;
            model.CategoryId = result.CategoryId;
            return model;
        }
        public async Task<AssetItemViewModel> GetAllRecord()
        {
            AssetItemViewModel model = new AssetItemViewModel();
            model.AssetItemList = await Task.Run(() => (from t1 in _dbContext.Product.Where(x => x.IsActive)
                                                        select new AssetItemViewModel
                                                      {
                                                          ProductTypeId = t1.ProductTypeId,
                                                          Name = t1.Name,
                                                          Description = t1.Description,
                                                          TP = t1.TP,
                                                          UnitId = t1.UnitId,
                                                          UnitName =t1.Unit.Name,
                                                          CategoryId = t1.CategoryId,
                                                          CategoryName = t1.Category.Name,
                                                      }).AsQueryable());
            return model;
        }
        public async Task<bool> AddRecord(AssetItemViewModel vm)
        {
            var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Name.Trim() == vm.Name.Trim());
            if (checkName == null)
            {
                Product com = new Product();
                com.Name = vm.Name;
                com.Description = vm.Description;
                com.TP = vm.TP;
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

            var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Name.Trim() == vm.Name.Trim());
            if (checkName != null)
            {
                var result = await _iEntityRepository.GetByIdAsync(vm.ProductTypeId);
                result.Name = vm.Name;
                result.Description = vm.Description;
                result.TP = vm.TP;
                result.UnitId = vm.UnitId;
                result.CategoryId = vm.CategoryId;
                result.ProductTypeId = (int)ProductTypeEnum.Asset;
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
