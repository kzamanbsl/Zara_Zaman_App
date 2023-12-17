using app.EntityModel;

namespace app.Services.DesignationServices
{
    public class DesignationViewModel: BaseViewModel
    {
        public string Name { get; set; }
        public IEnumerable<DesignationViewModel> DesignationList { get; set; }
    }
}
