using System.ComponentModel;

namespace app.Services.StorehouseServices
{
    public class StorehouseViewModel:BaseViewModel
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public IEnumerable<StorehouseViewModel> StorehouseList { get; set; }
    }
}
