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
using app.Services.PurchaseOrderDetailServices;
using app.Services.DropdownServices;
using Microsoft.EntityFrameworkCore;

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
            purchaseOrder.PurchaseTypeId = (int)PurchaseTypeEnum.Purchase;
            purchaseOrder.OrderStatusId = (int)PurchaseOrderStatusEnum.Draft;
            var res = await _iEntityRepository.AddAsync(purchaseOrder);
            vm.Id = res?.Id ?? 0;
            return true;
        }

        public async Task<PurchaseOrderViewModel> GetPurchaseOrder(long purchaseOrderId)
        {
            PurchaseOrderViewModel purchaseOrderDetailVM = new PurchaseOrderViewModel();
            purchaseOrderDetailVM = await Task.Run(async () => await Task.Run(() => (from t1 in _dbContext.PurchaseOrder.Where(x => x.IsActive && x.Id == purchaseOrderId)
                                                                                     select new PurchaseOrderViewModel
                                                                                     {
                                                                                         Id = t1.Id,
                                                                                         OrderNo = t1.OrderNo,
                                                                                         PurchaseDate = t1.PurchaseDate,    
                                                                                         SupplierId = t1.SupplierId,
                                                                                         StorehouseId = t1.StorehouseId,
                                                                                         OverallDiscount = t1.OverallDiscount,
                                                                                         Description = t1.Description,
                                                                                         PurchaseTypeId = t1.PurchaseTypeId,
                                                                                         OrderStatusId = t1.OrderStatusId
                                                                                     }).FirstOrDefaultAsync()));

            purchaseOrderDetailVM.PurchaseOrderList = await Task.Run(async () => await Task.Run(() => (from t1 in _dbContext.PurchaseOrderDetail.Where(x => x.IsActive && x.PurchaseOrderId == purchaseOrderId)
                                                                                                       join t2 in _dbContext.Product.Where(x => x.IsActive) on t1.ProductId equals t2.Id
                                                                                                       join t3 in _dbContext.ProductCategory.Where(x => x.IsActive) on t2.CategoryId equals t3.Id
                                                                                                       select new PurchaseOrderViewModel
                                                                                                       {
                                                                                                           Id = t1.Id,

                                                                                                           
                                                                                                           
                                                                                                       }).OrderByDescending(x => x.Id).AsEnumerable()));

            return purchaseOrderDetailVM;
        }

    }
}
