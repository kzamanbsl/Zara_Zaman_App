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

namespace app.Services.PurchaseOrderServices
{
    public class PurchaseOrderService : IPurchaseOrderService
    {
        private readonly IEntityRepository<PurchaseOrder> _iEntityRepository;
        private readonly InventoryDbContext _dbContext;
        private readonly IWorkContext _iWorkContext;
        public PurchaseOrderService(IEntityRepository<PurchaseOrder> iEntityRepository, InventoryDbContext dbContext, IWorkContext iWorkContext)
        {
            _iEntityRepository = iEntityRepository;
            _dbContext = dbContext;
            _iWorkContext = iWorkContext;
        }
        public async Task<bool> AddRecord(PurchaseOrderViewModel vm)
        {
                var poMax = _dbContext.PurchaseOrder.Count() + 1;
                string poCid = @"PO-" +
                               DateTime.Now.ToString("yy") +
                               DateTime.Now.ToString("MM") +
                               DateTime.Now.ToString("dd") + "-" +
                               poMax.ToString().PadLeft(2, '0');

                PurchaseOrder purchaseOrder = new PurchaseOrder();
                purchaseOrder.OrderNo = poCid;
                purchaseOrder.PurchaseDate = vm.PurchaseDate;
                purchaseOrder.SupplierId = vm.SupplierId;
                purchaseOrder.StorehouseId = vm.StorehouseId;
                purchaseOrder.OverallDiscount = vm.OverallDiscount;
                purchaseOrder.Description = vm.Description;                
                purchaseOrder.OrderStatusId = (int)PurchaseOrderStatusEnum.Draft;
                var res = await _iEntityRepository.AddAsync(purchaseOrder);
                vm.Id = res?.Id ?? 0;
                return true;            
        }

        public Task<bool> UpdateRecord(PurchaseOrderViewModel vm)
        {
            throw new NotImplementedException();
        }
    }
}
