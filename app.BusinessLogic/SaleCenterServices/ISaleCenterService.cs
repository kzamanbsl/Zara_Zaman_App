﻿namespace app.Services.SaleCenterServices
{
    public interface ISaleCenterService
    {
       
        Task<bool> AddRecord(SaleCenterViewModel vm);
        Task<bool> UpdateRecord(SaleCenterViewModel vm);

        Task<SaleCenterViewModel> GetRecordById(long id);
        Task<SaleCenterViewModel> GetAllRecord();
        Task<bool> DeleteRecord(long id);
    }
}