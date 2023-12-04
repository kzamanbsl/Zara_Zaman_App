using app.EntityModel.CoreModel;

namespace app.Services.MainMenuServices
{
    public interface IMainMenuService
    {
        Task<bool> AddRecord(MainMenuViewModel model);
        Task<List<MainMenu>> GetAllRecord();
        Task<bool> UpdateRecord(MainMenuViewModel model);
        Task<bool> DeleteRecord(long id);
        Task<MainMenuViewModel> GetRecordById(long id);
    }
}
