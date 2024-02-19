using app.EntityModel.AppModels;
using app.Infrastructure.Auth;
using app.Infrastructure.Repository;
using app.Infrastructure;
using app.Utility;
using Microsoft.EntityFrameworkCore;
using app.Services.SalesOrderDetailServices;
using app.Services.SalesOrderServices;
using app.Services.PurchaseOrderServices;

namespace app.Services.SalesOrderDetailServices
{
    public class SalesOrderDetailService : ISalesOrderDetailService
    {
<<<<<<< HEAD
        private readonly IEntityRepository<PurchaseOrderList> _iEntityRepository;
        private readonly InventoryDbContext _dbContext;
        private readonly IWorkContext _iWorkContext;
        public SalesOrderDetailService(IEntityRepository<PurchaseOrderList> iEntityRepository, InventoryDbContext dbContext, IWorkContext iWorkContext)
=======
        private readonly IEntityRepository<SalesOrderDetails> _iEntityRepository;
        private readonly InventoryDbContext _dbContext;
        private readonly IWorkContext _iWorkContext;
        public SalesOrderDetailService(IEntityRepository<SalesOrderDetails> iEntityRepository, InventoryDbContext dbContext, IWorkContext iWorkContext)
>>>>>>> dd06daa72bec12423b6d09ba182da259f96d7bab
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

<<<<<<< HEAD
            var poMax = _dbContext.PurchaseOrder.Count() + 1;
            string poCid = @"PO-" +
                           DateTime.Now.ToString("yy") +
                           DateTime.Now.ToString("MM") +
                           DateTime.Now.ToString("dd") + "-" +
                           poMax.ToString().PadLeft(2, '0');

            PurchaseOrderList purchaseOrder = new PurchaseOrderList();
            purchaseOrder.OrderNo = poCid;
            purchaseOrder.PurchaseDate = vm.PurchaseDate;
            purchaseOrder.SupplierId = vm.SupplierId;
            purchaseOrder.StorehouseId = vm.StorehouseId;
            purchaseOrder.OverallDiscount = vm.OverallDiscount;
            purchaseOrder.Description = vm.Description;
            purchaseOrder.OrderStatusId = (int)PurchaseOrderStatusEnum.Draft;
            purchaseOrder.PurchaseTypeId = (int)PurchaseTypeEnum.Purchase;
            var res = await _iEntityRepository.AddAsync(purchaseOrder);
            vm.Id = res?.Id ?? 0;
            return true;
        }
        public async Task<PurchaseOrderViewModel> GetPurchaseOrder(long purchaseOrderId = 0)
        {
            PurchaseOrderViewModel purchaseOrderModel = new PurchaseOrderViewModel();
            purchaseOrderModel = await Task.Run(() => (from t1 in _dbContext.PurchaseOrder.Where(x => x.IsActive && x.Id == purchaseOrderId)
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
                                                           OverallDiscount = t1.OverallDiscount,
                                                           PurchaseTypeId = t1.PurchaseTypeId,
                                                           Description = t1.Description,
                                                       }).FirstOrDefault());

            purchaseOrderModel.PurchaseOrderDetailsList = await Task.Run(() => (from t1 in _dbContext.PurchaseOrderDetail.Where(x => x.IsActive && x.PurchaseOrder.Id == purchaseOrderId)
                                                                                select new PurchaseOrderDetailViewModel
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
                                                                                    //Discount = t1.Discount,
                                                                                    TotalAmount = ((decimal)t1.PurchaseQty * t1.CostPrice) - t1.Discount,
                                                                                    Remarks = t1.Remarks,
                                                                                }).OrderByDescending(x => x.Id).AsQueryable());


            return purchaseOrderModel;
        }





        public async Task<PurchaseOrderViewModel> GetAllRecord()
        {
            PurchaseOrderViewModel purchaseMasterModel = new PurchaseOrderViewModel();
            var dataQuery = await Task.Run(() => (from t1 in _dbContext.PurchaseOrder
                                                  where t1.IsActive == true && t1.PurchaseTypeId == (int)PurchaseTypeEnum.Purchase

                                                  select new PurchaseOrderViewModel
                                                  {
                                                      Id = t1.Id,
                                                      OrderNo = t1.OrderNo,
                                                      PurchaseDate = t1.PurchaseDate,
                                                      SupplierId = t1.SupplierId,
                                                      SupplierName = t1.Supplier.Name,
                                                      StorehouseId = t1.StorehouseId,
                                                      StoreName = t1.Storehouse.Name,
                                                      OrderStatusId = (int)(PurchaseOrderStatusEnum)t1.OrderStatusId,

                                                  }).OrderByDescending(x => x.Id).AsQueryable());

            purchaseMasterModel.PurchaseOrderList = await Task.Run(() => dataQuery.ToList());
            purchaseMasterModel.PurchaseOrderList.ToList().ForEach((c => c.OrderStatusName = Enum.GetName(typeof(PurchaseOrderStatusEnum), c.OrderStatusId)));

            var masterIds = purchaseMasterModel.PurchaseOrderList.Select(x => x.Id);

            var matchingDetails = await _dbContext.PurchaseOrderDetail
                .Where(detail => masterIds.Contains(detail.PurchaseOrderId) && detail.IsActive == true)
                .ToListAsync();
            foreach (var master in purchaseMasterModel.PurchaseOrderList)
            {
                var detailsForMaster = matchingDetails.Where(detail => detail.PurchaseOrderId == master.Id);
                decimal? total = detailsForMaster.Sum(detail => (detail.CostPrice * (decimal)detail.PurchaseQty)
                );
                master.TotalAmount = (double)(total ?? 0);
            }
            return purchaseMasterModel;
        }

        public async Task<bool> ConfirmPurchaseOrder(long id)
        {
            var checkPurchaseOrder = await _dbContext.PurchaseOrder.FirstOrDefaultAsync(c => c.Id == id);
            if (checkPurchaseOrder != null && checkPurchaseOrder.OrderStatusId == (int)PurchaseOrderStatusEnum.Draft)
            {
                checkPurchaseOrder.OrderStatusId = (int)PurchaseOrderStatusEnum.Confirm;
                await _iEntityRepository.UpdateAsync(checkPurchaseOrder);
=======
                var res = await _iEntityRepository.AddAsync(purchaseOrderDetail);
                purchaseOrderDetail.Id = res?.Id ?? 0;
>>>>>>> dd06daa72bec12423b6d09ba182da259f96d7bab
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
