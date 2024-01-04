using app.EntityModel.AppModels;
using app.Infrastructure.Auth;
using app.Infrastructure.Repository;
using app.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Services.PurchaseOrderDetailServices
{
    public class PurchaseOrderDetailService : IPurchaseOrderDetailService
    {
        private readonly IEntityRepository<PurchaseOrderDetail> _iEntityRepository;
        private readonly InventoryDbContext _dbContext;
        public PurchaseOrderDetailService(IEntityRepository<PurchaseOrderDetail> iEntityRepository, InventoryDbContext dbContext, IWorkContext iWorkContext)
        {
            _iEntityRepository = iEntityRepository;
            _dbContext = dbContext;
        }
        public async Task<bool> AddRecord(PurchaseOrderDetailViewModel vm)
        {
            var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Id == vm.Id);
            if (checkName == null)
            {
                PurchaseOrderDetail purchaseOrderDetail = new PurchaseOrderDetail();
                purchaseOrderDetail.PurchaseOrderId = vm.PurchaseOrderId;
                purchaseOrderDetail.ProductId = vm.ProductId;
                purchaseOrderDetail.PurchaseQty = vm.PurchaseQty;
                purchaseOrderDetail.Consumption = vm.Consumption;
                purchaseOrderDetail.UnitId = vm.UnitId;
                purchaseOrderDetail.CostPrice = vm.CostPrice;
                purchaseOrderDetail.SalePrice = vm.SalePrice;
                purchaseOrderDetail.Discount = vm.Discount;
                purchaseOrderDetail.Remarks = vm.Remarks;

                var res = await _iEntityRepository.AddAsync(purchaseOrderDetail);
                vm.Id = res?.Id ?? 0;
                return true;
            }
            return false;

        }

        public Task<bool> UpdateRecord(PurchaseOrderDetailViewModel vm)
        {
            throw new NotImplementedException();
        }
    }
}
