using app.EntityModel.AppModels;
using app.Infrastructure.Auth;
using app.Infrastructure.Repository;
using app.Infrastructure;
using app.Services.SalesOrderServices;
using app.Services.PurchaseOrderServices;
using app.Services.AssetPurchaseOrderServices;
using app.Services.PurchaseOrderDetailServices;

namespace app.Services.SalesOrderDetailServices
{
    public class SalesOrderDetailService : ISalesOrderDetailService
    {
        private readonly IEntityRepository<SalesOrderDetails> _iEntityRepository;
        private readonly InventoryDbContext _dbContext;
        private readonly IWorkContext _iWorkContext;
        public SalesOrderDetailService(IEntityRepository<SalesOrderDetails> iEntityRepository, InventoryDbContext dbContext, IWorkContext iWorkContext)
        {
            _iEntityRepository = iEntityRepository;
            _dbContext = dbContext;
            _iWorkContext = iWorkContext;
        }
        public async Task<bool> AddSalesOrderDetails(SalesOrderViewModel vm)
        {
            try
            {
                SalesOrderDetails purchaseOrderDetail = new SalesOrderDetails
                {
                    SalesOrderId = vm.Id,
                    Id = vm.SalesOrderDetailVM.Id,
                    ProductId = vm.SalesOrderDetailVM.ProductId,
                    UnitId = vm.SalesOrderDetailVM.UnitId,
                    SalesPrice = vm.SalesOrderDetailVM.SalesPrice,
                    SalesQty = vm.SalesOrderDetailVM.SalesQty,
                    WarrantyFormDate = vm.SalesOrderDetailVM.WarrantyFormDate,
                    WarrantyToDate = vm.SalesOrderDetailVM.WarrantyToDate,
                    SerialNo = vm.SalesOrderDetailVM.SerialNo,
                    ModelNo = vm.SalesOrderDetailVM.ModelNo,
                    Discount = vm.SalesOrderDetailVM.Discount,
                    IsForService = vm.SalesOrderDetailVM.IsForService,
                    Remarks = vm.SalesOrderDetailVM.Remarks
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

        public async Task<bool> UpdateSalesDetail(SalesOrderDetailViewModel vm)
        {
            var salesOrderDetailOrder = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Id == vm.SalesOrderVM.Id);
            if (salesOrderDetailOrder != null)
            {
                vm.Id = salesOrderDetailOrder.Id;
                salesOrderDetailOrder.SalesOrderId=vm.SalesOrderId;
                salesOrderDetailOrder.ProductId = vm.ProductId;
                salesOrderDetailOrder.SalesPrice = vm.SalesPrice;
                salesOrderDetailOrder.SalesQty = vm.SalesQty;
                salesOrderDetailOrder.WarrantyFormDate =vm.WarrantyFormDate;
                salesOrderDetailOrder.WarrantyToDate =vm.WarrantyToDate;
                salesOrderDetailOrder.SerialNo = vm.SerialNo;
                salesOrderDetailOrder.ModelNo = vm.ModelNo;
                salesOrderDetailOrder.TotalAmount = vm.TotalAmount;
                await _iEntityRepository.UpdateAsync(salesOrderDetailOrder);
                return true;
            }
            return false;
        }

        public async Task<SalesOrderDetailViewModel> SingleSalesOrderDetails(long id)
        {
            var v = await Task.Run(() => (from t1 in _dbContext.SalesOrderDetailViewModel.Where(x => x.IsActive && x.Id == id)

                                          select new PurchaseOrderDetailViewModel
                                          {
                                              Id = t1.Id,
                                              Sal = t1.PurchaseOrderId,
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

        //public async Task<bool> UpdateAssetPurchaseDetail(AssetPurchaseOrderViewModel model)
        //{
        //    var assetPurchaseOrderDetail = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Id == model.AssetPurchaseOrderDetailVM.Id);
        //    if (assetPurchaseOrderDetail != null)
        //    {
        //        model.Id = assetPurchaseOrderDetail.PurchaseOrderId;
        //        assetPurchaseOrderDetail.ProductId = model.AssetPurchaseOrderDetailVM.ProductId;
        //        assetPurchaseOrderDetail.UnitId = model.AssetPurchaseOrderDetailVM.UnitId;
        //        assetPurchaseOrderDetail.Consumption = model.AssetPurchaseOrderDetailVM.Consumption;
        //        assetPurchaseOrderDetail.Discount = model.AssetPurchaseOrderDetailVM.Discount;
        //        assetPurchaseOrderDetail.PurchaseQty = model.AssetPurchaseOrderDetailVM.PurchaseQty;
        //        assetPurchaseOrderDetail.SalePrice = model.AssetPurchaseOrderDetailVM.SalePrice;
        //        assetPurchaseOrderDetail.CostPrice = model.AssetPurchaseOrderDetailVM.CostPrice;
        //        assetPurchaseOrderDetail.TotalAmount = ((decimal)model.AssetPurchaseOrderDetailVM.PurchaseQty * model.AssetPurchaseOrderDetailVM.CostPrice) - model.AssetPurchaseOrderDetailVM.Discount;
        //        assetPurchaseOrderDetail.Remarks = model.AssetPurchaseOrderDetailVM.Remarks;
        //        await _iEntityRepository.UpdateAsync(assetPurchaseOrderDetail);
        //        return true;
        //    }
        //    return false;
        //}


    }
}
