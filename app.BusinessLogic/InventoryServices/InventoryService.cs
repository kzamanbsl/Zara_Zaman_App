using app.EntityModel.AppModels;
using app.Infrastructure.Auth;
using app.Infrastructure.Repository;
using app.Infrastructure;
using app.Services.PurchaseOrderServices;
using app.Services.PurchaseOrderDetailServices;
using app.Utility;
using Microsoft.EntityFrameworkCore;

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
   

        public async Task<bool> AddInventory(long id = 0)
        {
            PurchaseOrderViewModel purchaseOrderModel = await Task.Run(() =>
                (from t1 in _dbContext.PurchaseOrder
                 where t1.IsActive && t1.Id == id
                 select new PurchaseOrderViewModel
                 {
                     Id = t1.Id,
                     PurchaseDate = t1.PurchaseDate,
                     OrderNo = t1.OrderNo,
                     OrderStatusId = (int)(PurchaseOrderStatusEnum)t1.OrderStatusId,
                     SupplierId = t1.SupplierId,
                     SupplierName = t1.Supplier.Name,
                     StorehouseId = t1.StorehouseId,
                     StoreName = t1.Storehouse.Name,
                     PurchaseTypeId = t1.PurchaseTypeId,
                     Description = t1.Description,
                 }).FirstOrDefault());

            purchaseOrderModel.PurchaseOrderDetailsList = await Task.Run(() =>
                (from t1 in _dbContext.PurchaseOrderDetail
                 where t1.IsActive && t1.PurchaseOrder.Id == id
                 select new PurchaseOrderDetailViewModel
                 {
                     Id = t1.Id,
                     PurchaseOrderId = t1.PurchaseOrderId,
                     ProductId = t1.ProductId,
                     ProductName = t1.Product.Name,
                     PurchaseQty = t1.PurchaseQty,
                     UnitId = t1.UnitId,
                     UnitName = t1.Unit.Name,
                     SalePrice = t1.SalePrice,
                     TotalAmount = ((decimal)t1.PurchaseQty * t1.SalePrice),
                     Remarks = t1.Remarks,
                 }).OrderByDescending(x => x.Id).ToListAsync());

            foreach (var detail in purchaseOrderModel.PurchaseOrderDetailsList)
            {
                Inventory inventory = new Inventory
                {
                    StoreFromId = detail.PurchaseOrderId,
                    StoreTypeId = (int)StoreTypeEnum.Purchase,
                    StockDate = purchaseOrderModel.PurchaseDate,
                    StorehouseId = purchaseOrderModel.StorehouseId ?? 0,
                    ProductId = detail?.ProductId ?? 0,
                    UnitId = detail?.UnitId ?? 0,
                    SalePrice = detail?.SalePrice ?? 0,
                    Remarks = detail.Remarks,
                };
                var res = await _iEntityRepository.AddAsync(inventory);
                detail.Id = res?.Id ?? 0;
            }
            var purchaseOrder = await _dbContext.PurchaseOrder.FirstOrDefaultAsync(x => x.Id == id && x.IsActive); ;
            if (purchaseOrder != null)
            {
                purchaseOrder.OrderStatusId = (int)PurchaseOrderStatusEnum.Receive;
                await _dbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
