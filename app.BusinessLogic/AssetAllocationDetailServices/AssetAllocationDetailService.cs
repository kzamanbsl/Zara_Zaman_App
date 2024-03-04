//using app.EntityModel.AppModels;
//using app.Infrastructure.Auth;
//using app.Infrastructure.Repository;
//using app.Infrastructure;
//using app.Services.AssetPurchaseOrderServices;

//namespace app.Services.AssetAllocationDetailServices
//{

//    public class AssetAllocationDetailService : IAssetAllocationDetailService
//    {
//        private readonly IEntityRepository<PurchaseOrderDetail> _iEntityRepository;
//        private readonly InventoryDbContext _dbContext;
//        public AssetAllocationDetailService(IEntityRepository<PurchaseOrderDetail> iEntityRepository, InventoryDbContext dbContext, IWorkContext iWorkContext)
//        {
//            _iEntityRepository = iEntityRepository;
//            _dbContext = dbContext;
//        }
//        public async Task<bool> AddRecord(AssetPurchaseOrderViewModel vm)
//        {
//            try
//            {
//                PurchaseOrderDetail assetPurchaseOrderDetail = new PurchaseOrderDetail
//                {

//                    PurchaseOrderId = vm.Id,
//                    Id = vm.AssetAllocationDetailVM.Id,
//                    ProductId = vm.AssetAllocationDetailVM.ProductId,
//                    PurchaseQty = vm.AssetAllocationDetailVM.PurchaseQty,
//                    Consumption = vm.AssetAllocationDetailVM.Consumption,
//                    UnitId = vm.AssetAllocationDetailVM.UnitId,
//                    CostPrice = vm.AssetAllocationDetailVM.CostPrice,
//                    SalePrice = vm.AssetAllocationDetailVM.SalePrice,
//                    Discount = vm.AssetAllocationDetailVM.Discount,
//                    TotalAmount = (vm.AssetAllocationDetailVM.CostPrice * (decimal)vm.AssetAllocationDetailVM.PurchaseQty) - vm.AssetAllocationDetailVM.Discount,
//                    Remarks = vm.AssetAllocationDetailVM.Remarks
//                };

//                var res = await _iEntityRepository.AddAsync(assetPurchaseOrderDetail);
//                assetPurchaseOrderDetail.Id = res?.Id ?? 0;
//                return true;
//            }
//            catch (Exception ex)
//            {
//                throw;
//            }

//        }

//        public async Task<bool> UpdateAssetPurchaseDetail(AssetPurchaseOrderViewModel model)
//        {
//            var assetPurchaseOrderDetail = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Id == model.AssetAllocationDetailVM.Id);
//            if (assetPurchaseOrderDetail != null)
//            {
//                model.Id = assetPurchaseOrderDetail.PurchaseOrderId;
//                assetPurchaseOrderDetail.ProductId = model.AssetAllocationDetailVM.ProductId;
//                assetPurchaseOrderDetail.UnitId = model.AssetAllocationDetailVM.UnitId;
//                assetPurchaseOrderDetail.Consumption = model.AssetAllocationDetailVM.Consumption;
//                assetPurchaseOrderDetail.Discount = model.AssetAllocationDetailVM.Discount;
//                assetPurchaseOrderDetail.PurchaseQty = model.AssetAllocationDetailVM.PurchaseQty;
//                assetPurchaseOrderDetail.SalePrice = model.AssetAllocationDetailVM.SalePrice;
//                assetPurchaseOrderDetail.CostPrice = model.AssetAllocationDetailVM.CostPrice;
//                assetPurchaseOrderDetail.TotalAmount = ((decimal)model.AssetAllocationDetailVM.PurchaseQty * model.AssetAllocationDetailVM.CostPrice) - model.AssetAllocationDetailVM.Discount;
//                assetPurchaseOrderDetail.Remarks = model.AssetAllocationDetailVM.Remarks;
//                await _iEntityRepository.UpdateAsync(assetPurchaseOrderDetail);
//                return true;
//            }
//            return false;
//        }

//        public async Task<AssetAllocationDetailViewModel> SingleAssetAllocationDetails(long id)
//        {
//            var v = await Task.Run(() => (from t1 in _dbContext.PurchaseOrderDetail.Where(x => x.IsActive && x.Id == id)

//                                          select new AssetAllocationDetailViewModel
//                                          {
//                                              Id = t1.Id,
//                                              PurchaseOrderId = t1.PurchaseOrderId,
//                                              ProductId = t1.ProductId,
//                                              ProductName = t1.Product.Name,
//                                              PurchaseQty = t1.PurchaseQty,
//                                              Consumption = t1.Consumption,
//                                              UnitId = t1.UnitId,
//                                              UnitName = t1.Unit.Name,
//                                              CostPrice = t1.CostPrice,
//                                              SalePrice = t1.SalePrice,
//                                              Discount = t1.Discount,
//                                              TotalAmount = ((decimal)t1.PurchaseQty * t1.CostPrice) - t1.Discount,
//                                              Remarks = t1.Remarks,
//                                          }).FirstOrDefault());
//            return v;
//        }

//        public async Task<bool> DeleteAssetPurchaseDetail(long id)
//        {

//            PurchaseOrderDetail assetPurchaseDetails = await _dbContext.PurchaseOrderDetail.FindAsync(id);
//            if (assetPurchaseDetails == null)
//            {
//                throw new Exception("Sorry! Order not found!");
//            }
//            var result = await _iEntityRepository.GetByIdAsync(id);
//            result.IsActive = false;
//            await _iEntityRepository.UpdateAsync(result);
//            return true;
//        }
//    }
//}
