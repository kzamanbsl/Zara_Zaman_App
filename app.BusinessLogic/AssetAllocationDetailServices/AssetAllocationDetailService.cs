using app.Infrastructure.Auth;
using app.Infrastructure.Repository;
using app.Infrastructure;
using app.Services.AssetPurchaseOrderServices;
using app.Services.AssetAllocationServices;
using Microsoft.EntityFrameworkCore;
using app.EntityModel.AppModels.AssetModels;

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



        //public async Task<bool> AddRecord(AssetAllocationViewModel vm)
        //{
        //    try
        //    {

        //        string tags = "";

        //        foreach (var index in vm.AssetAllocationDetailVm.Tag)
        //        {
        //            tags += index + ", ";
        //        }

        //        AssetAllocationDetail assetAllocationDetail = new AssetAllocationDetail
        //        {

        //            AllocationId = vm.Id,
        //            Id = vm.AssetAllocationDetailVm.Id,
        //            ProductId = vm.AssetAllocationDetailVm.ProductId,
        //            Qty = vm.AssetAllocationDetailVm.Qty,
        //            Description = vm.AssetAllocationDetailVm.Description,
        //            Tags = tags
        //        };

        //        var res = await _iEntityRepository.AddAsync(assetAllocationDetail);
        //        assetAllocationDetail.Id = res?.Id ?? 0;
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }

        //}

        public async Task<bool> AddRecord(AssetAllocationViewModel vm)
        {
            try
            {
                string tags = "";

                foreach (var index in vm.AssetAllocationDetailVm.Tag)
                {
                    tags += index + ", ";
                }


                AssetAllocationDetail assetAllocationDetail = new AssetAllocationDetail
                {
                    AllocationId = vm.Id,
                    Id = vm.AssetAllocationDetailVm.Id,
                    ProductId = vm.AssetAllocationDetailVm.ProductId,
                    Qty = vm.AssetAllocationDetailVm.Qty,
                    //Tags = vm.AssetAllocationDetailVm.Tags,
                    Remarks = vm.AssetAllocationDetailVm.Remarks,
                    Tags = tags
                };

                var res = await _iEntityRepository.AddAsync(assetAllocationDetail);
                assetAllocationDetail.Id = res?.Id ?? 0;
                return true;
            }
            catch (Exception ex)
            {
                // Handle exceptions properly, perhaps log them
                throw;
            }
        }



        public async Task<bool> UpdateAssetAllocationDetail(AssetAllocationViewModel model)
        {

            string tags = "";

            foreach (var index in model.AssetAllocationDetailVm.Tag)
            {
                tags += index + ", ";
            }

            var assetAllocationDetail = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Id == model.AssetAllocationDetailVm.Id);
            if (assetAllocationDetail != null)
            {

                model.Id = assetAllocationDetail.AllocationId;
                assetAllocationDetail.ProductId = model.AssetAllocationDetailVm.ProductId;
                assetAllocationDetail.Qty = model.AssetAllocationDetailVm.Qty;
                //assetAllocationDetail.Tags = model.AssetAllocationDetailVm.Tags;
                assetAllocationDetail.Remarks = model.AssetAllocationDetailVm.Remarks;
                assetAllocationDetail.Tags = tags;
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
                                              AllocationId = t1.AllocationId,
                                              ProductId = t1.ProductId,
                                              ProductName=t1.Product.Name,
                                              Qty= t1.Qty,
                                              Tags = t1.Tags,
                                              Remarks = t1.Remarks,

                                          }).FirstOrDefault());
            return v;
        }

        public async Task<bool> DeleteAssetAllocationDetail(long id)
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
