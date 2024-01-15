﻿using app.EntityModel.AppModels;
using app.Infrastructure.Auth;
using app.Infrastructure.Repository;
using app.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using app.Utility;
using app.Services.PurchaseOrderDetailServices;
using app.Services.DropdownServices;
using Microsoft.EntityFrameworkCore;

namespace app.Services.PurchaseOrderServices
{
    public class PurchaseOrderService : IPurchaseOrderService
    {
        private readonly IEntityRepository<PurchaseOrder> _iEntityRepository;
        private readonly InventoryDbContext _dbContext;
        private readonly IWorkContext _iWorkContext;
        public PurchaseOrderService(IEntityRepository<PurchaseOrder> iEntityRepository, InventoryDbContext dbContext, IWorkContext iWorkContext)
        {
            _iEntityRepository = iEntityRepository;
            _dbContext = dbContext;
            _iWorkContext = iWorkContext;
        }
        public async Task<bool> AddRecord(PurchaseOrderViewModel vm)
        {

            if (vm.OrderStatusId == 0)
            {
                vm.OrderStatusId = PurchaseOrderStatusEnum.Draft;
            }

            var poMax = _dbContext.PurchaseOrder.Count() + 1;
            string poCid = @"PO-" +
                           DateTime.Now.ToString("yy") +
                           DateTime.Now.ToString("MM") +
                           DateTime.Now.ToString("dd") + "-" +
                           poMax.ToString().PadLeft(2, '0');

            PurchaseOrder purchaseOrder = new PurchaseOrder();
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
                                                                   OrderStatusId = PurchaseOrderStatusEnum.Draft,
                                                                   SupplierId = t1.SupplierId,
                                                                   SupplierName = t1.Supplier.Name,
                                                                   StorehouseId = t1.StorehouseId,
                                                                   StoreName = t1.Storehouse.Name,
                                                                   OverallDiscount = t1.OverallDiscount,
                                                                   PurchaseTypeId = t1.PurchaseTypeId,                                                                   
                                                                   Description = t1.Description,                                                                   
                                                               }).FirstOrDefault());

            purchaseOrderModel.PurchaseOrderDetailsList = await Task.Run(() => (from t1 in _dbContext.PurchaseOrderDetail.Where(x => x.IsActive && x.Id == purchaseOrderId)
                                                                          join t2 in _dbContext.PurchaseOrder.Where(x => x.IsActive) on t1.Id equals t2.Id into t2_Join
                                                                          from t2 in t2_Join.DefaultIfEmpty()
                                                                          select new PurchaseOrderDetailViewModel
                                                                          {
                                                                              Id = t1.Id,
                                                                              PurchaseOrderId = t1.PurchaseOrderId,
                                                                              ProductId = t1.ProductId,
                                                                              PurchaseQty = t1.PurchaseQty,
                                                                              Consumption = t1.Consumption,
                                                                              UnitId = t1.UnitId,
                                                                              UnitName = t1.Unit.Name,
                                                                              CostPrice = t1.CostPrice,
                                                                              SalePrice = t1.SalePrice,
                                                                              Discount = t1.Discount,
                                                                              TotalAmount = t1.TotalAmount,                                                                           
                                                                              Remarks = t1.Remarks,
                                                                          }).OrderByDescending(x => x.Id).AsEnumerable());


            return purchaseOrderModel;
        }
    }
}
