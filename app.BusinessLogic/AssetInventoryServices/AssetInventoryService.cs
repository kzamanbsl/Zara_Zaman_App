using app.EntityModel.AppModels;
using app.Infrastructure.Auth;
using app.Infrastructure.Repository;
using app.Infrastructure;
using app.Services.AssetInventoryServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Services.AssetInventoryServices
{
    public class AssetInventoryService : IAssetInventoryService
    {
        private readonly IEntityRepository<AssetInventory> _iEntityRepository;
        private readonly InventoryDbContext _dbContext;
        private readonly IWorkContext _iWorkContext;
        public AssetInventoryService(IEntityRepository<AssetInventory> iEntityRepository, InventoryDbContext dbContext, IWorkContext iWorkContext)
        {
            _iEntityRepository = iEntityRepository;
            _dbContext = dbContext;
            _iWorkContext = iWorkContext;
        }

        public async Task<AssetInventoryViewModel> GetRecordById(long id)
        {
            var result = await _iEntityRepository.GetByIdAsync(id);
            AssetInventoryViewModel model = new AssetInventoryViewModel();
            model.Id = result.Id;
            model.StockDate = result.StockDate;
            model.StoreTypeId = result.StoreTypeId;
            model.StorehouseId = result.StorehouseId;
            model.ProductId = result.ProductId;
            model.UnitId = result.UnitId;
            model.Consumption = result.Consumption;
            model.CostPrice = result.CostPrice;
            model.SalePrice = result.SalePrice;
            model.Remarks = result.Remarks;
            return model;
        }
        public async Task<AssetInventoryViewModel> GetAllRecord()
        {
            AssetInventoryViewModel model = new AssetInventoryViewModel();
            model.AssetInventoryList = await Task.Run(() => (from t1 in _dbContext.AssetInventory
                                                      where t1.IsActive == true
                                                      select new AssetInventoryViewModel
                                                      {
                                                          Id = t1.Id,
                                                          StockDate = t1.StockDate,
                                                          StoreTypeId = t1.StoreTypeId,
                                                          StorehouseId = t1.StorehouseId,
                                                          ProductId = t1.ProductId,
                                                          UnitId = t1.UnitId,
                                                          Consumption = t1.Consumption,
                                                          CostPrice = t1.CostPrice,
                                                          SalePrice = t1.SalePrice,
                                                          Remarks = t1.Remarks,
                                                      }).AsQueryable());
            return model;
        }
        public async Task<bool> AddRecord(AssetInventoryViewModel vm)
        {
            var checkName = _iEntityRepository.AllIQueryableAsync();

            if (checkName == null)
            {
                AssetInventory com = new AssetInventory();
                var res = await _iEntityRepository.AddAsync(com);
                vm.Id = res.Id;
                vm.StockDate = res.StockDate;
                vm.StoreTypeId = res.StoreTypeId;
                vm.StorehouseId = res.StorehouseId;
                vm.ProductId = res.ProductId;
                vm.UnitId = res.UnitId;
                vm.Consumption = res.Consumption;
                vm.CostPrice = res.CostPrice;
                vm.SalePrice = res.SalePrice;
                vm.Remarks = res.Remarks;
                return true;
            }
            return false;
        }
        public async Task<bool> UpdateRecord(AssetInventoryViewModel vm)
        {

            var checkName = _iEntityRepository.AllIQueryableAsync();
            if (checkName != null)
            {
                var result = await _iEntityRepository.GetByIdAsync(vm.Id);
               result.StockDate = vm.StockDate;
                result.StoreTypeId = vm.StoreTypeId;
                result.StorehouseId= vm.StorehouseId;
                result.ProductId = vm.ProductId;
                result.UnitId = vm.UnitId;
                result.Consumption = vm.Consumption;
                result.CostPrice = vm.CostPrice;
                result.SalePrice = vm.SalePrice;
                result.Remarks = vm.Remarks;
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
