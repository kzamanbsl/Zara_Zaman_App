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
                SalesOrderDetails SalesOrderDetail = new SalesOrderDetails
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

                var res = await _iEntityRepository.AddAsync(SalesOrderDetail);
                SalesOrderDetail.Id = res?.Id ?? 0;
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public async Task<bool> UpdateSalesDetail(SalesOrderViewModel model)
        {
            var salesOrderDetail = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Id == model.SalesOrderDetailVM.Id);
            if (salesOrderDetail != null)
            {
                model.Id = salesOrderDetail.SalesOrderId;
                salesOrderDetail.ProductId = model.SalesOrderDetailVM.ProductId;
                salesOrderDetail.UnitId = model.SalesOrderDetailVM.UnitId;
                salesOrderDetail.SalesPrice = model.SalesOrderDetailVM.SalesPrice;
                salesOrderDetail.SalesQty = model.SalesOrderDetailVM.SalesQty;
                salesOrderDetail.WarrantyFormDate = model.SalesOrderDetailVM.WarrantyFormDate;
                salesOrderDetail.WarrantyToDate = model.SalesOrderDetailVM.WarrantyToDate;
                salesOrderDetail.ModelNo = model.SalesOrderDetailVM.ModelNo;
                salesOrderDetail.SerialNo = model.SalesOrderDetailVM.SerialNo;
                salesOrderDetail.IsForService = model.SalesOrderDetailVM.IsForService;
                salesOrderDetail.Discount = model.SalesOrderDetailVM.Discount;
                salesOrderDetail.TotalAmount = ((decimal)model.SalesOrderDetailVM.SalesPrice * model.SalesOrderDetailVM.SalesQty) - model.SalesOrderDetailVM.Discount;
                salesOrderDetail.Remarks = model.SalesOrderDetailVM.Remarks;
                await _iEntityRepository.UpdateAsync(salesOrderDetail);
                return true;
            }
            return false;
        }

        public async Task<SalesOrderDetailViewModel> SingleSalesOrderDetails(long id)
        {
            var v = await Task.Run(() => (from t1 in _dbContext.SalesOrderDetails.Where(x => x.IsActive && x.Id == id)

                                          select new SalesOrderDetailViewModel
                                          {
                                              Id = t1.Id,
                                              SalesOrderId = t1.SalesOrderId,
                                              ProductId = t1.ProductId,
                                              ProductName = t1.Product.Name,
                                              UnitId = t1.UnitId,
                                              UnitName = t1.Unit.Name,
                                              SalesPrice = t1.SalesPrice,
                                              SalesQty = t1.SalesQty,
                                              Discount = t1.Discount,
                                              TotalAmount = t1.TotalAmount,
                                              WarrantyFormDate = t1.WarrantyFormDate,
                                              WarrantyToDate = t1.WarrantyToDate,
                                              SerialNo = t1.SerialNo,
                                              ModelNo = t1.ModelNo,
                                              IsForService = t1.IsForService,
                                              Remarks = t1.Remarks,
                                          }).FirstOrDefault());
            return v;
        }

        public async Task<bool> DeleteSalesDetail(long id)
        {

            SalesOrderDetails salesDetails = await _dbContext.SalesOrderDetails.FindAsync(id);
            if (salesDetails == null)
            {
                throw new Exception("Sorry! Order not found!");
            }
            var result = await _iEntityRepository.GetByIdAsync(id);
            result.IsActive = false;
            await _iEntityRepository.UpdateAsync(result);
            return true;
        }
    }

    //public async Task<bool> UpdateAssetPurchaseDetail(AssetPurchaseOrderViewModel model)
    //{
    //    var assetPurchaseOrderDetail = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Id == model.AssetSalesOrderDetailVM.Id);
    //    if (assetPurchaseOrderDetail != null)
    //    {
    //        model.Id = assetPurchaseOrderDetail.PurchaseOrderId;
    //        assetPurchaseOrderDetail.ProductId = model.AssetSalesOrderDetailVM.ProductId;
    //        assetPurchaseOrderDetail.UnitId = model.AssetSalesOrderDetailVM.UnitId;
    //        assetPurchaseOrderDetail.Consumption = model.AssetSalesOrderDetailVM.Consumption;
    //        assetPurchaseOrderDetail.Discount = model.AssetSalesOrderDetailVM.Discount;
    //        assetPurchaseOrderDetail.PurchaseQty = model.AssetSalesOrderDetailVM.PurchaseQty;
    //        assetPurchaseOrderDetail.SalePrice = model.AssetSalesOrderDetailVM.SalePrice;
    //        assetPurchaseOrderDetail.CostPrice = model.AssetSalesOrderDetailVM.CostPrice;
    //        assetPurchaseOrderDetail.TotalAmount = ((decimal)model.AssetSalesOrderDetailVM.PurchaseQty * model.AssetSalesOrderDetailVM.CostPrice) - model.AssetSalesOrderDetailVM.Discount;
    //        assetPurchaseOrderDetail.Remarks = model.AssetSalesOrderDetailVM.Remarks;
    //        await _iEntityRepository.UpdateAsync(assetPurchaseOrderDetail);
    //        return true;
    //    }
    //    return false;
    //}


}

