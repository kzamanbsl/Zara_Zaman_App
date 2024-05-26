using app.Infrastructure.Auth;
using app.Infrastructure.Repository;
using app.Infrastructure;
using app.Utility;
using app.Services.PurchaseOrderDetailServices;
using Microsoft.EntityFrameworkCore;
using app.EntityModel.DataTablePaginationModels;
using app.Services.SupplierServices;
using app.EntityModel.AppModels.PurchaseModels;

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

            try
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

                PurchaseOrder purchaseOrder = new PurchaseOrder();
                purchaseOrder.OrderNo = poCid;
                purchaseOrder.PurchaseDate = vm.PurchaseDate;
                purchaseOrder.SupplierId = vm.SupplierId;
                purchaseOrder.StorehouseId = vm.StorehouseId;
                purchaseOrder.Description = vm.Description;
                purchaseOrder.OrderStatusId = (int)PurchaseOrderStatusEnum.Draft;
                purchaseOrder.PurchaseTypeId = (int)PurchaseTypeEnum.Purchase;
                var res = await _iEntityRepository.AddAsync(purchaseOrder);
                vm.Id = res?.Id ?? 0;
                return true;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<bool> UpdatePurchaseOrder(PurchaseOrderViewModel vm)
        {
            var purchaseOrder = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Id == vm.Id);
            if (purchaseOrder != null)
            {
                purchaseOrder.Id = vm.Id;
                purchaseOrder.PurchaseDate = vm.PurchaseDate;
                purchaseOrder.SupplierId = vm.SupplierId;
                purchaseOrder.StorehouseId = vm.StorehouseId;
                await _iEntityRepository.UpdateAsync(purchaseOrder);
                return true;
            }
            return false;
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
                                                                                    UnitId = t1.UnitId,
                                                                                    UnitName = t1.Unit.Name,
                                                                                    SalePrice = t1.SalePrice,
                                                                                    //Discount = t1.Discount,
                                                                                    TotalAmount = ((decimal)t1.PurchaseQty * t1.SalePrice),
                                                                                    Remarks = t1.Remarks,
                                                                                }).OrderByDescending(x => x.Id).AsEnumerable());


            return purchaseOrderModel;
        }

        public async Task<PurchaseOrderViewModel> GetPurchaseOrderDetails(long id = 0)
        {
            PurchaseOrderViewModel purchaseOrderModel = new PurchaseOrderViewModel();
            purchaseOrderModel = await Task.Run(() => (from t1 in _dbContext.PurchaseOrder.Where(x => x.IsActive && x.Id == id)
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
                                                           PurchaseTypeId = t1.PurchaseTypeId,
                                                           Description = t1.Description,
                                                           RejectionCause = t1.RejectionCause,
                                                       }).FirstOrDefault());

            purchaseOrderModel.PurchaseOrderDetailsList = await Task.Run(() => (from t1 in _dbContext.PurchaseOrderDetail.Where(x => x.IsActive && x.PurchaseOrder.Id == id)
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
                                                                                    //Discount = t1.Discount,
                                                                                    TotalAmount = ((decimal)t1.PurchaseQty * t1.SalePrice),
                                                                                    Remarks = t1.Remarks,
                                                                                }).OrderByDescending(x => x.Id).AsEnumerable());


            return purchaseOrderModel;
        }
        public async Task<bool> ConfirmPurchaseOrder(long id)
        {
            var checkPurchaseOrder = await _dbContext.PurchaseOrder.FirstOrDefaultAsync(c => c.Id == id);
            if (checkPurchaseOrder != null && checkPurchaseOrder.OrderStatusId == (int)PurchaseOrderStatusEnum.Draft)
            {
                checkPurchaseOrder.OrderStatusId = (int)PurchaseOrderStatusEnum.Confirm;
                await _iEntityRepository.UpdateAsync(checkPurchaseOrder);
                return true;
            }
            return false;
        }
        public async Task<bool> RejectPurchaseOrder(PurchaseOrderViewModel vm)
        {
            var purchaseOrder = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Id == vm.Id);
            if (purchaseOrder != null || purchaseOrder.OrderStatusId == (int)PurchaseOrderStatusEnum.Draft || purchaseOrder.OrderStatusId == (int)PurchaseOrderStatusEnum.Confirm)
            {
                purchaseOrder.RejectionCause = vm.RejectionCause;
                purchaseOrder.OrderStatusId = (int)PurchaseOrderStatusEnum.Reject;
                await _iEntityRepository.UpdateAsync(purchaseOrder);
                return true;
            }
            return false;
        }

        //public async Task<bool> RejectPurchaseOrder(PurchaseOrderViewModel vm)
        //{
        //    var checkPurchaseOrder = await _dbContext.PurchaseOrder.FirstOrDefaultAsync(c => c.Id == id);
        //    if (checkPurchaseOrder != null || checkPurchaseOrder.OrderStatusId == (int)PurchaseOrderStatusEnum.Draft || checkPurchaseOrder.OrderStatusId == (int)PurchaseOrderStatusEnum.Confirm)
        //    {
        //        checkPurchaseOrder.RejectionCause = 
        //        checkPurchaseOrder.OrderStatusId = (int)PurchaseOrderStatusEnum.Reject;
        //        await _iEntityRepository.UpdateAsync(checkPurchaseOrder);
        //        return true;
        //    }
        //    return false;
        //}
        public async Task<bool> DeletePurchaseOrder(long id)
        {
            var result = await _iEntityRepository.GetByIdAsync(id);
            result.IsActive = false;
            await _iEntityRepository.UpdateAsync(result);
            return true;
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

            var masterIds = purchaseMasterModel.PurchaseOrderList.Select(x => x.Id);

            var matchingDetails = await _dbContext.PurchaseOrderDetail
                .Where(detail => masterIds.Contains(detail.PurchaseOrderId) && detail.IsActive == true)
                .ToListAsync();
            foreach (var master in purchaseMasterModel.PurchaseOrderList)
            {
                var detailsForMaster = matchingDetails.Where(detail => detail.PurchaseOrderId == master.Id);
                decimal? total = detailsForMaster.Sum(detail => (detail.SalePrice * (decimal)detail.PurchaseQty)
                );
                master.TotalAmount = (double)(total ?? 0);
            }
            return purchaseMasterModel;
        }

        public async Task<DataTablePagination<PurchaseOrderSearchDto>> SearchAsync(DataTablePagination<PurchaseOrderSearchDto> searchDto)
        {
            var searchResult = _dbContext.PurchaseOrder.Include(c => c.Storehouse).Include(c => c.Supplier).Where(c => c.IsActive == true && c.PurchaseTypeId == (int)PurchaseTypeEnum.Purchase).AsNoTracking(); ;

            var searchModel = searchDto.SearchVm;
            var filter = searchDto?.Search?.Value?.Trim();

            if (searchModel?.StorehouseId is > 0)
            {
                searchResult = searchResult.Where(c => c.StorehouseId == searchModel.StorehouseId);
            }
            if (searchModel?.SupplierId is > 0)
            {
                searchResult = searchResult.Where(c => c.SupplierId == searchModel.SupplierId);
            }

            if (!string.IsNullOrEmpty(filter))
            {
                filter = filter.ToLower();
                searchResult = searchResult.Where(c =>
                    c.OrderNo.ToLower().Contains(filter)
                    || c.Supplier.Name.ToLower().Contains(filter)
                    || c.Storehouse.Name.ToLower().Contains(filter)
                    );
            }

            var pageSize = searchDto.Length ?? 0;
            var skip = searchDto.Start ?? 0;

            var totalRecords = searchResult.Count();
            if (totalRecords <= 0) return searchDto;

            searchDto.RecordsTotal = totalRecords;
            searchDto.RecordsFiltered = totalRecords;
            List<PurchaseOrder> filteredDataList = await searchResult.OrderByDescending(c => c.Id).Skip(skip).Take(pageSize).ToListAsync();

            var sl = searchDto.Start ?? 0;
            searchDto.Data = filteredDataList.Select(c => new PurchaseOrderSearchDto()
            {
                SerialNo = ++sl,
                Id = c.Id,
                OrderNo = c.OrderNo,
                PurchaseDate = c.PurchaseDate,
                StorehouseId = c.StorehouseId,
                StoreName = c.Storehouse.Name,
                SupplierId = c.SupplierId,
                SupplierName = c.Supplier.Name,
                OrderStatusId = c.OrderStatusId,
                //OrderStatusName = Enum.GetName(typeof(PurchaseOrderStatusEnum), c.OrderStatusId),

                //TotalAmount = (double)c.TotalAmount,
            }).ToList();

            return searchDto;
        }
    }
}
