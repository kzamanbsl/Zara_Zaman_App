namespace app.Services.SalesOrderServices
{
    public interface ISalesOrderService
    {
        Task<bool> AddSalesOrder(SalesOrderViewModel vm);      
        Task<SalesOrderViewModel> GetSalesOrder(long salesOrderId);
        Task<SalesOrderViewModel> GetSalesOrderDetails(long id);
        Task<SalesOrderViewModel> GetAllRecord(); 
        Task<bool> ConfirmSalesOrder(long id);
        Task<bool> DeleteSalesOrder(long id);
        Task<bool> RejectSalesOrder(long id);
        Task<bool> UpdateSalesOrder(SalesOrderViewModel vm);
    }
}
