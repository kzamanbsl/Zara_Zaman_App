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
            model.DivisionId = result.DivisionId;
            model.DivisionName = result.Division?.Name;
            model.DistrictId = result.DistrictId;
            model.DistrictName = result.District?.Name;
            model.UpazilaId = result.UpazilaId;
            model.UpazilaName = result.Upazila?.Name;
            return model;
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
                                                          Phone= t1.Phone,
                                                          Email = t1.Email,
                                                          Description = t1.Description,
                                                          Address = t1.Address,
                                                          DivisionId = t1.DivisionId,
                                                          DistrictId = t1.DistrictId,
                                                          UpazilaId= t1.UpazilaId,
                                                      }).AsQueryable());
            return model;
        }
        public async Task<bool> AddRecord(CustomerViewModel vm)
        {
            var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Name.Trim() == vm.Name.Trim());
            if (checkName == null)
            {
                Customer com = new Customer();
                com.Name = vm.Name;
                com.Phone = vm.Phone;
                com.Email = vm.Email;
                com.Description = vm.Description;
                com.Address = vm.Address;
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

            var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Name.Trim() == vm.Name.Trim());
            if (checkName != null)
            {
                var result = await _iEntityRepository.GetByIdAsync(vm.Id);
                result.Name = vm.Name;
                result.Phone = vm.Phone;
                result.Email = vm.Email;
                result.Description = vm.Description;
                result.Address = vm.Address;
                result.DivisionId = vm.DivisionId;
                result.DistrictId= vm.DistrictId;
                result.UpazilaId= vm.UpazilaId;
                await _iEntityRepository.UpdateAsync(result);
                return true;
            }
            return false;
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
