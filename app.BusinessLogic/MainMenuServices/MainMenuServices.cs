using app.EntityModel.CoreModel;
using app.Infrastructure.Repository;

namespace app.Services.MainMenuServices
{
    public class MainMenuService : IMainMenuService
    {
        private readonly IEntityRepository<MainMenu> _entityRepository;
        public MainMenuService(IEntityRepository<MainMenu> entityRepository)
        {
            _entityRepository = entityRepository;
        }
        public async Task<bool> AddRecord(MainMenuViewModel model)
        {
            var getItem = _entityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Name == model.Name.Trim());
            if (getItem == null)
            {
                MainMenu menu = new MainMenu();
                menu.Name = model.Name;
                menu.Icon = model.Icon;
                menu.OrderNo = model.OrderNo;
                var result = await _entityRepository.AddAsync(menu);
                if (result.Id > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        public async Task<bool> DeleteRecord(long id)
        {
            var getItem = await _entityRepository.GetByIdAsync(id);
            if (getItem != null)
            {
                getItem.IsActive = false;
                var result = await _entityRepository.UpdateAsync(getItem);
                if (result)
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        public async Task<List<MainMenu>> GetAllRecord()
        {
            List<MainMenu> getItem = _entityRepository.AllIQueryableAsync().OrderBy(d => d.OrderNo).ToList();
            return getItem;
        }

        public async Task<MainMenuViewModel> GetRecordById(long id)
        {
            MainMenu menu = await _entityRepository.GetByIdAsync(id);
            MainMenuViewModel model = new MainMenuViewModel();
            model.Id = menu.Id;
            model.Name = menu.Name;
            model.OrderNo = menu.OrderNo;
            model.Icon = menu.Icon;
            model.IsActive = menu.IsActive;
            return model;
        }

        public async Task<bool> UpdateRecord(MainMenuViewModel model)
        {
            var checkMenu = _entityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Name == model.Name && f.Id != model.Id);
            if (checkMenu == null)
            {
                var menu = await _entityRepository.GetByIdAsync(model.Id);
                menu.Name = model.Name;
                menu.Icon = model.Icon;
                menu.OrderNo = model.OrderNo;
                menu.IsActive = model.IsActive;
                var result = await _entityRepository.UpdateAsync(menu);
                if (result)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
    }
}
