using app.Services.SalesOrderServices;

namespace app.Services.SalesOrderDetailServices
{
    public interface ISalesOrderDetailService
    {
        Task<bool> AddSalesOrderDetails(SalesOrderViewModel vm);
        Task<bool> UpdateSalesDetail(SalesOrderDetailViewModel vm);
        //Task<bool> DeleteSalesDetail(long id);
        //Task<SalesOrderDetailViewModel> SingleSalesOrderDetails(long id);
    }
}
