using app.EntityModel.AppModels;
using app.Infrastructure.Auth;
using app.Infrastructure.Repository;
using app.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using app.Services.AssetPurchaseOrderServices;
using Microsoft.EntityFrameworkCore;

namespace app.Services.AssetPurchaseOrderDetailServices
{
    public class AssetPurchaseOrderDetailService : IAssetPurchaseOrderDetailService
    {
        private readonly IEntityRepository<PurchaseOrderDetail> _iEntityRepository;
        private readonly InventoryDbContext _dbContext;
        public AssetPurchaseOrderDetailService(IEntityRepository<PurchaseOrderDetail> iEntityRepository, InventoryDbContext dbContext, IWorkContext iWorkContext)
        {
            _iEntityRepository = iEntityRepository;
            _dbContext = dbContext;
        }
        public async Task<bool> AddRecord(AssetPurchaseOrderViewModel vm)
        {
            try
            {
                PurchaseOrderDetail assetPurchaseOrderDetail = new PurchaseOrderDetail
                {

                    PurchaseOrderId = vm.Id,
                    Id = vm.AssetPurchaseOrderDetailVM.Id,
                    ProductId = vm.AssetPurchaseOrderDetailVM.ProductId,
                    PurchaseQty = vm.AssetPurchaseOrderDetailVM.PurchaseQty,
                    Consumption = vm.AssetPurchaseOrderDetailVM.Consumption,
                    UnitId = vm.AssetPurchaseOrderDetailVM.UnitId,
                    CostPrice = vm.AssetPurchaseOrderDetailVM.CostPrice,
                    SalePrice = vm.AssetPurchaseOrderDetailVM.SalePrice,
                    Discount = vm.AssetPurchaseOrderDetailVM.Discount,
                    TotalAmount = (vm.AssetPurchaseOrderDetailVM.CostPrice * (decimal)vm.AssetPurchaseOrderDetailVM.PurchaseQty) - vm.AssetPurchaseOrderDetailVM.Discount,
                    Remarks = vm.AssetPurchaseOrderDetailVM.Remarks
                };

                var res = await _iEntityRepository.AddAsync(assetPurchaseOrderDetail);
                assetPurchaseOrderDetail.Id = res?.Id ?? 0;
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public async Task<bool> UpdatePurchaseDetail(AssetPurchaseOrderViewModel model)
        {
            var assetPurchaseOrderDetail = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Id == model.AssetPurchaseOrderDetailVM.Id);
            if (assetPurchaseOrderDetail != null)
            {
                model.Id = assetPurchaseOrderDetail.PurchaseOrderId;
                assetPurchaseOrderDetail.ProductId = model.AssetPurchaseOrderDetailVM.ProductId;
                assetPurchaseOrderDetail.UnitId = model.AssetPurchaseOrderDetailVM.UnitId;
                assetPurchaseOrderDetail.Consumption = model.AssetPurchaseOrderDetailVM.Consumption;
                assetPurchaseOrderDetail.Discount = model.AssetPurchaseOrderDetailVM.Discount;
                assetPurchaseOrderDetail.PurchaseQty = model.AssetPurchaseOrderDetailVM.PurchaseQty;
                assetPurchaseOrderDetail.SalePrice = model.AssetPurchaseOrderDetailVM.SalePrice;
                assetPurchaseOrderDetail.CostPrice = model.AssetPurchaseOrderDetailVM.CostPrice;
                assetPurchaseOrderDetail.TotalAmount = ((decimal)model.AssetPurchaseOrderDetailVM.PurchaseQty * model.AssetPurchaseOrderDetailVM.CostPrice) - model.AssetPurchaseOrderDetailVM.Discount;
                assetPurchaseOrderDetail.Remarks = model.AssetPurchaseOrderDetailVM.Remarks;
                await _iEntityRepository.UpdateAsync(assetPurchaseOrderDetail);
                return true;
            }
            return false;
        }

        public async Task<AssetPurchaseOrderDetailViewModel> SingleAssetPurchaseOrderDetails(long id)
        {
            var v = await Task.Run(() => (from t1 in _dbContext.PurchaseOrderDetail.Where(x => x.IsActive && x.Id == id)

                                          select new AssetPurchaseOrderDetailViewModel
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

        public async Task<bool> DeletePurchaseDetail(long id)
        {

            PurchaseOrderDetail assetPurchaseDetails = await _dbContext.PurchaseOrderDetail.FindAsync(id);
            if (assetPurchaseDetails == null)
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
