using app.Infrastructure.Auth;
using app.Infrastructure.Repository;
using app.Infrastructure;
using app.Utility;
using app.Services.AssetPurchaseOrderDetailServices;
using Microsoft.EntityFrameworkCore;
using app.EntityModel.AppModels;
using app.EntityModel.DataTablePaginationModels;
using app.Services.ProductServices;
using app.Services.PurchaseOrderServices;

namespace app.Services.AssetPurchaseOrderServices
{
    public class AssetPurchaseOrderService : IAssetPurchaseOrderService
    {
        private readonly IEntityRepository<PurchaseOrder> _iEntityRepository;
        private readonly InventoryDbContext _dbContext;
        private readonly IWorkContext _iWorkContext;
        public AssetPurchaseOrderService(IEntityRepository<PurchaseOrder> iEntityRepository, InventoryDbContext dbContext, IWorkContext iWorkContext)
        {
            _iEntityRepository = iEntityRepository;
            _dbContext = dbContext;
            _iWorkContext = iWorkContext;
        }
        public async Task<bool> AddRecord(AssetPurchaseOrderViewModel vm)
        {

            if (vm.OrderStatusId == 0)
            {
                vm.OrderStatusId = (int)PurchaseOrderStatusEnum.Draft;
            }

            var poMax = _dbContext.PurchaseOrder.Count() + 1;
            string poCid = @"PO-" +
                           DateTime.Now.ToString("yy") +
                           DateTime.Now.ToString("MM") +
                           DateTime.Now.ToString("dd") + "-" +
                           poMax.ToString().PadLeft(2, '0');

            PurchaseOrder assetPurchaseOrder = new PurchaseOrder();
            assetPurchaseOrder.OrderNo = poCid;
            assetPurchaseOrder.PurchaseDate = vm.PurchaseDate;
            assetPurchaseOrder.SupplierId = vm.SupplierId;
            assetPurchaseOrder.StorehouseId = vm.StorehouseId;
            assetPurchaseOrder.OverallDiscount = vm.OverallDiscount;
            assetPurchaseOrder.Description = vm.Description;
            assetPurchaseOrder.OrderStatusId = (int)PurchaseOrderStatusEnum.Draft;
            assetPurchaseOrder.PurchaseTypeId = (int)PurchaseTypeEnum.AssetPurchase;
            var res = await _iEntityRepository.AddAsync(assetPurchaseOrder);
            vm.Id = res?.Id ?? 0;
            return true;
        }
        public async Task<AssetPurchaseOrderViewModel> GetAssetPurchaseOrder(long assetPurchaseOrderId = 0)
        {
            AssetPurchaseOrderViewModel assetPurchaseOrderModel = new AssetPurchaseOrderViewModel();
            assetPurchaseOrderModel = await Task.Run(() => (from t1 in _dbContext.PurchaseOrder.Where(x => x.IsActive && x.Id == assetPurchaseOrderId)
                                                            select new AssetPurchaseOrderViewModel
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

            assetPurchaseOrderModel.AssetPurchaseOrderDetailsList = await Task.Run(() => (from t1 in _dbContext.PurchaseOrderDetail.Where(x => x.IsActive && x.PurchaseOrder.Id == assetPurchaseOrderId)
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
                                                                                              //Discount = t1.Discount,
                                                                                              TotalAmount = ((decimal)t1.PurchaseQty * t1.CostPrice) - t1.Discount,
                                                                                              Remarks = t1.Remarks,
                                                                                          }).OrderByDescending(x => x.Id).AsEnumerable());


            return assetPurchaseOrderModel;
        }

        public async Task<bool> ConfirmAssetPurchaseOrder(long id)
        {
            var checkAssetPurchaseOrder = await _dbContext.PurchaseOrder.FirstOrDefaultAsync(c => c.Id == id);
            if (checkAssetPurchaseOrder != null && checkAssetPurchaseOrder.OrderStatusId == (int)PurchaseOrderStatusEnum.Draft)
            {
                checkAssetPurchaseOrder.OrderStatusId = (int)PurchaseOrderStatusEnum.Confirm;
                await _iEntityRepository.UpdateAsync(checkAssetPurchaseOrder);
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteAssetPurchaseOrder(long id)
        {
            var result = await _iEntityRepository.GetByIdAsync(id);
            result.IsActive = false;
            await _iEntityRepository.UpdateAsync(result);
            return true;
        }

        public async Task<AssetPurchaseOrderViewModel> GetAssetPurchaseOrderDetails(long id = 0)
        {
            AssetPurchaseOrderViewModel assetPurchaseOrderModel = new AssetPurchaseOrderViewModel();
            assetPurchaseOrderModel = await Task.Run(() => (from t1 in _dbContext.PurchaseOrder.Where(x => x.IsActive && x.Id == id)
                                                            select new AssetPurchaseOrderViewModel
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

            assetPurchaseOrderModel.AssetPurchaseOrderDetailsList = await Task.Run(() => (from t1 in _dbContext.PurchaseOrderDetail.Where(x => x.IsActive && x.PurchaseOrder.Id == id)
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
                                                                                              //Discount = t1.Discount,
                                                                                              TotalAmount = ((decimal)t1.PurchaseQty * t1.CostPrice) - t1.Discount,
                                                                                              Remarks = t1.Remarks,
                                                                                          }).OrderByDescending(x => x.Id).AsEnumerable());


            return assetPurchaseOrderModel;
        }

        public async Task<bool> RejectAssetPurchaseOrder(long id)
        {
            var checkAssetPurchaseOrder = await _dbContext.PurchaseOrder.FirstOrDefaultAsync(c => c.Id == id);
            if (checkAssetPurchaseOrder != null || checkAssetPurchaseOrder.OrderStatusId == (int)PurchaseOrderStatusEnum.Draft || checkAssetPurchaseOrder.OrderStatusId == (int)PurchaseOrderStatusEnum.Confirm)
            {
                checkAssetPurchaseOrder.OrderStatusId = (int)PurchaseOrderStatusEnum.Reject;
                await _iEntityRepository.UpdateAsync(checkAssetPurchaseOrder);
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateAssetPurchaseOrder(AssetPurchaseOrderViewModel vm)
        {
            var assetPurchaseOrder = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Id == vm.Id);
            if (assetPurchaseOrder != null)
            {
                assetPurchaseOrder.Id = vm.Id;
                assetPurchaseOrder.PurchaseDate = vm.PurchaseDate;
                assetPurchaseOrder.SupplierId = vm.SupplierId;
                assetPurchaseOrder.StorehouseId = vm.StorehouseId;
                await _iEntityRepository.UpdateAsync(assetPurchaseOrder);
                return true;
            }
            return false;
        }

        public async Task<AssetPurchaseOrderViewModel> GetAllRecord()
        {
            AssetPurchaseOrderViewModel assetPurchaseMasterModel = new AssetPurchaseOrderViewModel();
            var dataQuery = await Task.Run(() => (from t1 in _dbContext.PurchaseOrder
                                                  where t1.IsActive == true && t1.PurchaseTypeId == (int)PurchaseTypeEnum.AssetPurchase

                                                  select new AssetPurchaseOrderViewModel
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

            assetPurchaseMasterModel.AssetPurchaseOrderList = await Task.Run(() => dataQuery.ToList());
            assetPurchaseMasterModel.AssetPurchaseOrderList.ToList().ForEach((c => c.OrderStatusName = Enum.GetName(typeof(PurchaseOrderStatusEnum), c.OrderStatusId)));

            var masterIds = assetPurchaseMasterModel.AssetPurchaseOrderList.Select(x => x.Id);

            var matchingDetails = await _dbContext.PurchaseOrderDetail
                .Where(detail => masterIds.Contains(detail.PurchaseOrderId) && detail.IsActive == true)
                .ToListAsync();
            foreach (var master in assetPurchaseMasterModel.AssetPurchaseOrderList)
            {
                var detailsForMaster = matchingDetails.Where(detail => detail.PurchaseOrderId == master.Id);
                decimal? total = detailsForMaster.Sum(detail => (detail.CostPrice * (decimal)detail.PurchaseQty)
                );
                master.TotalAmount = (double)(total ?? 0);
            }
            return assetPurchaseMasterModel;
        }

        public async Task<DataTablePagination<AssetPurchaseOrderSearchDto>> SearchAsync(DataTablePagination<AssetPurchaseOrderSearchDto> searchDto)
        {
            var searchResult = _dbContext.PurchaseOrderDetail.Include(c => c.PurchaseOrder.Storehouse).Include(c=>c.PurchaseOrder.Supplier).Where(c=>c.IsActive==true).AsNoTracking();

            var searchModel = searchDto.SearchVm;
            var filter = searchDto?.Search?.Value?.Trim();
            if (searchModel?.StorehouseId is > 0)
            {
                searchResult = searchResult.Where(c => c.PurchaseOrder.StorehouseId == searchModel.StorehouseId);
            }
            if (searchModel?.SupplierId is > 0)
            {
                searchResult = searchResult.Where(c => c.PurchaseOrder.SupplierId == searchModel.SupplierId);
            }
            if (!string.IsNullOrEmpty(filter))
            {
                filter = filter.ToLower();
                searchResult = searchResult.Where(c =>
                    c.PurchaseOrder.OrderNo.ToString().Contains(filter)
                    || c.PurchaseOrder.PurchaseDate.ToString().Contains(filter)
                    || c.PurchaseOrder.Supplier.Name.ToLower().Contains(filter)
                    || c.PurchaseOrder.Storehouse.Name.ToLower().Contains(filter)
                );
            }

            var pageSize = searchDto.Length ?? 0;
            var skip = searchDto.Start ?? 0;

            var totalRecords = searchResult.Count();
            if (totalRecords <= 0) return searchDto;

            searchDto.RecordsTotal = totalRecords;
            searchDto.RecordsFiltered = totalRecords;
            List<PurchaseOrderDetail> filteredDataList = await searchResult.OrderByDescending(c => c.Id).Skip(skip).Take(pageSize).ToListAsync();

            var sl = searchDto.Start ?? 0;
            searchDto.Data = filteredDataList.Select(c => new AssetPurchaseOrderSearchDto()
            {
                SerialNo = ++sl,
                Id = c.PurchaseOrder.Id,
                OrderNo = c.PurchaseOrder.OrderNo,
                PurchaseDate = c.PurchaseOrder.PurchaseDate,
                StorehouseId = c.PurchaseOrder.StorehouseId,
                Storehouse = c.PurchaseOrder.Storehouse,
                OrderStatusId = (int)(PurchaseOrderStatusEnum)c.PurchaseOrder.OrderStatusId,
                SupplierId = c.PurchaseOrder.SupplierId,
                Supplier = c.PurchaseOrder.Supplier,
                TotalAmount = (double)c.TotalAmount,
            }).ToList();

            return searchDto;
        }
    }
}
