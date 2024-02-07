using app.EntityModel.AppModels;
using app.Infrastructure.Auth;
using app.Infrastructure.Repository;
using app.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using app.Services.PurchaseOrderServices;
using Microsoft.EntityFrameworkCore;

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
                    Consumption = vm.PurchaseOrderDetailVM.Consumption,
                    UnitId = vm.PurchaseOrderDetailVM.UnitId,
                    CostPrice = vm.PurchaseOrderDetailVM.CostPrice,
                    SalePrice = vm.PurchaseOrderDetailVM.SalePrice,
                    Discount = vm.PurchaseOrderDetailVM.Discount,
                    TotalAmount = (vm.PurchaseOrderDetailVM.CostPrice * (decimal)vm.PurchaseOrderDetailVM.PurchaseQty) - vm.PurchaseOrderDetailVM.Discount,
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
                purchaseOrderDetail.Consumption = model.PurchaseOrderDetailVM.Consumption;
                purchaseOrderDetail.Discount = model.PurchaseOrderDetailVM.Discount;
                purchaseOrderDetail.PurchaseQty = model.PurchaseOrderDetailVM.PurchaseQty;
                purchaseOrderDetail.SalePrice = model.PurchaseOrderDetailVM.SalePrice;
                purchaseOrderDetail.CostPrice = model.PurchaseOrderDetailVM.CostPrice;
                purchaseOrderDetail.TotalAmount = ((decimal)model.PurchaseOrderDetailVM.PurchaseQty * model.PurchaseOrderDetailVM.CostPrice) - model.PurchaseOrderDetailVM.Discount;
                purchaseOrderDetail.Remarks = model.PurchaseOrderDetailVM.Remarks;
                await _iEntityRepository.UpdateAsync(purchaseOrderDetail);
                return true;
            }
            return false;
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
