using app.EntityModel.AppModels;
using app.Infrastructure.Auth;
using app.Infrastructure.Repository;
using app.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using app.Services.PurchaseOrderServices;

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
        public async Task<bool> AddRecord(PurchaseOrderViewModel vm)
        {
            try
            {
                PurchaseOrderDetail purchaseOrderDetail = new PurchaseOrderDetail
                {
                    PurchaseOrderId = vm.Id,
                    ProductId = vm.PurchaseOrderDetailVM.ProductId,
                    PurchaseQty = vm.PurchaseOrderDetailVM.PurchaseQty,
                    Consumption = vm.PurchaseOrderDetailVM.Consumption,
                    UnitId = vm.PurchaseOrderDetailVM.UnitId,
                    CostPrice = vm.PurchaseOrderDetailVM.CostPrice,
                    SalePrice = vm.PurchaseOrderDetailVM.SalePrice,
                    Discount = vm.PurchaseOrderDetailVM.Discount,
                    Remarks = vm.PurchaseOrderDetailVM.Remarks
                    


                };

                var res = await _iEntityRepository.AddAsync(purchaseOrderDetail);
                purchaseOrderDetail.Id = res?.Id ?? 0;
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public Task<bool> UpdateRecord(PurchaseOrderDetailViewModel vm)
        {
            throw new NotImplementedException();
        }
    }
}
