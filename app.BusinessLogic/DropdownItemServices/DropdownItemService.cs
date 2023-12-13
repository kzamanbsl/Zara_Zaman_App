
using app.EntityModel.AppModels;
using app.Infrastructure.Auth;
using app.Infrastructure.Repository;
using app.Infrastructure;
using app.Services.DropdownItemServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Services.DropdownItemServices
{
    public class DropdownItemService:IDropdownItemService
    {
        private readonly IEntityRepository<DropdownItem> _iEntityRepository;
        private readonly InventoryDbContext _dbContext;
        private readonly IWorkContext _iWorkContext;
        public DropdownItemService(IEntityRepository<DropdownItem> iEntityRepository, InventoryDbContext dbContext, IWorkContext iWorkContext)
        {
            _iEntityRepository = iEntityRepository;
            _dbContext = dbContext;
            _iWorkContext = iWorkContext;
        }

        public async Task<int> AddRecord(DropdownItemViewModel model)
        {
            var user = await _iWorkContext.GetCurrentAdminUserAsync();
            var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Name.Trim() == model.Name.Trim());
            if (checkName == null)
            {
                DropdownItem com = new DropdownItem();
                com.Name = model.Name;
                com.DropdownTypeId = model.DropdownTypeId;
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

        public async Task<DropdownItemViewModel> GetAllRecord()
        {
            DropdownItemViewModel model = new DropdownItemViewModel();
            model.DropdownItemList = await Task.Run(() => (from t1 in _dbContext.DropdownItem
                                                         where t1.IsActive == true
                                                         select new DropdownItemViewModel
                                                         {
                                                             Id = t1.Id,
                                                             Name = t1.Name,
                                                             DropdownTypeId = t1.DropdownTypeId,
                                                         }).AsQueryable());
            return model;
        }

        public async Task<DropdownItemViewModel> GetRecordById(long id)
        {
            var result = await _iEntityRepository.GetByIdAsync(id);
            DropdownItemViewModel model = new DropdownItemViewModel();
            model.Id = result.Id;
            model.Name = result.Name;
            model.DropdownTypeId = result.DropdownTypeId;
            return model;
        }

        public async Task<int> UpdateRecord(DropdownItemViewModel model)
        {

            var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Name.Trim() == model.Name.Trim());
            if (checkName == null)
            {
                var result = await _iEntityRepository.GetByIdAsync(model.Id);
                result.Name = model.Name;
                result.DropdownTypeId = model.DropdownTypeId;
                await _iEntityRepository.UpdateAsync(result);
                return 2;
            }
            return 1;
        }
    }
}
