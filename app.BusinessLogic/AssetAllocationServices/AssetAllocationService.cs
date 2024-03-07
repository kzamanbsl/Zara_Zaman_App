﻿using app.Infrastructure.Auth;
using app.Infrastructure.Repository;
using app.Infrastructure;
using app.Utility;
using app.Services.AssetAllocationDetailServices;
using Microsoft.EntityFrameworkCore;
using app.EntityModel.AppModels;
using app.EntityModel.DataTablePaginationModels;
using app.Services.ProductServices;
using app.Services.AssetAllocationServices;
using app.Services.SalesOrderServices;
using app.Services.AssetPurchaseOrderServices;

namespace app.Services.AssetAllocationServices
{
    public class AssetAllocationService : IAssetAllocationService
    {
        private readonly IEntityRepository<AssetAllocation> _iEntityRepository;
        private readonly InventoryDbContext _dbContext;
        private readonly IWorkContext _iWorkContext;
        public AssetAllocationService(IEntityRepository<AssetAllocation> iEntityRepository, InventoryDbContext dbContext, IWorkContext iWorkContext)
        {
            _iEntityRepository = iEntityRepository;
            _dbContext = dbContext;
            _iWorkContext = iWorkContext;
        }
        public async Task<bool> AddRecord(AssetAllocationViewModel vm)
        {

            if (vm.AssetAllocationStatusId == 0)
            {
                vm.AssetAllocationStatusId = (int)AasetAllocationStatusEnum.Draft;
            }

            var poMax = _dbContext.AssetAllocation.Count() + 1;
            string poCid = @"ALNO" +
                           DateTime.Now.ToString("yy") +
                           DateTime.Now.ToString("MM") +
                           DateTime.Now.ToString("dd") + "-" +
                           poMax.ToString().PadLeft(2, '0');

            AssetAllocation assetAllocation =new AssetAllocation();
            assetAllocation.OrderNo = poCid;
            assetAllocation.EmployeeId = vm.EmployeeId;
            assetAllocation.DepartmentId = vm.DepartmentId;
            assetAllocation.Date = vm.Date;
            assetAllocation.Remarks = vm.Remarks;
            assetAllocation.AssetAllocationStatusId = (int)AasetAllocationStatusEnum.Draft;
            var res = await _iEntityRepository.AddAsync(assetAllocation);
            vm.Id = res?.Id ?? 0;
            return true;
        }
        public async Task<bool> UpdateAssetAllocation(AssetAllocationViewModel vm)
        {
            var assetAllocation = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Id == vm.Id);
            if (assetAllocation != null)
            {
                assetAllocation.Id = vm.Id;
                assetAllocation.OrderNo = vm.OrderNo;
                assetAllocation.AssetAllocationStatusId = vm.AssetAllocationStatusId;
                assetAllocation.EmployeeId = vm.EmployeeId;
                assetAllocation.DepartmentId = vm.DepartmentId;
                assetAllocation.Date = vm.Date;
                assetAllocation.Remarks = vm.Remarks;
                await _iEntityRepository.UpdateAsync(assetAllocation);
                return true;
            }
            return false;
        }
        public async Task<AssetAllocationViewModel> GetAssetAllocation(long assetAllocationId = 0)
        {
            AssetAllocationViewModel assetAllocationModel = new AssetAllocationViewModel();
            assetAllocationModel = await Task.Run(() => (from t1 in _dbContext.AssetAllocation.Where(x => x.IsActive && x.Id == assetAllocationId)
                                                         select new AssetAllocationViewModel
                                                         {
                                                             Id = t1.Id,
                                                             OrderNo= t1.OrderNo,
                                                             AssetAllocationStatusId = (int)(AasetAllocationStatusEnum)t1.AssetAllocationStatusId,
                                                             EmployeeId = t1.EmployeeId,
                                                             EmployeeName= t1.Employee.Name,
                                                             DepartmentId = t1.DepartmentId,
                                                             DepartmentName= t1.Department.Name,
                                                             Date = t1.Date,
                                                             //Quantity = t1.Quantity,
                                                             Remarks = t1.Remarks,
                                                         }).FirstOrDefault()); ;

            assetAllocationModel.AssetAllocationDetailsList = await Task.Run(() => (from t1 in _dbContext.AssetAllocationDetail.Where(x => x.IsActive && x.AssetAllocation.Id == assetAllocationId)
                                                                                    select new AssetAllocationDetailViewModel
                                                                                    {
                                                                                        Id = t1.Id,
                                                                                        AssetAllocationId = t1.AssetAllocationId,                                                               ProductId= t1.ProductId,
                                                                                        ProductName= t1.Product.Name,
                                                                                        Quantity = t1.Quantity,
                                                                                        Tags = t1.Tags,
                                                                                        Description = t1.Description,
                                                                                    }).OrderByDescending(x => x.Id).AsEnumerable());


            return assetAllocationModel;
        }
        public async Task<AssetAllocationViewModel> GetAssetAllocationDetails(long id = 0)
        {
            AssetAllocationViewModel assetAllocationModel = new AssetAllocationViewModel();
            assetAllocationModel = await Task.Run(() => (from t1 in _dbContext.AssetAllocation.Where(x => x.IsActive && x.Id == id)
                                                         select new AssetAllocationViewModel
                                                         {
                                                             Id = t1.Id,
                                                             OrderNo = t1.OrderNo,
                                                             AssetAllocationStatusId = (int)(AasetAllocationStatusEnum)t1.AssetAllocationStatusId,
                                                             EmployeeId = t1.EmployeeId,
                                                             EmployeeName = t1.Employee.Name,
                                                             Date = t1.Date,
                                                             Remarks = t1.Remarks,
                                                         }).FirstOrDefault());

            assetAllocationModel.AssetAllocationDetailsList = await Task.Run(() => (from t1 in _dbContext.AssetAllocationDetail.Where(x => x.IsActive && x.AssetAllocation.Id == id)
                                                                                    select new AssetAllocationDetailViewModel
                                                                                    {
                                                                                        Id = t1.Id,
                                                                                        AssetAllocationId = t1.AssetAllocationId,
                                                                                        ProductId = t1.ProductId,
                                                                                        ProductName = t1.Product.Name,
                                                                                        Quantity = t1.Quantity,
                                                                                        Tags = t1.Tags,
                                                                                        Description = t1.Description,

                                                                                    }).OrderByDescending(x => x.Id).AsEnumerable());


            return assetAllocationModel;
        }
        public async Task<AssetAllocationViewModel> AssetAllocationById(long id)
        {
            AssetAllocationViewModel sendData = new AssetAllocationViewModel();
            var result = await _dbContext.AssetAllocation.FirstOrDefaultAsync(x => x.Id == id);
            sendData.Id = result.Id;
            sendData.OrderNo = result.OrderNo;
            sendData.EmployeeId = result.EmployeeId;
            sendData.DepartmentId = result.DepartmentId;
            sendData.AssetAllocationStatusId = result.AssetAllocationStatusId;
            sendData.Date = result.Date;
            sendData.Remarks = result.Remarks;

            return sendData;
        }
        public async Task<bool> ConfirmAssetAllocation(long id)
        {
            var checkAssetAllocation = await _dbContext.AssetAllocation.FirstOrDefaultAsync(c => c.Id == id);
            if (checkAssetAllocation != null && checkAssetAllocation.Id == id)
            {
                checkAssetAllocation.AssetAllocationStatusId = (int)AasetAllocationStatusEnum.Confirm;
                await _iEntityRepository.UpdateAsync(checkAssetAllocation);
                return true;
            }
            return false;
        }
        public async Task<bool> RejectAssetAllocation(long id)
        {
            var checkAssetAllocation = await _dbContext.AssetAllocation.FirstOrDefaultAsync(c => c.Id == id);

            if (checkAssetAllocation != null || checkAssetAllocation.AssetAllocationStatusId == (int)AasetAllocationStatusEnum.Draft || checkAssetAllocation.AssetAllocationStatusId == (int)AasetAllocationStatusEnum.Confirm)
            {
                checkAssetAllocation.AssetAllocationStatusId = (int)AasetAllocationStatusEnum.Reject;
                await _iEntityRepository.UpdateAsync(checkAssetAllocation);
                return true;
            }
            return false;

        }
        public async Task<bool> DeleteAssetAllocation(long id)
        {
            var result = await _iEntityRepository.GetByIdAsync(id);
            result.IsActive = false;
            await _iEntityRepository.UpdateAsync(result);
            return true;
        }
        public async Task<AssetAllocationViewModel> GetAllRecord()
        {
            AssetAllocationViewModel assetAllocationMasterModel = new AssetAllocationViewModel();
            var dataQuery = await Task.Run(() => (from t1 in _dbContext.AssetAllocation
                                                  where t1.IsActive == true && t1.AssetAllocationStatusId == (int)AasetAllocationStatusEnum.Draft

                                                  select new AssetAllocationViewModel
                                                  {
                                                      Id = t1.Id,
                                                      OrderNo = t1.OrderNo,
                                                      AssetAllocationStatusId = (int)(AasetAllocationStatusEnum)t1.AssetAllocationStatusId,
                                                      EmployeeId = t1.EmployeeId,
                                                      EmployeeName = t1.Employee.Name,
                                                      DepartmentId = t1.DepartmentId,
                                                      DepartmentName = t1.Department.Name,
                                                      Date = t1.Date,
                                                      Remarks = t1.Remarks,

                                                  }).OrderByDescending(x => x.Id).AsQueryable());

            assetAllocationMasterModel.AssetAllocationList = await Task.Run(() => dataQuery.ToList());
            assetAllocationMasterModel.AssetAllocationList.ToList().ForEach((c => c.AssetAllocationStatusName = Enum.GetName(typeof(AasetAllocationStatusEnum), c.AssetAllocationStatusId)));


            //var masterIds = assetAllocationMasterModel.AssetAllocationList.Select(x => x.Id);

            //var matchingDetails = await _dbContext.AssetAllocationDetail
            //    .Where(detail => masterIds.Contains(detail.AssetAllocationStatusId) && detail.IsActive == true)
            //    .ToListAsync();
            //foreach (var master in assetAllocationMasterModel.AssetAllocationList)
            //{
            //    var detailsForMaster = matchingDetails.Where(detail => detail.AssetAllocationStatusId == master.Id);
            //    decimal? total = detailsForMaster.Sum(detail => (detail.CostPrice * (decimal)detail.PurchaseQty)
            //    );
            //    //master.TotalAmount = (double)(total ?? 0);
            //}
            return assetAllocationMasterModel;
        }
     
        //public async Task<DataTablePagination<AssetAllocationSearchDto>> SearchAsync(DataTablePagination<AssetAllocationSearchDto> searchDto)
        //{
        //    var searchResult = _dbContext.AssetAllocationDetail.Include(c => c.AssetAllocation.Storehouse).Include(c => c.AssetAllocation.Supplier).Where(c => c.IsActive == true).AsNoTracking();

        //    var searchModel = searchDto.SearchVm;
        //    var filter = searchDto?.Search?.Value?.Trim();
        //    if (searchModel?.StorehouseId is > 0)
        //    {
        //        searchResult = searchResult.Where(c => c.AssetAllocation.StorehouseId == searchModel.StorehouseId);
        //    }
        //    if (searchModel?.SupplierId is > 0)
        //    {
        //        searchResult = searchResult.Where(c => c.AssetAllocation.SupplierId == searchModel.SupplierId);
        //    }
        //    if (!string.IsNullOrEmpty(filter))
        //    {
        //        filter = filter.ToLower();
        //        searchResult = searchResult.Where(c =>
        //            c.AssetAllocation.OrderNo.ToString().Contains(filter)
        //            || c.AssetAllocation.PurchaseDate.ToString().Contains(filter)
        //            || c.AssetAllocation.Supplier.Name.ToLower().Contains(filter)
        //            || c.AssetAllocation.Storehouse.Name.ToLower().Contains(filter)
        //        );
        //    }

        //    var pageSize = searchDto.Length ?? 0;
        //    var skip = searchDto.Start ?? 0;

        //    var totalRecords = searchResult.Count();
        //    if (totalRecords <= 0) return searchDto;

        //    searchDto.RecordsTotal = totalRecords;
        //    searchDto.RecordsFiltered = totalRecords;
        //    List<AssetAllocationDetail> filteredDataList = await searchResult.OrderByDescending(c => c.Id).Skip(skip).Take(pageSize).ToListAsync();

        //    var sl = searchDto.Start ?? 0;
        //    searchDto.Data = filteredDataList.Select(c => new AssetAllocationSearchDto()
        //    {
        //        SerialNo = ++sl,
        //        Id = c.AssetAllocation.Id,
        //        OrderNo = c.AssetAllocation.OrderNo,
        //        PurchaseDate = c.AssetAllocation.PurchaseDate,
        //        StorehouseId = c.AssetAllocation.StorehouseId,
        //        Storehouse = c.AssetAllocation.Storehouse,
        //        OrderStatusId = (int)(AssetAllocationStatusEnum)c.AssetAllocation.OrderStatusId,
        //        SupplierId = c.AssetAllocation.SupplierId,
        //        Supplier = c.AssetAllocation.Supplier,
        //        TotalAmount = (double)c.TotalAmount,
        //    }).ToList();

        //    return searchDto;
        //}
    }
}