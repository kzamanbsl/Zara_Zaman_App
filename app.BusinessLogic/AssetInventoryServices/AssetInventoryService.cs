using app.Infrastructure.Auth;
using app.Infrastructure.Repository;
using app.Infrastructure;
using app.Services.AssetPurchaseOrderServices;
using app.Services.AssetPurchaseOrderDetailServices;
using app.Utility;
using Microsoft.EntityFrameworkCore;
using app.Services.IAssetnventoryServices;
using app.EntityModel.AppModels.AssetModels;

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
   

        public async Task<bool> AddAssetInventory(long id = 0)
        {
            AssetPurchaseOrderViewModel assetPurchaseOrderModel = await Task.Run(() =>
                (from t1 in _dbContext.PurchaseOrder
                 where t1.IsActive && t1.Id == id
                 select new AssetPurchaseOrderViewModel
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

            assetPurchaseOrderModel.AssetPurchaseOrderDetailsList = await Task.Run(() =>
                (from t1 in _dbContext.PurchaseOrderDetail
                 where t1.IsActive && t1.PurchaseOrder.Id == id
                 select new AssetPurchaseOrderDetailViewModel
                 {
                     Id = t1.Id,
                     PurchaseOrderId = t1.PurchaseOrderId,
                     ProductId = t1.ProductId,
                     ProductName = t1.Product.Name,
                     PurchaseQty = t1.PurchaseQty,
                     UnitId = t1.UnitId,
                     UnitName = t1.Unit.Name,
                     //TotalAmount = ((decimal)t1.PurchaseQty 
                     Remarks = t1.Remarks,
                 }).OrderByDescending(x => x.Id).ToListAsync());

            foreach (var detail in assetPurchaseOrderModel.AssetPurchaseOrderDetailsList)
            {
                AssetInventory assetInventory = new AssetInventory
                {
                    StoreFromId = detail.PurchaseOrderId,
                    StoreTypeId = (int)StoreTypeEnum.Purchase,
                    StockDate = assetPurchaseOrderModel.PurchaseDate,
                    StorehouseId = assetPurchaseOrderModel.StorehouseId ?? 0,
                    ProductId = detail?.ProductId ?? 0,
                    UnitId = detail?.UnitId ?? 0,
                    //SalePrice = detail?.SalePrice ?? 0,
                    Consumption = detail?.Consumption ?? 0,
                    Remarks = detail.Remarks,
                };
                var res = await _iEntityRepository.AddAsync(assetInventory);
                detail.Id = res?.Id ?? 0;
            }
            var assetPurchaseOrder = await _dbContext.PurchaseOrder.FirstOrDefaultAsync(x => x.Id == id && x.IsActive); ;
            if (assetPurchaseOrder != null)
            {
                assetPurchaseOrder.OrderStatusId = (int)PurchaseOrderStatusEnum.Receive;
                await _dbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
