using app.Services.SalesOrderServices;

namespace app.Services.SalesOrderDetailServices
{
    public interface ISalesOrderDetailService
    {
        Task<bool> AddRecord(SalesOrderViewModel vm);
        Task<bool> UpdateSalesDetail(SalesOrderViewModel vm);
        Task<bool> DeleteSalesDetail(long id);
        Task<SalesOrderDetailViewModel> SingleSalesOrderDetails(long id);
    }
}
