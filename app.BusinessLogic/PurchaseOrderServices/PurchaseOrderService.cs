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
using app.Services.PurchaseOrderDetailServices;
using app.Services.DropdownServices;
using Microsoft.EntityFrameworkCore;
using app.Services.ProductServices;

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
                                                                              Discount = t1.Discount,
                                                                              TotalAmount = ((decimal)t1.PurchaseQty * t1.CostPrice) - t1.Discount,                                                                           
                                                                              Remarks = t1.Remarks,
                                                                          }).OrderByDescending(x => x.Id).AsEnumerable());


            return purchaseOrderModel;
        }



        //public async Task<PurchaseOrderViewModel> GetAllRecord()
        //{
        //    PurchaseOrderViewModel purchaseOrder = new PurchaseOrderViewModel();
        //    var dataQuery = (from t1 in _dbContext.PurchaseOrder
        //                     where t1.IsActive 
        //                     select new PurchaseOrderViewModel
        //                     {
        //                         Id = t1.Id,
        //                         OrderNo = t1.OrderNo,
        //                         PurchaseDate = t1.PurchaseDate,
        //                         OrderStatusId = (PurchaseOrderStatusEnum)t1.OrderStatusId,
        //                         OverallDiscount = t1.OverallDiscount,
        //                         StorehouseId = (int)BusinessCenterEnum.Storehouse,

        //                     }).OrderByDescending(x => x.Id).AsEnumerable();


        //    //purchaseOrder.PurchaseOrderList = await Task.Run(() => dataQuery.ToList());

        //    //var masterIds = purchaseOrder.PurchaseOrderList.Select(x => x.Id);

        //    //var matchingDetails = await _dbContext.PurchaseOrderDetail
        //    //                            .Where(detail => masterIds.Contains(detail.Id))
        //    //                            .ToListAsync();

        //    //foreach (var master in purchaseOrder.PurchaseOrderList)
        //    //{
        //    //    var detailsForMaster = matchingDetails.Where(detail => detail.Id == master.Id);
        //    //    double? total = detailsForMaster.Sum(detail =>(double)detail.CostPrice + detail.PurchaseQty);
        //    //    master.TotalAmount = (double)total;
        //    //}

        //    return purchaseOrder;
        //}




        public async Task<PurchaseOrderViewModel> GetAllRecord()
        {
            var result = _dbContext.PurchaseOrder
        .Include(po => po.Supplier).ToList()
        .Select(po => new PurchaseOrderViewModel
        {
            PurchaseDate = po.PurchaseDate,
            Description = po.Description,
            OrderNo = po.OrderNo,
            OverallDiscount = po.OverallDiscount,
            OrderStatusName = Enum.GetName(typeof(PurchaseOrderStatusEnum), po.OrderStatusId),
            SupplierId = po.SupplierId,
            SupplierName = po.Supplier != null ? po.Supplier.Name : null,
            StorehouseId = po.StorehouseId,
            StoreName = po.Storehouse != null ? po.Storehouse.Name : null,
        }).AsQueryable();

            var purchaseOrderViewModel = new PurchaseOrderViewModel
            {
                PurchaseOrderList = result
            };

            return purchaseOrderViewModel;
        }


        public async Task<PurchaseOrderDetailViewModel> SingleOrderDetails(long id)
        {
            var v = await Task.Run(() => (from t1 in _dbContext.PurchaseOrderDetail.Where(x => x.IsActive && x.Id == id)
                                         
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
                                              Discount = t1.Discount,
                                              TotalAmount = ((decimal)t1.PurchaseQty * t1.CostPrice) - t1.Discount,
                                              Remarks = t1.Remarks,
                                          }).FirstOrDefault());
            return v;
        }

        public async Task<bool> UpdateRecord(PurchaseOrderViewModel vm)
        {
            var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Id == vm.Id && f.IsActive == true);

            if (vm.Id == 0)
            {
                vm.OrderStatusId = PurchaseOrderStatusEnum.Draft;
                return false;
            }

            var existingPurchaseOrder = await _iEntityRepository.GetByIdAsync(vm.Id);
            if (existingPurchaseOrder == null)
            {
                vm.OrderStatusId = PurchaseOrderStatusEnum.Draft;
                return false;
            }
            existingPurchaseOrder.PurchaseDate = vm.PurchaseDate;
            existingPurchaseOrder.SupplierId = vm.SupplierId;
            existingPurchaseOrder.StorehouseId = vm.StorehouseId;
            existingPurchaseOrder.OverallDiscount = vm.OverallDiscount;
            existingPurchaseOrder.Description = vm.Description;
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteRecord(PurchaseOrderViewModel vm)
        {
            var result = await _iEntityRepository.GetByIdAsync(vm.Id);
            result.IsActive = false;
            await _iEntityRepository.UpdateAsync(result);
            return true;
        }
    }
}
