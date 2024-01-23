using System.ComponentModel;

namespace app.Services.SaleCenterServices
{
    public class SaleCenterViewModel:BaseViewModel
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public int BusinessCenterTypeId { get; set; }
        public IEnumerable<SaleCenterViewModel> SaleCenterList { get; set; }
    }
}
