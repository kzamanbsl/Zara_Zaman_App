using app.EntityModel;

namespace app.Services.EmployeeCategoryServices
{
    public class EmployeeCategoryViewModel: BaseViewModel
    {
        public string Name { get; set; }
        public IEnumerable<EmployeeCategoryViewModel> EmployeeCategoryList { get; set; }
    }
}
