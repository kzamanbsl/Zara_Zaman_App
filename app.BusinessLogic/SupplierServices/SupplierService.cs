using app.EntityModel.AppModels;
using app.EntityModel.DataTablePaginationModels;
using app.Infrastructure;
using app.Infrastructure.Auth;
using app.Infrastructure.Repository;
using app.Services.ProductServices;
using app.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace app.Services.SupplierServices
{
    public class SupplierService : ISupplierService
    {
        private readonly IEntityRepository<Supplier> _iEntityRepository;
        private readonly InventoryDbContext _dbContext;
        private readonly IWorkContext _iWorkContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public SupplierService(IEntityRepository<Supplier> iEntityRepository, InventoryDbContext dbContext, IWorkContext iWorkContext, IHttpContextAccessor httpContextAccessor)
        {
            _iEntityRepository = iEntityRepository;
            _dbContext = dbContext;
            _iWorkContext = iWorkContext;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> AddRecord(SupplierViewModel vm)
        {
            try
            {
                var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Name.Trim() == vm.Name.Trim() && f.IsActive == true);
                if (checkName == null)
                {
                    Supplier model = new Supplier();
                    model.Name = vm.Name;
                    model.Phone = vm.Phone;
                    model.Email = vm.Email;
                    model.Description = vm.Description;
                    model.Address = vm.Address;
                    model.BankName = vm.BankName;
                    model.BranchName = vm.BranchName;
                    model.BankAccountNo = vm.BankAccountNo;
                    //model.CountryId = vm.CountryId;
                    //model.DivisionId = vm.DivisionId;
                    //model.DistrictId = vm.DistrictId;
                    //model.UpazilaId = vm.UpazilaId;
                    model.CreatedBy = _httpContextAccessor.HttpContext.User.Identity.Name;
                    model.CreatedOn = DateTime.Now;
                    model.IsActive = true;
                    var res = await _iEntityRepository.AddAsync(model);
                    if (res != null)
                    {
                        vm.Id = res.Id;
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception es)
            {

                throw;
            }

            return false;
        }

        public async Task<bool> UpdateRecord(SupplierViewModel vm)
        {
            var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Name.Trim() == vm.Name.Trim() && f.Id != vm.Id && f.IsActive == true);
            if (checkName == null)
            {
                var result = await _iEntityRepository.GetByIdAsync(vm.Id);
                result.Name = vm.Name;
                result.Phone = vm.Phone;
                result.Email = vm.Email;
                result.Description = vm.Description;
                result.Address = vm.Address;
                result.BankAccountNo = vm.BankAccountNo;
                result.BankName = vm.BankName;
                result.BranchName = vm.BranchName;
                //result.CountryId = vm.CountryId;
                //result.DivisionId = vm.DivisionId;
                //result.DistrictId = vm.DistrictId;
                //result.UpazilaId = vm.UpazilaId;
                result.UpdatedBy = _httpContextAccessor.HttpContext.User.Identity.Name;
                result.UpdatedOn = DateTime.Now;
                var res = await _iEntityRepository.UpdateAsync(result);

                return true;
            }
            return false;
        }

        public async Task<SupplierViewModel> GetRecordById(long id)
        {
            var result = await _iEntityRepository.GetByIdAsync(id);
            SupplierViewModel model = new SupplierViewModel();
            model.Id = result.Id;
            model.Name = result.Name;
            model.Phone = result.Phone;
            model.Email = result.Email;
            model.Description = result.Description;
            model.Address = result.Address;
            model.BankAccountNo = result.BankAccountNo;
            model.BankName = result.BankName;
            model.BranchName = result.BranchName;
            //model.CountryId = result.CountryId;
            //model.DivisionId = result.DivisionId;
            //model.DistrictId = result.DistrictId;
            //model.UpazilaId = result.UpazilaId;
            return model;
        }
       
        public async Task<bool> DeleteRecord(long id)
        {
            var result = await _iEntityRepository.GetByIdAsync(id);
            result.IsActive = false;
            await _iEntityRepository.UpdateAsync(result);
            return true;
        }

        public async Task<SupplierViewModel> GetAllRecord()
        {
            SupplierViewModel model = new SupplierViewModel();
            model.SupplierList = await Task.Run(() => (from t1 in _dbContext.Supplier
                                                       where t1.IsActive == true
                                                       select new SupplierViewModel
                                                       {
                                                           Id = t1.Id,
                                                           Name = t1.Name,
                                                           Phone = t1.Phone,
                                                           Email = t1.Email,
                                                           Description = t1.Description,
                                                           Address = t1.Address,
                                                           BankName = t1.BankName,
                                                           BranchName = t1.BranchName,
                                                           BankAccountNo = t1.BankAccountNo,
                                                           //CountryId = t1.CountryId,
                                                           //CountryName = t1.Country.Name,
                                                           //DivisionId = t1.DivisionId,
                                                           //DivisionName = t1.Division.Name,
                                                           //DistrictId = t1.DistrictId,
                                                           //DistrictName = t1.District.Name,
                                                           //UpazilaId = t1.UpazilaId,
                                                           //UpazilaName = t1.Upazila.Name,
                                                       }).AsEnumerable());
            return model;
        }

        public async Task<DataTablePagination<SupplierSearchDto>> SearchAsync(DataTablePagination<SupplierSearchDto> searchDto)
        {
            var searchResult = _dbContext.Supplier.Where(c=>c.IsActive==true).AsNoTracking();

            var searchModel = searchDto.SearchVm;
            var filter = searchDto?.Search?.Value?.Trim();
            //if (searchModel?.CountryId is > 0)
            //{
            //    searchResult = searchResult.Where(c => c.CountryId == searchModel.CountryId);
            //}
            //if (searchModel?.DivisionId is > 0)
            //{
            //    searchResult = searchResult.Where(c => c.DivisionId == searchModel.DivisionId);
            //}
            //if (searchModel?.DistrictId is > 0)
            //{
            //    searchResult = searchResult.Where(c => c.DistrictId == searchModel.DistrictId);
            //}
            //if (searchModel?.UpazilaId is > 0)
            //{
            //    searchResult = searchResult.Where(c => c.UpazilaId == searchModel.UpazilaId);
            //}
            if (!string.IsNullOrEmpty(filter))
            {
                filter = filter.ToLower();
                searchResult = searchResult.Where(c =>
                    c.Name.ToLower().Contains(filter)
                    ||c.Phone.ToString().Contains(filter)
                    || c.Address.ToLower().Contains(filter)
                    || c.BankName.ToLower().Contains(filter)
                    || c.BranchName.ToLower().Contains(filter)
                    || c.Email.ToLower().Contains(filter)
                    || c.Description.ToLower().Contains(filter)
                    || c.Address.ToLower().Contains(filter)
                );
            }

            var pageSize = searchDto.Length ?? 0;
            var skip = searchDto.Start ?? 0;

            var totalRecords = searchResult.Count();
            if (totalRecords <= 0) return searchDto;

            searchDto.RecordsTotal = totalRecords;
            searchDto.RecordsFiltered = totalRecords;
            List<Supplier> filteredDataList = await searchResult.OrderByDescending(c => c.Id).Skip(skip).Take(pageSize).ToListAsync();

            var sl = searchDto.Start ?? 0;
            searchDto.Data = filteredDataList.Select(c => new SupplierSearchDto()
            {
                SerialNo = ++sl,
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
                Phone = c.Phone,
                Email = c.Email,
                BankName = c.BankName,
                BranchName = c.BranchName,
                BankAccountNo = c.BankAccountNo,
               
                Address = c.Address,
            }).ToList();

            return searchDto;
        }
    }
}
