using app.EntityModel.AppModels;
using app.EntityModel.DataTablePaginationModels;
using app.Infrastructure;
using app.Infrastructure.Auth;
using app.Infrastructure.Repository;
using app.Services.DepartmentServices;
using app.Utility;
using Microsoft.EntityFrameworkCore;

namespace app.Services.ServiceCenterServices
{
    public class ServiceCenterService : IServiceCenterService
    {
        private readonly IEntityRepository<BusinessCenter> _iEntityRepository;
        private readonly InventoryDbContext _dbContext;
        private readonly IWorkContext _iWorkContext;
        public ServiceCenterService(IEntityRepository<BusinessCenter> iEntityRepository, InventoryDbContext dbContext, IWorkContext iWorkContext)
        {
            _iEntityRepository = iEntityRepository;
            _dbContext = dbContext;
            _iWorkContext = iWorkContext;
        }

        public async Task<bool> AddRecord(ServiceCenterViewModel vm)
        {
            var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Name.Trim() == vm.Name.Trim() && f.IsActive == true);
            if (checkName == null)
            {
                BusinessCenter serviceCenter = new BusinessCenter();
                serviceCenter.Name = vm.Name;
                serviceCenter.Code = vm.Code;
                serviceCenter.Location = vm.Location;
                serviceCenter.Description = vm.Description;
                serviceCenter.BusinessCenterTypeId=(int)BusinessCenterEnum.ServiceCenter;
                var res = await _iEntityRepository.AddAsync(serviceCenter);
                vm.Id = res.Id;
                return true;
            }
            return false;
        }
        public async Task<bool> UpdateRecord(ServiceCenterViewModel vm)
        {

            //var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Name.Trim() == vm.Name.Trim());
            //var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Id == vm.Id && f.IsActive == true);
            var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Name.Trim() == vm.Name.Trim() && f.Id != vm.Id && f.BusinessCenterTypeId == (int)BusinessCenterEnum.ServiceCenter && f.IsActive == true);
            if (checkName == null)
            {
                var serviceCenter = await _iEntityRepository.GetByIdAsync(vm.Id);
                serviceCenter.Name = vm.Name;
                serviceCenter.Code = vm.Code;
                serviceCenter.Location = vm.Location;
                serviceCenter.Description = vm.Description;
                serviceCenter.BusinessCenterTypeId = (int)BusinessCenterEnum.ServiceCenter;
                await _iEntityRepository.UpdateAsync(serviceCenter);
                return true;
            }
            return false;
        }
        public async Task<ServiceCenterViewModel> GetRecordById(long id)
        {
            var result = await _iEntityRepository.GetByIdAsync(id);
            ServiceCenterViewModel model = new ServiceCenterViewModel();
            model.Id = result.Id;
            model.Code = result.Code;
            model.Name = result.Name;
            model.Location = result.Location;
            model.Description = result.Description;
            model.BusinessCenterTypeId =result.BusinessCenterTypeId;
            return model;
        }
        public async Task<bool> DeleteRecord(long id)
        {
            var result = await _iEntityRepository.GetByIdAsync(id);
            result.IsActive = false;
            await _iEntityRepository.UpdateAsync(result);
            return true;
        }
        public async Task<ServiceCenterViewModel> GetAllRecord()
        {
            ServiceCenterViewModel model = new ServiceCenterViewModel();
            model.ServiceCenterList = await Task.Run(() => (from t1 in _dbContext.BusinessCenter
                                                            where t1.BusinessCenterTypeId == (int)BusinessCenterEnum.ServiceCenter && t1.IsActive == true
                                                            select new ServiceCenterViewModel
                                                            {
                                                                Id = t1.Id,
                                                                Name = t1.Name,
                                                                Code = t1.Code,
                                                                Location = t1.Location,
                                                                Description = t1.Description,
                                                                BusinessCenterTypeId = t1.BusinessCenterTypeId,
                                                            }).AsEnumerable());
            return model;
        }
        public async Task<DataTablePagination<ServiceCenterSearchDto>> SearchAsync(DataTablePagination<ServiceCenterSearchDto> searchDto)
        {
            var searchResult = _dbContext.BusinessCenter.Where(c => c.IsActive == true).AsNoTracking();

            var searchModel = searchDto.SearchVm;
            var filter = searchDto?.Search?.Value?.Trim();

            if (!string.IsNullOrEmpty(filter))
            {
                filter = filter.ToLower();
                searchResult = searchResult.Where(c =>
                    c.Name.ToLower().Contains(filter)
                    || c.Code.ToString().Contains(filter)
                    || c.Location.ToLower().Contains(filter)
                );
            }

            var pageSize = searchDto.Length ?? 0;
            var skip = searchDto.Start ?? 0;

            var totalRecords = searchResult.Count();
            if (totalRecords <= 0) return searchDto;

            searchDto.RecordsTotal = totalRecords;
            searchDto.RecordsFiltered = totalRecords;
            List<BusinessCenter> filteredDataList = await searchResult.OrderByDescending(c => c.Id).Skip(skip).Take(pageSize).ToListAsync();

            var sl = searchDto.Start ?? 0;
            searchDto.Data = filteredDataList.Select(c => new ServiceCenterSearchDto()
            {
                SerialNo = ++sl,
                Id = c.Id,
                Name = c.Name,
                Code = c.Code,
                Location = c.Location,
                Description = c.Description,

            }).ToList();

            return searchDto;
        }
    }
}
