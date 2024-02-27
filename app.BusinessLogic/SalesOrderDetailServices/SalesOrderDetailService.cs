using app.EntityModel.AppModels;
using app.Infrastructure.Auth;
using app.Infrastructure.Repository;
using app.Infrastructure;
using app.Services.SalesOrderServices;
using app.Services.PurchaseOrderServices;

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
            var salesOrderDetailOrder = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Id == vm.Id);
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

    }
}
