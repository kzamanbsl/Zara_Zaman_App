using app.EntityModel;

namespace app.Services.OfficeTypeServices
{
    public class OfficeTypeViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public IEnumerable<OfficeTypeViewModel> OfficeTypeList { get; set; }
    }
}
