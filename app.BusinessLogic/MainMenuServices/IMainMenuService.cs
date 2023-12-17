using app.EntityModel.CoreModel;

namespace app.Services.MainMenuServices
{
    public interface IMainMenuService
    {
        Task<bool> AddRecord(MainMenuViewModel vm);
        Task<bool> UpdateRecord(MainMenuViewModel vm);
        Task<MainMenuViewModel> GetRecordById(long id);
        Task<List<MainMenu>> GetAllRecord();
        Task<bool> DeleteRecord(long id);
  
    }
}
