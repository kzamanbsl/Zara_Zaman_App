using app.EntityModel.AppModels.ProductModels;
using app.EntityModel.DataTablePaginationModels;
using app.Infrastructure.Auth;
using app.Infrastructure.Repository;
using app.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using app.EntityModel.AppModels.AssetModels;
using app.EntityModel.AppModels.PurchaseModels;
using app.Utility;
using Microsoft.EntityFrameworkCore;
using app.Services.AssetPurchaseOrderServices;

namespace app.Services.AssetTransferServices
{
    public class AssetTransferService : IAssetTransferService
    {

        private readonly IEntityRepository<AssetTransfer> _iEntityRepository;
        private readonly InventoryDbContext _dbContext;
        private readonly IWorkContext _iWorkContext;
        public AssetTransferService(IEntityRepository<AssetTransfer> iEntityRepository, InventoryDbContext dbContext, IWorkContext iWorkContext)
        {
            _iEntityRepository = iEntityRepository;
            _dbContext = dbContext;
            _iWorkContext = iWorkContext;
        }
       
        public async Task<bool> AddRecord(AssetTransferViewModel vm)
        {
            if (vm.StatusId == 0)
            {
                vm.StatusId = (int)AssetTransferStatusEnum.Draft;
            }

            var atMax = _dbContext.AssetTransfer.Count() + 1;
            string atCid = @"ATN-" +
                           DateTime.Now.ToString("yy") +
                           DateTime.Now.ToString("MM") +
                           DateTime.Now.ToString("dd") + "-" +
                           atMax.ToString().PadLeft(2, '0');

            AssetTransfer assetTransfer = new AssetTransfer()
            {
                TransferNo = atCid,
                Date = vm.Date,
                FromStoreId = vm.FromStoreId,
                ToStoreId = vm.ToStoreId,
                Description = vm.Description,
                StatusId = vm.StatusId
            };

            var res = await _iEntityRepository.AddAsync(assetTransfer);
            vm.Detail.TransferId = res?.Id ?? 0;
            vm.Id = res?.Id ?? 0;
            return true;
        }

        public async Task<bool> DeleteRecord(long id)
        {

            var result = await _iEntityRepository.GetByIdAsync(id);
            result.IsActive = false;
            await _iEntityRepository.UpdateAsync(result);
            return true;
        }

        public async Task<List<AssetTransferViewModel>> GetAllRecord()
        {
            var data = await _dbContext.AssetTransfer.AsNoTracking().AsQueryable()
                      .Where(c => c.IsActive)
                      .Select(c => new AssetTransferViewModel()
                      {
                          TransferNo = c.TransferNo,
                          FromStoreId = c.FromStoreId,
                          ToStoreId = c.ToStoreId,
                          StatusId = c.StatusId

                      }).ToListAsync();

            return data;
        }

        public async Task<AssetTransferViewModel> GetRecordById(long id)
        {
            var data = await _dbContext.AssetTransfer.AsNoTracking().AsQueryable()
                    .Where(c => c.IsActive && c.Id.Equals(id))
                    .Select(c => new AssetTransferViewModel()
                    {
                        TransferNo = c.TransferNo,
                        FromStoreId = c.FromStoreId,
                        ToStoreId = c.ToStoreId,
                        StatusId = c.StatusId
                    }).FirstOrDefaultAsync();
            return data;
        }

        public async Task<DataTablePagination<AssetTransferSearchDto>> SearchAsync(DataTablePagination<AssetTransferSearchDto> searchDto)
        {
            var searchResult = _dbContext.AssetTransfer.Include(c => c.FromStore).Include(c => c.ToStore).Where(c => c.IsActive == true).AsNoTracking(); ;

            var searchModel = searchDto.SearchVm;
            var filter = searchDto?.Search?.Value?.Trim();

            //if (searchModel?.FromStoreId is > 0)
            //{
            //    searchResult = searchResult.Where(c => c.FromStoreId == searchModel.FromStoreId);
            //}
            //if (searchModel?.SupplierId is > 0)
            //{
            //    searchResult = searchResult.Where(c => c.SupplierId == searchModel.SupplierId);
            //}

            //if (searchModel?.OrderStatusId is > 0)
            //{
            //    searchResult = searchResult.Where(c => c.OrderStatusId == searchModel.OrderStatusId);
            //}

            if (!string.IsNullOrEmpty(filter))
            {
                filter = filter.ToLower();
                searchResult = searchResult.Where(c =>
                    c.TransferNo.ToLower().Contains(filter)
                    || c.FromStore.Name.ToLower().Contains(filter)
                    || c.ToStore.Name.ToLower().Contains(filter)
                );
            }

            var pageSize = searchDto.Length ?? 0;
            var skip = searchDto.Start ?? 0;

            var totalRecords = searchResult.Count();
            if (totalRecords <= 0) return searchDto;

            searchDto.RecordsTotal = totalRecords;
            searchDto.RecordsFiltered = totalRecords;
            List<AssetTransfer> filteredDataList = await searchResult.OrderByDescending(c => c.Id).Skip(skip).Take(pageSize).ToListAsync();

            var sl = searchDto.Start ?? 0;
            searchDto.Data = filteredDataList.Select(c => new AssetTransferSearchDto()
            {
                SerialNo = ++sl,
                Id = c.Id,
                TransferNo = c.TransferNo,
                Date = c.Date,
                FromStoreId = c.FromStoreId,
                FromStoreName = c.FromStore?.Name,
                ToStoreId = c.ToStoreId,
                ToStoreName = c.ToStore?.Name,
                StatusId = c.StatusId

            }).ToList();

            return searchDto;
        }

        public async Task<bool> UpdateRecord(AssetTransferViewModel vm)
        {
            var assetTransfer = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Id == vm.Id);
            if (assetTransfer == null) return false;

            assetTransfer.Date = vm.Date;
            assetTransfer.FromStoreId = vm.FromStoreId;
            assetTransfer.ToStoreId = vm.ToStoreId;
            var res = await _iEntityRepository.UpdateAsync(assetTransfer);
            return true;

           
        }
    }
}
