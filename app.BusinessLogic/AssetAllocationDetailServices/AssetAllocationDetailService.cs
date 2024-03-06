using app.EntityModel.AppModels;
using app.Infrastructure.Auth;
using app.Infrastructure.Repository;
using app.Infrastructure;
using app.Services.AssetPurchaseOrderServices;
using app.Services.AssetAllocationServices;

namespace app.Services.AssetAllocationDetailServices
{

    public class AssetAllocationDetailService : IAssetAllocationDetailService
    {
        private readonly IEntityRepository<AssetAllocationDetail> _iEntityRepository;
        private readonly InventoryDbContext _dbContext;
        public AssetAllocationDetailService(IEntityRepository<AssetAllocationDetail> iEntityRepository, InventoryDbContext dbContext, IWorkContext iWorkContext)
        {
            _iEntityRepository = iEntityRepository;
            _dbContext = dbContext;
        }
        public async Task<bool> AddRecord(AssetAllocationDetailViewModel vm)
        {
            try
            {
                AssetAllocationDetail assetAllocationDetail = new AssetAllocationDetail
                {

                    AssetAllocationId = vm.Id,
                    Id = vm.AssetAllocationVM.Id,
                    EmployeeId = vm.EmployeeId,
                    DepartmentId = vm.DepartmentId,
                    Date = vm.Date,
                    Description = vm.Description,

                    //PurchaseQty = vm.AssetAllocationDetailVM.PurchaseQty,
                    //Consumption = vm.AssetAllocationDetailVM.Consumption,
                    //UnitId = vm.AssetAllocationDetailVM.UnitId,
                    //CostPrice = vm.AssetAllocationDetailVM.CostPrice,
                    //SalePrice = vm.AssetAllocationDetailVM.SalePrice,
                    //Discount = vm.AssetAllocationDetailVM.Discount,
                    //TotalAmount = (vm.AssetAllocationDetailVM.CostPrice * (decimal)vm.AssetAllocationDetailVM.PurchaseQty) - vm.AssetAllocationDetailVM.Discount,
                    //Remarks = vm.AssetAllocationDetailVM.Remarks
                };

                var res = await _iEntityRepository.AddAsync(assetAllocationDetail);
                assetAllocationDetail.Id = res?.Id ?? 0;
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public async Task<bool> UpdateAssetAllocationDetail(AssetAllocationViewModel model)
        {
            var assetAllocationDetail = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Id == model.AssetAllocationDetailVM.Id);
            if (assetAllocationDetail != null)
            {
                model.Id = assetAllocationDetail.AssetAllocationId;
                assetAllocationDetail.ProductId = model.AssetAllocationDetailVM.ProductId;



                model.ProductId = ;
                model.DepartmentId = assetAllocationDetail.DepartmentId;
                model.Date = assetAllocationDetail.Date;
                model.Description = assetAllocationDetail.Description;

                //assetAssetAllocationDetail.ProductId = model.AssetAllocationDetailVM.ProductId;
                //assetAssetAllocationDetail.UnitId = model.AssetAllocationDetailVM.UnitId;
                //assetAssetAllocationDetail.Consumption = model.AssetAllocationDetailVM.Consumption;
                //assetAssetAllocationDetail.Discount = model.AssetAllocationDetailVM.Discount;
                //assetAssetAllocationDetail.PurchaseQty = model.AssetAllocationDetailVM.PurchaseQty;
                //assetAssetAllocationDetail.SalePrice = model.AssetAllocationDetailVM.SalePrice;
                //assetAssetAllocationDetail.CostPrice = model.AssetAllocationDetailVM.CostPrice;
                //assetAssetAllocationDetail.TotalAmount = ((decimal)model.AssetAllocationDetailVM.PurchaseQty * model.AssetAllocationDetailVM.CostPrice) - model.AssetAllocationDetailVM.Discount;
                //assetAssetAllocationDetail.Remarks = model.AssetAllocationDetailVM.Remarks;
                await _iEntityRepository.UpdateAsync(assetAllocationDetail);
                return true;
            }
            return false;
        }

        public async Task<AssetAllocationDetailViewModel> SingleAssetAllocationDetails(long id)
        {
            var v = await Task.Run(() => (from t1 in _dbContext.AssetAllocationDetail.Where(x => x.IsActive && x.Id == id)

                                          select new AssetAllocationDetailViewModel
                                          {
                                              Id = t1.Id,
                                              AssetAllocationId = t1.AssetAllocationId,
                                              EmployeeId = t1.EmployeeId,
                                              EmployeeName = t1.Employee.Name,
                                              DepartmentId = t1.DepartmentId,
                                              DepartmentName = t1.Department.Name,
                                              Date = t1.Date,
                                              Description = t1.Description,

                                              //PurchaseOrderId = t1.PurchaseOrderId,
                                              //ProductId = t1.ProductId,
                                              //ProductName = t1.Product.Name,
                                              //PurchaseQty = t1.PurchaseQty,
                                              //Consumption = t1.Consumption,
                                              //UnitId = t1.UnitId,
                                              //UnitName = t1.Unit.Name,
                                              //CostPrice = t1.CostPrice,
                                              //SalePrice = t1.SalePrice,
                                              //Discount = t1.Discount,
                                              //TotalAmount = ((decimal)t1.AllocationQty * t1.CostPrice) - t1.Discount,
                                              //Remarks = t1.Remarks,

                                          }).FirstOrDefault());
            return v;
        }

        public async Task<bool> DeleteAssetPurchaseDetail(long id)
        {

            AssetAllocationDetail assetPurchaseDetails = await _dbContext.AssetAllocationDetail.FindAsync(id);
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
