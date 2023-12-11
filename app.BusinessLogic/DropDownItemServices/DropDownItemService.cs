using app.EntityModel.AppModels;
using app.Infrastructure.Auth;
using app.Infrastructure.Repository;
using app.Infrastructure;
using app.Services.DropDownItemServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Services.DropDownItemServices
{
    public class DropDownItemService:IDropDownItemService
    {
        private readonly IEntityRepository<DropDownItem> _iEntityRepository;
        private readonly InventoryDbContext _dbContext;
        private readonly IWorkContext _iWorkContext;
        public DropDownItemService(IEntityRepository<DropDownItem> iEntityRepository, InventoryDbContext dbContext, IWorkContext iWorkContext)
        {
            _iEntityRepository = iEntityRepository;
            _dbContext = dbContext;
            _iWorkContext = iWorkContext;
        }

        public async Task<int> AddRecord(DropDownItemViewModel model)
        {
            var user = await _iWorkContext.GetCurrentAdminUserAsync();
            var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Name.Trim() == model.Name.Trim());
            if (checkName == null)
            {
                DropDownItem com = new DropDownItem();
                com.Name = model.Name;
                com.DropDownTypeId = model.DropDownTypeId;
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

        public async Task<DropDownItemViewModel> GetAllRecord()
        {
            DropDownItemViewModel model = new DropDownItemViewModel();
            model.DropDownItemList = await Task.Run(() => (from t1 in _dbContext.DropDownItem
                                                         where t1.IsActive == true
                                                         select new DropDownItemViewModel
                                                         {
                                                             Id = t1.Id,
                                                             Name = t1.Name,
                                                             DropDownTypeId = t1.DropDownTypeId,
                                                         }).AsQueryable());
            return model;
        }

        public async Task<DropDownItemViewModel> GetRecordById(long id)
        {
            var result = await _iEntityRepository.GetByIdAsync(id);
            DropDownItemViewModel model = new DropDownItemViewModel();
            model.Id = result.Id;
            model.Name = result.Name;
            model.DropDownTypeId = result.DropDownTypeId;
            return model;
        }

        public async Task<int> UpdateRecord(DropDownItemViewModel model)
        {

            var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Name.Trim() == model.Name.Trim());
            if (checkName == null)
            {
                var result = await _iEntityRepository.GetByIdAsync(model.Id);
                result.Name = model.Name;
                result.DropDownTypeId = model.DropDownTypeId;
                await _iEntityRepository.UpdateAsync(result);
                return 2;
            }
            return 1;
        }
    }
}
