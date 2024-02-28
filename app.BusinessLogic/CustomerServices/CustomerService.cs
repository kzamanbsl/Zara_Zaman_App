using app.EntityModel.AppModels;
using app.Infrastructure.Auth;
using app.Infrastructure.Repository;
using app.Infrastructure;
using app.Services.CustomerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using app.EntityModel.DataTablePaginationModels;
using app.Services.SupplierServices;
using Microsoft.EntityFrameworkCore;

namespace app.Services.CustomerServices
{
    public class CustomerService : ICustomerService
    {
        private readonly IEntityRepository<Customer> _iEntityRepository;
        private readonly InventoryDbContext _dbContext;
        private readonly IWorkContext _iWorkContext;
        public CustomerService(IEntityRepository<Customer> iEntityRepository, InventoryDbContext dbContext, IWorkContext iWorkContext)
        {
            _iEntityRepository = iEntityRepository;
            _dbContext = dbContext;
            _iWorkContext = iWorkContext;
        }

        public async Task<bool> AddRecord(CustomerViewModel vm)
        {
            var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Name.Trim() == vm.Name.Trim() && f.IsActive == true);
            if (checkName == null)
            {
                Customer com = new Customer();
                com.Name = vm.Name;
                com.Phone = vm.Phone;
                com.Email = vm.Email;
                com.Description = vm.Description;
                com.Address = vm.Address;
                //com.c = vm.CountryId;
                com.DivisionId = vm.DivisionId;
                com.DistrictId = vm.DistrictId;
                com.UpazilaId = vm.UpazilaId;
                var res = await _iEntityRepository.AddAsync(com);
                vm.Id = res.Id;
                return true;
            }
            return false;
        }
        public async Task<bool> UpdateRecord(CustomerViewModel vm)
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
                //result.CountryId = vm.CountryId;
                result.DivisionId = vm.DivisionId;
                result.DistrictId= vm.DistrictId;
                result.UpazilaId= vm.UpazilaId;
                await _iEntityRepository.UpdateAsync(result);
                return true;
            }
            return false;
        }
        public async Task<CustomerViewModel> GetRecordById(long id)
        {
            var result = await _iEntityRepository.GetByIdAsync(id);
            CustomerViewModel model = new CustomerViewModel();
            model.Id = result.Id;
            model.Name = result.Name;
            model.Phone = result.Phone;
            model.Email = result.Email;
            model.Description = result.Description;
            model.Address = result.Address;
            model.Description = result.Description;
            //model.CountryId = result.CountryId;
            //model.CountryName = result.Country?.Name;
            model.DivisionId = result.DivisionId;
            model.DivisionName = result.Division?.Name;
            model.DistrictId = result.DistrictId;
            model.DistrictName = result.District?.Name;
            model.UpazilaId = result.UpazilaId;
            model.UpazilaName = result.Upazila?.Name;
            return model;
        }
        public async Task<bool> DeleteRecord(long id)
        {
            var result = await _iEntityRepository.GetByIdAsync(id);
            result.IsActive = false;
            await _iEntityRepository.UpdateAsync(result);
            return true;
        }
        public async Task<CustomerViewModel> GetAllRecord()
        {
            CustomerViewModel model = new CustomerViewModel();
            model.CustomerList = await Task.Run(() => (from t1 in _dbContext.Customer
                                                       where t1.IsActive == true
                                                       select new CustomerViewModel
                                                       {
                                                           Id = t1.Id,
                                                           Name = t1.Name,
                                                           Phone = t1.Phone,
                                                           Email = t1.Email,
                                                           Description = t1.Description,
                                                           Address = t1.Address,
                                                           //CountryId = t1.CountryId,
                                                           //CountryName = t1.Country.Name,
                                                           DistrictId = t1.DistrictId,
                                                           DistrictName = t1.District.Name,
                                                           DivisionId = t1.DivisionId,
                                                           DivisionName = t1.Division.Name,
                                                           UpazilaId = t1.UpazilaId,
                                                           UpazilaName = t1.Upazila.Name,
                                                       }).AsEnumerable());
            return model;
        }
        public async Task<DataTablePagination<CustomerSearchDto>> SearchAsync(DataTablePagination<CustomerSearchDto> searchDto)
        {
            var searchResult = _dbContext.Customer.Include(c => c.Upazila).Include(c => c.District).Include(c => c.Division).AsNoTracking();

            var searchModel = searchDto.SearchVm;
            var filter = searchDto?.Search?.Value?.Trim();
            //if (searchModel?.CountryId is > 0)
            //{
            //    searchResult = searchResult.Where(c => c.CountryId == searchModel.CountryId);
            //}
            if (searchModel?.DivisionId is > 0)
            {
                searchResult = searchResult.Where(c => c.DivisionId == searchModel.DivisionId);
            }
            if (searchModel?.DistrictId is > 0)
            {
                searchResult = searchResult.Where(c => c.DistrictId == searchModel.DistrictId);
            }
            if (searchModel?.UpazilaId is > 0)
            {
                searchResult = searchResult.Where(c => c.UpazilaId == searchModel.UpazilaId);
            }
            if (!string.IsNullOrEmpty(filter))
            {
                filter = filter.ToLower();
                searchResult = searchResult.Where(c =>
                    c.Name.ToLower().Contains(filter)
                    || c.Phone.ToString().Contains(filter)
                    || c.Address.ToLower().Contains(filter)
                    //|| c.Country.Name.ToString().Contains(filter)
                     || c.Division.Name.ToLower().Contains(filter)
                     || c.District.Name.ToLower().Contains(filter)
                      || c.Upazila.Name.ToLower().Contains(filter)
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
            List<Customer> filteredDataList = await searchResult.OrderByDescending(c => c.Id).Skip(skip).Take(pageSize).ToListAsync();

            var sl = searchDto.Start ?? 0;
            searchDto.Data = filteredDataList.Select(c => new CustomerSearchDto()
            {
                SerialNo = ++sl,
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
                Phone = c.Phone,
                Email = c.Email,

                //CountryId = c.CountryId,
                //CountryName = c.Country.Name,
                DivisionId = c.DivisionId,
                DivisionName = c.Division.Name,
                DistrictId = c.DistrictId,
                DistrictName = c.District.Name,
                UpazilaId = c.UpazilaId,
                UpazilaName = c.Upazila.Name,
                Address = c.Address,
            }).ToList();

            return searchDto;
        }



    }
}
