using app.EntityModel.AppModels;
using app.Infrastructure.Auth;
using app.Infrastructure.Repository;
using app.Infrastructure;
using app.Services.AssetPurchaseOrderServices;
using app.Services.AssetAllocationServices;
using Microsoft.EntityFrameworkCore;

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

        //        foreach (var index in vm.AssetAllocationDetailVM.Tag)
        //        {
        //            tags += index + ", ";
        //        }

        //        AssetAllocationDetail assetAllocationDetail = new AssetAllocationDetail
        //        {

        //            AssetAllocationId = vm.Id,
        //            Id = vm.AssetAllocationDetailVM.Id,
        //            ProductId = vm.AssetAllocationDetailVM.ProductId,
        //            Quantity = vm.AssetAllocationDetailVM.Quantity,
        //            Description = vm.AssetAllocationDetailVM.Description,
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

                foreach (var index in vm.AssetAllocationDetailVM.Tag)
                {
                    tags += index + ", ";
                }


                AssetAllocationDetail assetAllocationDetail = new AssetAllocationDetail
                {
                    AssetAllocationId = vm.Id,
                    Id = vm.AssetAllocationDetailVM.Id,
                    ProductId = vm.AssetAllocationDetailVM.ProductId,
                    Quantity = vm.AssetAllocationDetailVM.Quantity,
                    Description = vm.AssetAllocationDetailVM.Description,
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

            foreach (var index in model.AssetAllocationDetailVM.Tag)
            {
                tags += index + ", ";
            }
          
            var assetAllocationDetail = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Id == model.AssetAllocationDetailVM.Id);
            if (assetAllocationDetail != null)
            {

                model.Id = assetAllocationDetail.AssetAllocationId;
                assetAllocationDetail.ProductId = model.AssetAllocationDetailVM.ProductId;
                assetAllocationDetail.Quantity = model.AssetAllocationDetailVM.Quantity;
                //assetAllocationDetail.Tags = model.AssetAllocationDetailVM.Tags;
                assetAllocationDetail.Description = model.AssetAllocationDetailVM.Description;
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
                                              AssetAllocationId = t1.AssetAllocationId,
                                              ProductId = t1.ProductId,
                                              ProductName=t1.Product.Name,
                                              Quantity= t1.Quantity,
                                              Tags = t1.Tags,
                                              Description = t1.Description,

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
