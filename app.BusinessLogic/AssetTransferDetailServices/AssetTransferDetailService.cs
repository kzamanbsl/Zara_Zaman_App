using app.EntityModel.AppModels.AssetModels;
using app.Infrastructure.Auth;
using app.Infrastructure.Repository;
using app.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Services.AssetTransferDetailServices
{
    public class AssetTransferDetailService : IAssetTransferDetailService
    {
        private readonly IEntityRepository<AssetTransferDetail> _iEntityRepository;
        private readonly InventoryDbContext _dbContext;
        private readonly IWorkContext _iWorkContext;
        public AssetTransferDetailService(IEntityRepository<AssetTransferDetail> iEntityRepository, InventoryDbContext dbContext, IWorkContext iWorkContext)
        {
            _iEntityRepository = iEntityRepository;
            _dbContext = dbContext;
            _iWorkContext = iWorkContext;
        }
        public async Task<bool> AddRecord(AssetTransferDetailViewModel vm)
        {
            var assetTransferDetail = new AssetTransferDetail()
            {
                TransferId=vm.TransferId,
                ProductId=vm.ProductId,
                Qty=vm.Qty,
                Remarks=vm.Remarks

            };

            var res = await _iEntityRepository.AddAsync(assetTransferDetail);
            vm.Id = res?.Id ?? 0;
            return true;
        }

        public Task<bool> DeleteRecord(long id)
        {
            throw new NotImplementedException();
        }

        public Task<AssetTransferDetailViewModel> GetRecordById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateRecord(AssetTransferDetailViewModel vm)
        {
            throw new NotImplementedException();
        }
    }
}
