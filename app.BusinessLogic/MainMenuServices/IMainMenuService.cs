﻿using app.EntityModel.CoreModel;
using app.EntityModel.DataTablePaginationModels;
using app.Services.UserServices;

namespace app.Services.MainMenuServices
{
    public interface IMainMenuService
    {
        Task<bool> AddRecord(MainMenuViewModel vm);
        Task<bool> UpdateRecord(MainMenuViewModel vm);
        Task<MainMenuViewModel> GetRecordById(long id);
        Task<bool> DeleteRecord(long id);
        Task<List<MainMenu>> GetAllRecord();
        Task<DataTablePagination<MainMenuSearchDto>> SearchAsync(DataTablePagination<MainMenuSearchDto> searchDto);

    }
}
