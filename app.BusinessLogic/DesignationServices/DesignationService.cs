using app.EntityModel.AppModels;
using app.Infrastructure.Auth;
using app.Infrastructure.Repository;
using app.Infrastructure;
using app.Services.DesignationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Services.DesignationServices
{
    public class DesignationService : IDesignationService
    {
        private readonly IEntityRepository<Designation> _iEntityRepository;
        private readonly InventoryDbContext _dbContext;
        private readonly IWorkContext _iWorkContext;
        public DesignationService(IEntityRepository<Designation> iEntityRepository, InventoryDbContext dbContext, IWorkContext iWorkContext)
        {
            _iEntityRepository = iEntityRepository;
            _dbContext = dbContext;
            _iWorkContext = iWorkContext;
        }

        public async Task<int> AddRecord(DesignationViewModel model)
        {
            var user = await _iWorkContext.GetCurrentAdminUserAsync();
            var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Name.Trim() == model.Name.Trim());
            if (checkName == null)
            {
                Designation com = new Designation();
                com.Name = model.Name;
                var res = await _iEntityRepository.AddAsync(com);
                return 2;
            }
            return 1;
        }

        public async Task<bool> DeleteRecord(long id)
        {
            var result = await _iEntityRepository.GetByIdAsync(id);
            result.IsActive = false;
            await _iEntityRepository.UpdateAsync(result);
            return true;
        }

        public async Task<DesignationViewModel> GetAllRecord()
        {
            DesignationViewModel model = new DesignationViewModel();
            model.DesignationList = await Task.Run(() => (from t1 in _dbContext.Designation
                                                         where t1.IsActive == true
                                                         select new DesignationViewModel
                                                         {
                                                             Id = t1.Id,
                                                             Name = t1.Name,
                                                         }).AsQueryable());
            return model;
        }

        public async Task<DesignationViewModel> GetRecordById(long id)
        {
            var result = await _iEntityRepository.GetByIdAsync(id);
            DesignationViewModel model = new DesignationViewModel();
            model.Id = result.Id;
            model.Name = result.Name;
            return model;
        }

        public async Task<int> UpdateRecord(DesignationViewModel model)
        {

            var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Name.Trim() == model.Name.Trim());
            if (checkName == null)
            {
                var result = await _iEntityRepository.GetByIdAsync(model.Id);
                result.Name = model.Name;
                await _iEntityRepository.UpdateAsync(result);
                return 2;
            }
            return 1;
        }
    }
}
