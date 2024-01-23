using app.EntityModel.AppModels;
using app.Infrastructure;
using app.Infrastructure.Auth;
using app.Infrastructure.Repository;
using app.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

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
            //var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Name.Trim() == vm.Name.Trim());
            var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Name.Trim() == vm.Name.Trim() && f.IsActive == true);
            if (checkName == null)
            {
                Supplier model = new Supplier();
                model.Name=vm.Name;
                model.Phone=vm.Phone;
                model.Email=vm.Email;
                model.Description=vm.Description;
                model.Address=vm.Address;
                model.CountryId=vm.CountryId;
                model.DivisionId=vm.DivisionId;
                model.DistrictId=vm.DistrictId;
                model.UpazilaId=vm.UpazilaId;
                model.CreatedBy = _httpContextAccessor.HttpContext.User.Identity.Name;
                model.CreatedOn = DateTime.Now;
                model.IsActive = true;
                var res = await _iEntityRepository.AddAsync(model);
                if(res != null)
                {
                    vm.Id = res.Id;
                    return true;
                }
                return false;
            }

            return false;
        }
        public async Task<bool> UpdateRecord(SupplierViewModel vm)
        {
            //var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Name.Trim() == vm.Name.Trim());
            var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Name.Trim() == vm.Name.Trim() && f.Id != vm.Id && f.IsActive == true);
            if (checkName == null)
            {
                var result = await _iEntityRepository.GetByIdAsync(vm.Id);
                result.Name = vm.Name;
                result.Phone = vm.Phone;
                result.Email = vm.Email;
                result.Description = vm.Description;
                result.Address = vm.Address;
                result.CountryId = vm.CountryId;
                result.DivisionId = vm.DivisionId;
                result.DistrictId = vm.DistrictId;
                result.UpazilaId = vm.UpazilaId;
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
            //model.LeaveCategoryId = result.LeaveCategoryId;
            //model.LeaveQty = result.LeaveQty;
            model.Name = result.Name;
            model.Phone = result.Phone;
            model.Email = result.Email;
            model.Description = result.Description;
            model.Address = result.Address;
            model.CountryId = result.CountryId;
            model.DivisionId = result.DivisionId;
            model.DistrictId = result.DistrictId;
            model.UpazilaId = result.UpazilaId;
            return model;
        }
        public async Task<SupplierViewModel> GetAllRecord()
        {
            SupplierViewModel model = new SupplierViewModel();
            model.SupplierList = await Task.Run(() => (from t1 in _dbContext.Supplier
                                                                where t1.IsActive == true
                                                                select new SupplierViewModel
                                                                {
                                                                    Id = t1.Id,
                                                                    Name=t1.Name,
                                                                    Phone= t1.Phone,
                                                                    Email = t1.Email,
                                                                    Description=t1.Description,
                                                                    Address=t1.Address,
                                                                    CountryId=t1.CountryId,
                                                                    CountryName=t1.Country.Name,
                                                                    DivisionId=t1.DivisionId,
                                                                    DivisionName=t1.Division.Name,
                                                                    DistrictId=t1.DistrictId,
                                                                    DistrictName=t1.District.Name,
                                                                    UpazilaId=t1.UpazilaId,
                                                                    UpazilaName=t1.Upazila.Name,
                                                                }).AsQueryable());
            return model;
        }
        public async Task<bool> DeleteRecord(long id)
        {
            var result = await _iEntityRepository.GetByIdAsync(id);
            result.IsActive = false;
            await _iEntityRepository.UpdateAsync(result);
            return true;
        }

    }
}
