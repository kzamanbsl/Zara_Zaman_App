
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using app.Services.SalesTermsAndConditonServices;

namespace app.Services.SalesOrderServices
{
    public interface ISalesOrderService
    {
        Task<bool> AddSalesOrder(SalesOrderViewModel vm);      
        Task<SalesOrderViewModel> GetSalesOrder(long salesOrderId);
        Task<SalesOrderViewModel> GetSalesOrderDetails(long id);
        //Task<SalesTermsAndConditionViewModel> GetSOTermsAndCondition(long id);
        Task<SalesOrderViewModel> GetAllSalesRecord();
        //Task<SalesOrderViewModel> GetAllRecord();
        Task<bool> ConfirmSalesOrder(long id);
        Task<bool> DeleteSalesOrder(long id);
        Task<bool> RejectSalesOrder(long id);
        Task<bool> UpdateSalesOrder(SalesOrderViewModel vm);
        Task<SalesOrderViewModel> SalesOrderById(long id);
    }
}
