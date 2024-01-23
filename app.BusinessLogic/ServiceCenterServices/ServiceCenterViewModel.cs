using System.ComponentModel;

namespace app.Services.ServiceCenterServices
{
    public class ServiceCenterViewModel:BaseViewModel
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public int BusinessCenterTypeId { get; set; }
        public IEnumerable<ServiceCenterViewModel> ServiceCenterList { get; set; }
    }
}
