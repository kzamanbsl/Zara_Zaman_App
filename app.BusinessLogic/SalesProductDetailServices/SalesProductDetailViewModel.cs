using app.EntityModel.AppModels.SalesModels;

namespace app.Services.SalesProductDetailServices
{
    public class SalesProductDetailViewModel : BaseViewModel
    {
        public long SalesOrderDetailsId { get; set; }
        public SalesOrderDetail SalesOrderDetails { get; set; }
        public DateTime? WarrantyFormDate { get; set; }
        public DateTime? WarrantyToDate { get; set; }
        public List<bool?>  IsForService { get; set; }
        public List<string> SerialNo { get; set; }
        public List<string> ModelNo { get; set; }
        public SalesProductDetailViewModel SalesProductDetailsVM { get; set; }
    }
}
