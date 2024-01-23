using app.EntityModel.AppModels;
using app.Infrastructure;
using app.Infrastructure.Auth;
using app.Infrastructure.Repository;
using app.Utility;

namespace app.Services.SaleCenterServices
{
    public class SaleCenterService : ISaleCenterService
    {
        private readonly IEntityRepository<BusinessCenter> _iEntityRepository;
        private readonly InventoryDbContext _dbContext;
        private readonly IWorkContext _iWorkContext;
        public SaleCenterService(IEntityRepository<BusinessCenter> iEntityRepository, InventoryDbContext dbContext, IWorkContext iWorkContext)
        {
            _iEntityRepository = iEntityRepository;
            _dbContext = dbContext;
            _iWorkContext = iWorkContext;
        }

        public async Task<bool> AddRecord(SaleCenterViewModel vm)
        {
            var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Name.Trim() == vm.Name.Trim() && f.IsActive == true);
            if (checkName == null)
            {
                BusinessCenter saleCenter = new BusinessCenter();
                saleCenter.Name = vm.Name;
                saleCenter.Code = vm.Code;
                saleCenter.Location = vm.Location;
                saleCenter.Description = vm.Description;
                saleCenter.BusinessCenterTypeId=(int)BusinessCenterEnum.SaleCenter;
                var res = await _iEntityRepository.AddAsync(saleCenter);
                vm.Id = res.Id;
                return true;
            }
            return false;
        }
        public async Task<bool> UpdateRecord(SaleCenterViewModel vm)
        {

            var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Id == vm.Id && f.IsActive == true);
            //var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Name.Trim() == vm.Name.Trim());

            if (checkName != null)
            {
                // var saleCenter = await _iEntityRepository.GetByIdAsync(vm.Id);
                checkName.Id = vm.Id;
                checkName.Name = vm.Name;
                checkName.Code = vm.Code;
                checkName.Location = vm.Location;
                checkName.Description = vm.Description;
                checkName.BusinessCenterTypeId = (int)BusinessCenterEnum.SaleCenter;
                await _iEntityRepository.UpdateAsync(checkName);
                return true;
            }
            return false;
        }

        public async Task<SaleCenterViewModel> GetRecordById(long id)
        {
            var result = await _iEntityRepository.GetByIdAsync(id);
            SaleCenterViewModel model = new SaleCenterViewModel();
            model.Id = result.Id;
            model.Code = result.Code;
            model.Name = result.Name;
            model.Location = result.Location;
            model.Description = result.Description;
            model.BusinessCenterTypeId = result.BusinessCenterTypeId;
            return model;
        }
        public async Task<SaleCenterViewModel> GetAllRecord()
        {
            SaleCenterViewModel model = new SaleCenterViewModel();
            model.SaleCenterList = await Task.Run(() => (from t1 in _dbContext.BusinessCenter
                                                                where t1.BusinessCenterTypeId == (int)BusinessCenterEnum.SaleCenter && t1.IsActive == true
                                                                select new SaleCenterViewModel
                                                                {
                                                                    Id = t1.Id,
                                                                    Name = t1.Name,
                                                                    Code = t1.Code,
                                                                    Location = t1.Location,
                                                                    Description = t1.Description,
                                                                    BusinessCenterTypeId=t1.BusinessCenterTypeId,
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
