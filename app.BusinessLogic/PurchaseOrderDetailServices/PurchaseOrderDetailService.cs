using app.EntityModel.AppModels;
using app.Infrastructure.Auth;
using app.Infrastructure.Repository;
using app.Infrastructure;
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
                    Id = vm.PurchaseOrderDetailVM.Id,
                    ProductId = vm.PurchaseOrderDetailVM.ProductId,
                    PurchaseQty = vm.PurchaseOrderDetailVM.PurchaseQty,
                    UnitId = vm.PurchaseOrderDetailVM.UnitId,
                    SalePrice = vm.PurchaseOrderDetailVM.SalePrice,
                    TotalAmount = (vm.PurchaseOrderDetailVM.SalePrice * (decimal)vm.PurchaseOrderDetailVM.PurchaseQty),
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

        public async Task<bool> UpdatePurchaseDetail(PurchaseOrderViewModel model)
        {
            var purchaseOrderDetail = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Id == model.PurchaseOrderDetailVM.Id);
            if (purchaseOrderDetail != null)
            {
                model.Id = purchaseOrderDetail.PurchaseOrderId;
                purchaseOrderDetail.ProductId = model.PurchaseOrderDetailVM.ProductId;
                purchaseOrderDetail.UnitId = model.PurchaseOrderDetailVM.UnitId;
                purchaseOrderDetail.PurchaseQty = model.PurchaseOrderDetailVM.PurchaseQty;
                purchaseOrderDetail.SalePrice = model.PurchaseOrderDetailVM.SalePrice;
                purchaseOrderDetail.TotalAmount = ((decimal)model.PurchaseOrderDetailVM.PurchaseQty * model.PurchaseOrderDetailVM.SalePrice);
                purchaseOrderDetail.Remarks = model.PurchaseOrderDetailVM.Remarks;
                await _iEntityRepository.UpdateAsync(purchaseOrderDetail);
                return true;
            }
            return false;
        }

        public async Task<PurchaseOrderDetailViewModel> SinglePurchaseOrderDetails(long id)
        {
            var v = await Task.Run(() => (from t1 in _dbContext.PurchaseOrderDetail.Where(x => x.IsActive && x.Id == id)

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
                                          }).FirstOrDefault());
            return v;
        }

        public async Task<bool> DeletePurchaseDetail(long id)
        {

            PurchaseOrderDetail purchaseDetails = await _dbContext.PurchaseOrderDetail.FindAsync(id);
            if (purchaseDetails == null)
            {
                throw new Exception("Sorry! Order not found!");
            }
            var result = await _iEntityRepository.GetByIdAsync(id);
            result.IsActive = false;
            await _iEntityRepository.UpdateAsync(result);
            return true;
        }
    }
}
