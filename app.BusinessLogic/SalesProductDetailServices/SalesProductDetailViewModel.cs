using app.EntityModel.AppModels;

namespace app.Services.SalesProductDetailServices
{
    public class SalesProductDetailViewModel : BaseViewModel
    {
        public long SalesOrderDetailsId { get; set; }
        public SalesOrderDetails SalesOrderDetails { get; set; }
        public DateTime? WarrantyFormDate { get; set; }
        public DateTime? WarrantyToDate { get; set; }
       // public string SerialNo { get; set; }
        //public string ModelNo { get; set; }
        public bool IsForService { get; set; }

        public List<string> SerialNo { get; set; }
        public List<string> ModelNo { get; set; }
        public SalesProductDetailViewModel SalesProductDetailsVM { get; set; }
    }
}
