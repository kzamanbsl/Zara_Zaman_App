using app.EntityModel.AppModels;
using app.Infrastructure.Auth;
using app.Infrastructure.Repository;
using app.Infrastructure;

namespace app.Services.AssetPurchaseOrderDetailServices
{
    public class AssetPurchaseOrderDetailService : IAssetPurchaseOrderDetailService
    {
        private readonly IEntityRepository<PurchaseOrderDetail> _iEntityRepository;
        private readonly InventoryDbContext _dbContext;
        public AssetPurchaseOrderDetailService(IEntityRepository<PurchaseOrderDetail> iEntityRepository, InventoryDbContext dbContext, IWorkContext iWorkContext)
        {
            _iEntityRepository = iEntityRepository;
            _dbContext = dbContext;
        }
        public async Task<bool> AddRecord(AssetPurchaseOrderDetailViewModel vm)
        {
            try
            {
                PurchaseOrderDetail assetPurchaseOrderDetail = new PurchaseOrderDetail
                {

                    PurchaseOrderId = vm.Id,
                    Id = vm.AssetPurchaseOrderVM.Id,
                    ProductId = vm.AssetPurchaseOrderVM.ProductId,
                    PurchaseQty = vm.AssetPurchaseOrderVM.PurchaseQty,
                    Consumption = vm.AssetPurchaseOrderVM.Consumption,
                    UnitId = vm.AssetPurchaseOrderVM.UnitId,
                    CostPrice = vm.AssetPurchaseOrderVM.CostPrice,
                    SalePrice = vm.AssetPurchaseOrderVM.SalePrice,
                    Discount = vm.AssetPurchaseOrderVM.Discount,
                    TotalAmount = (vm.AssetPurchaseOrderVM.CostPrice * (decimal)vm.AssetPurchaseOrderVM.PurchaseQty) - vm.AssetPurchaseOrderVM.Discount,
                    Remarks = vm.AssetPurchaseOrderVM.Remarks
                };

                var res = await _iEntityRepository.AddAsync(assetPurchaseOrderDetail);
                assetPurchaseOrderDetail.Id = res?.Id ?? 0;
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        //public async Task<bool> UpdatePurchaseDetail(AssetPurchaseOrderViewModel model)
        //{
        //    var purchaseOrderDetail = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Id == model.AssetPurchaseOrderDetailVM.Id);
        //    if (purchaseOrderDetail != null)
        //    {
        //        model.Id = purchaseOrderDetail.PurchaseOrderId;
        //        purchaseOrderDetail.ProductId = model.AssetPurchaseOrderDetailVM.ProductId;
        //        purchaseOrderDetail.UnitId = model.AssetPurchaseOrderDetailVM.UnitId;
        //        purchaseOrderDetail.Consumption = model.AssetPurchaseOrderDetailVM.Consumption;
        //        purchaseOrderDetail.Discount = model.AssetPurchaseOrderDetailVM.Discount;
        //        purchaseOrderDetail.PurchaseQty = model.AssetPurchaseOrderDetailVM.PurchaseQty;
        //        purchaseOrderDetail.SalePrice = model.AssetPurchaseOrderDetailVM.SalePrice;
        //        purchaseOrderDetail.CostPrice = model.AssetPurchaseOrderDetailVM.CostPrice;
        //        purchaseOrderDetail.TotalAmount = ((decimal)model.AssetPurchaseOrderDetailVM.PurchaseQty * model.AssetPurchaseOrderDetailVM.CostPrice) - model.AssetPurchaseOrderDetailVM.Discount;
        //        purchaseOrderDetail.Remarks = model.AssetPurchaseOrderDetailVM.Remarks;
        //        await _iEntityRepository.UpdateAsync(purchaseOrderDetail);
        //        return true;
        //    }
        //    return false;
        //}

        public async Task<AssetPurchaseOrderDetailViewModel> SinglePurchaseOrderDetails(long id)
        {
            var v = await Task.Run(() => (from t1 in _dbContext.PurchaseOrderDetail.Where(x => x.IsActive && x.Id == id)

                                          select new AssetPurchaseOrderDetailViewModel
                                          {
                                              Id = t1.Id,
                                              PurchaseOrderId = t1.PurchaseOrderId,
                                              ProductId = t1.ProductId,
                                              ProductName = t1.Product.Name,
                                              PurchaseQty = t1.PurchaseQty,
                                              Consumption = t1.Consumption,
                                              UnitId = t1.UnitId,
                                              UnitName = t1.Unit.Name,
                                              CostPrice = t1.CostPrice,
                                              SalePrice = t1.SalePrice,
                                              Discount = t1.Discount,
                                              TotalAmount = ((decimal)t1.PurchaseQty * t1.CostPrice) - t1.Discount,
                                              Remarks = t1.Remarks,
                                          }).FirstOrDefault());
            return v;
        }

        public async Task<bool> DeletePurchaseDetail(long id)
        {

            PurchaseOrderDetail assetPurchaseDetails = await _dbContext.PurchaseOrderDetail.FindAsync(id);
            if (assetPurchaseDetails == null)
            {
                throw new Exception("Sorry! Order not found!");
            }
            var result = await _iEntityRepository.GetByIdAsync(id);
            result.IsActive = false;
            await _iEntityRepository.UpdateAsync(result);
            return true;
        }

        //public Task<bool> UpdatePurchaseDetail(AssetPurchaseOrderDetailViewModel vm)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
