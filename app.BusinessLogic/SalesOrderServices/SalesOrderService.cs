using app.EntityModel.AppModels;
using app.Infrastructure.Auth;
using app.Infrastructure.Repository;
using app.Infrastructure;
using app.Utility;
using app.Services.SalesOrderDetailServices;
using Microsoft.EntityFrameworkCore;
using app.Services.SalesTermsAndConditonServices;

namespace app.Services.SalesOrderServices
{
    public class SalesOrderService : ISalesOrderService
    {
        private readonly IEntityRepository<SalesOrder> _iEntityRepository;
        private readonly InventoryDbContext _dbContext;
        private readonly IWorkContext _iWorkContext;
        public SalesOrderService(IEntityRepository<SalesOrder> iEntityRepository, InventoryDbContext dbContext, IWorkContext iWorkContext)
        {
            _iEntityRepository = iEntityRepository;
            _dbContext = dbContext;
            _iWorkContext = iWorkContext;
        }
        public async Task<bool> AddSalesOrder(SalesOrderViewModel vm)
        {

            if (vm.OrderStatusId == 0)
            {
                vm.OrderStatusId = (int)SalesOrderStatusEnum.Draft;
            }

            var soMax = _dbContext.SalesOrder.Count() + 1;
            string soCid = @"SO#" +
                           DateTime.Now.ToString("yy") +
                           DateTime.Now.ToString("MM") +
                           DateTime.Now.ToString("dd") + "-" +
                           soMax.ToString().PadLeft(2, '0');

            SalesOrder salesOrder = new SalesOrder();
            salesOrder.OrderNo = soCid;
            salesOrder.SalesDate = vm.SalesDate;
            salesOrder.StorehouseId = vm.StorehouseId;
            salesOrder.CustomerId = vm.CustomerId;
            salesOrder.OverallDiscount = vm.OverallDiscount;
            salesOrder.Description = vm.Description;
            salesOrder.TermsAndCondition = vm.TermsAndCondition;
            salesOrder.DeliveryDate = vm.DeliveryDate;
            salesOrder.DeliveryAddress = vm.DeliveryAddress;
            salesOrder.PaymentStatusId = (int)PaymentStatusEnum.Due;
            salesOrder.OrderStatusId = (int)SalesOrderStatusEnum.Draft;
            var res = await _iEntityRepository.AddAsync(salesOrder);
            vm.Id = res?.Id ?? 0;
            return true;
        }
        public async Task<SalesOrderViewModel> GetSalesOrder(long salesOrderId = 0)
        {
            SalesOrderViewModel SalesOrderModel = new SalesOrderViewModel();
            SalesOrderModel = await Task.Run(() => (from t1 in _dbContext.SalesOrder.Where(x => x.IsActive && x.Id == salesOrderId)
                                                    select new SalesOrderViewModel
                                                    {
                                                        Id = t1.Id,
                                                        SalesDate = t1.SalesDate,
                                                        OrderNo = t1.OrderNo,
                                                        OrderStatusId = (int)(SalesOrderStatusEnum)t1.OrderStatusId,
                                                        StorehouseId = t1.StorehouseId,
                                                        StoreName = t1.Storehouse.Name,
                                                        CustomerId = t1.CustomerId,
                                                        CustomerName = t1.Customer.Name,
                                                        CustomerPhoneNo = t1.Customer.Phone,
                                                        DeliveryDate = t1.DeliveryDate,
                                                        DeliveryAddress = t1.DeliveryAddress,
                                                        PaymentStatusId = (int)(PaymentStatusEnum)t1.PaymentStatusId,
                                                        TermsAndCondition = t1.TermsAndCondition,
                                                        OverallDiscount = t1.OverallDiscount,
                                                        Description = t1.Description,
                                                    }).FirstOrDefault());

            SalesOrderModel.SalesOrderDetailsList = await Task.Run(() => (from t1 in _dbContext.SalesOrderDetails.Where(x => x.IsActive && x.SalesOrder.Id == salesOrderId)
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
                                                                              //SerialNo = t1.SerialNo,
                                                                              //ModelNo = t1.ModelNo,
                                                                              IsForService = t1.IsForService,
                                                                              Remarks = t1.Remarks,
                                                                          }).OrderByDescending(x => x.Id).AsQueryable());


            return SalesOrderModel;
        }

        public async Task<SalesOrderViewModel> SalesOrderById(long id)
        {
            SalesOrderViewModel sendData = new SalesOrderViewModel();
            var result = await _dbContext.SalesOrder.FirstOrDefaultAsync(x => x.Id == id);
            sendData.Id = result.Id;
            sendData.SalesDate = result.SalesDate;
            sendData.OrderNo = result.OrderNo;
            sendData.OrderStatusId = (int)(SalesOrderStatusEnum)result.OrderStatusId;
            sendData.StorehouseId = result.StorehouseId;
            sendData.CustomerId = result.CustomerId;
            sendData.DeliveryDate = result.DeliveryDate;
            sendData.DeliveryAddress = result.DeliveryAddress;
            sendData.PaymentStatusId = (int)(PaymentStatusEnum)result.PaymentStatusId;
            sendData.TermsAndCondition = result.TermsAndCondition;
            sendData.OverallDiscount = result.OverallDiscount;
            sendData.Description = result.Description;
            return sendData;
        }


        public async Task<SalesOrderViewModel> GetAllSalesRecord()
        {
            SalesOrderViewModel salesMaster = new SalesOrderViewModel();
            var dataQuery = await Task.Run(() => (from t1 in _dbContext.SalesOrder
                                                  where t1.IsActive == true

                                                  select new SalesOrderViewModel
                                                  {
                                                      Id = t1.Id,
                                                      OrderNo = t1.OrderNo,
                                                      SalesDate = t1.SalesDate,
                                                      CustomerId = t1.CustomerId,
                                                      CustomerName = t1.Customer.Name,
                                                      DeliveryDate = t1.DeliveryDate,
                                                      PaymentStatusId = (int)(PaymentStatusEnum)t1.PaymentStatusId,
                                                      OrderStatusId = (int)(SalesOrderStatusEnum)t1.OrderStatusId,
                                                  }).OrderByDescending(x => x.Id).AsQueryable());

            salesMaster.SalesOrderList = await Task.Run(() => dataQuery.ToList());
            salesMaster.SalesOrderList.ToList().ForEach((c => c.OrderStatusName = Enum.GetName(typeof(PurchaseOrderStatusEnum), c.OrderStatusId)));
            salesMaster.SalesOrderList.ToList().ForEach((c => c.PaymentStatusName = Enum.GetName(typeof(PaymentStatusEnum), c.PaymentStatusId)));

            var masterIds = salesMaster.SalesOrderList.Select(x => x.Id);

            var matchingDetails = await _dbContext.SalesOrderDetails
                .Where(detail => masterIds.Contains(detail.SalesOrderId) && detail.IsActive == true)
                .ToListAsync();

            foreach (var master in salesMaster.SalesOrderList)
            {
                var detailsForMaster = matchingDetails.Where(detail => detail.SalesOrderId == master.Id);
                decimal? total = detailsForMaster.Sum(detail => (detail.SalesPrice * (decimal)detail.SalesQty) - detail.Discount);
                master.TotalAmount = (double)(total ?? 0);
            }
            return salesMaster;
        }

        public async Task<bool> ConfirmSalesOrder(long id)
        {
            var checkSalesOrder = await _dbContext.SalesOrder.FirstOrDefaultAsync(c => c.Id == id);
            if (checkSalesOrder != null && checkSalesOrder.OrderStatusId == (int)SalesOrderStatusEnum.Draft)
            {
                checkSalesOrder.OrderStatusId = (int)SalesOrderStatusEnum.Confirm;
                await _iEntityRepository.UpdateAsync(checkSalesOrder);
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteSalesOrder(long id)
        {
            var result = await _iEntityRepository.GetByIdAsync(id);
            result.IsActive = false;
            await _iEntityRepository.UpdateAsync(result);
            return true;
        }

        public async Task<SalesOrderViewModel> GetSalesOrderDetails(long id = 0)
        {
            SalesOrderViewModel purchaseOrderModel = new SalesOrderViewModel();
            purchaseOrderModel = await Task.Run(() => (from t1 in _dbContext.SalesOrder.Where(x => x.IsActive && x.Id == id)
                                                       select new SalesOrderViewModel
                                                       {
                                                           Id = t1.Id,
                                                           SalesDate = t1.SalesDate,
                                                           OrderNo = t1.OrderNo,
                                                           OrderStatusId = (int)(SalesOrderStatusEnum)t1.OrderStatusId,
                                                           Description = t1.Description,
                                                       }).FirstOrDefault());

            purchaseOrderModel.SalesOrderDetailsList = await Task.Run(() => (from t1 in _dbContext.PurchaseOrderDetail.Where(x => x.IsActive)
                                                                             select new SalesOrderDetailViewModel
                                                                             {
                                                                                 Id = t1.Id,
                                                                                 Remarks = t1.Remarks,
                                                                             }).OrderByDescending(x => x.Id).AsQueryable());


            return purchaseOrderModel;
        }

        public async Task<bool> RejectSalesOrder(long id)
        {
            var checkSalesOrder = await _dbContext.SalesOrder.FirstOrDefaultAsync(c => c.Id == id);
            if (checkSalesOrder != null || checkSalesOrder.OrderStatusId == (int)SalesOrderStatusEnum.Draft || checkSalesOrder.OrderStatusId == (int)SalesOrderStatusEnum.Confirm)
            {
                checkSalesOrder.OrderStatusId = (int)SalesOrderStatusEnum.Reject;
                await _iEntityRepository.UpdateAsync(checkSalesOrder);
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateSalesOrder(SalesOrderViewModel vm)
        {
            var salesOrder = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Id == vm.Id);
            if (salesOrder != null)
            {
                salesOrder.Id = vm.Id;
                salesOrder.DeliveryDate = vm.DeliveryDate;
                salesOrder.StorehouseId = (int)vm.StorehouseId;
                salesOrder.CustomerId = vm.CustomerId;
                salesOrder.DeliveryAddress = vm.DeliveryAddress;
                await _iEntityRepository.UpdateAsync(salesOrder);
                return true;
            }
            return false;
        }


        public async Task<SalesTermsAndConditionViewModel> GetSOTermsAndCondition(long id)
        {
            var item = await (from t1 in _dbContext.SalesTermsAndCondition.Where(t => t.IsActive == true && t.Id == id)
                              select new SalesTermsAndConditionViewModel
                              {
                                  Value = t1.Value,
                                  Key = t1.Key,
                                  Id = t1.Id
                              }).FirstOrDefaultAsync();
            return item;
        }
    }
}
