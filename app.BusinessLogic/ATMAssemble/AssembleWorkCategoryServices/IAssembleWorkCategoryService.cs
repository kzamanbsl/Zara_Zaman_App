﻿namespace app.Services.ATMAssemble.AssembleWorkCategoryServices
{
    public interface IAssembleWorkCategoryService
    {

        Task<bool> AddRecord(AssembleWorkCategoryViewModel vm);
        Task<bool> UpdateRecord(AssembleWorkCategoryViewModel vm);
        Task<AssembleWorkCategoryViewModel> GetRecordById(long id);
        Task<AssembleWorkCategoryViewModel> GetAllRecord();
        Task<bool> DeleteRecord(long id);

    }
}
