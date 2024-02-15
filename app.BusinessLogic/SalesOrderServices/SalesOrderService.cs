using app.EntityModel.AppModels;
using app.Infrastructure.Auth;
using app.Infrastructure.Repository;
using app.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using app.Utility;
using app.Services.SalesOrderDetailServices;
using app.Services.DropdownServices;
using Microsoft.EntityFrameworkCore;
using app.Services.ProductServices;
using app.Services.LeaveBalanceServices;
using app.Services.JobStatusServices;
using app.Services.StorehouseServices;
using app.Services.SalesOrderServices;

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
        public async Task<bool> AddRecord(SalesOrderViewModel vm)
        {

            if (vm.OrderStatusId == 0)
            {
                vm.OrderStatusId = (int)SalesOrderStatusEnum.Draft;
            }

            var poMax = _dbContext.SalesOrder.Count() + 1;
            string poCid = @"PO-" +
                           DateTime.Now.ToString("yy") +
                           DateTime.Now.ToString("MM") +
                           DateTime.Now.ToString("dd") + "-" +
                           poMax.ToString().PadLeft(2, '0');

            SalesOrder purchaseOrder = new SalesOrder();
            purchaseOrder.OrderNo = poCid;
            purchaseOrder.SalesDate = vm.SalesDate;
            purchaseOrder.StorehouseId = vm.StorehouseId;
            purchaseOrder.OverallDiscount = vm.OverallDiscount;
            purchaseOrder.Description = vm.Description;
            purchaseOrder.OrderStatusId = (int)SalesOrderStatusEnum.Draft;
            var res = await _iEntityRepository.AddAsync(purchaseOrder);
            vm.Id = res?.Id ?? 0;
            return true;
        }
        public async Task<SalesOrderViewModel> GetSalesOrder(long purchaseOrderId = 0)
        {
            SalesOrderViewModel purchaseOrderModel = new SalesOrderViewModel();
            purchaseOrderModel = await Task.Run(() => (from t1 in _dbContext.SalesOrder.Where(x => x.IsActive && x.Id == purchaseOrderId)
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





        public async Task<SalesOrderViewModel> GetAllRecord()
        {
            SalesOrderViewModel purchaseMasterModel = new SalesOrderViewModel();
            var dataQuery = await Task.Run(() => (from t1 in _dbContext.SalesOrder
                                                  where t1.IsActive == true 

                                                  select new SalesOrderViewModel
                                                  {
                                                      Id = t1.Id,
                                                      OrderNo = t1.OrderNo,
                                                      SalesDate = t1.SalesDate,
                                                      OrderStatusId = (int)(SalesOrderStatusEnum)t1.OrderStatusId,

                                                  }).OrderByDescending(x => x.Id).AsQueryable());

            return purchaseMasterModel;
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
            var purchaseOrder = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Id == vm.Id);
            if (purchaseOrder != null)
            {
                purchaseOrder.Id = vm.Id;
                purchaseOrder.StorehouseId = vm.StorehouseId;
                await _iEntityRepository.UpdateAsync(purchaseOrder);
                return true;
            }
            return false;
        }
    }
}
