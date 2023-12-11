namespace app.Services.EmployeeServiceTypeServices
{
    public class EmployeeServiceTypeViewModel:BaseViewModel
    {
        public string Name { get; set; }
        public IEnumerable<EmployeeServiceTypeViewModel> EmployeeServiceTypeList { get; set; }
    }
}
