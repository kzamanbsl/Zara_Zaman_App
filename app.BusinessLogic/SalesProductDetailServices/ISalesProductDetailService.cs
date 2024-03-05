using app.Services.SalesOrderServices;

namespace app.Services.SalesProductDetailServices
{
    public interface ISalesProductDetailService
    {
        Task<bool> AddSalesProductDetails(SalesOrderViewModel vm);
    }
}
