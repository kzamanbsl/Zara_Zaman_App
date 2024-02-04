using app.EntityModel.AppModels;
using app.Infrastructure.Auth;
using app.Infrastructure.Repository;
using app.Infrastructure;
using app.Services.InventoryServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Services.InventoryServices
{
    public class InventoryService : IInventoryService
    {
        private readonly IEntityRepository<Inventory> _iEntityRepository;
        private readonly InventoryDbContext _dbContext;
        private readonly IWorkContext _iWorkContext;
        public InventoryService(IEntityRepository<Inventory> iEntityRepository, InventoryDbContext dbContext, IWorkContext iWorkContext)
        {
            _iEntityRepository = iEntityRepository;
            _dbContext = dbContext;
            _iWorkContext = iWorkContext;
        }
        public async Task<bool> AddRecord(InventoryViewModel vm)
        {
            var checkName = _iEntityRepository.AllIQueryableAsync();

            if (checkName == null)
            {
                Inventory com = new Inventory();
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
    }
}
