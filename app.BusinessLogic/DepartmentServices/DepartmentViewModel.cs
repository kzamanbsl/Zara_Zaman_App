namespace app.Services.DepartmentServices
{
    public class DepartmentViewModel:BaseViewModel
    {
        public string Name { get; set; }
        public IEnumerable<DepartmentViewModel> DepartmentList { get; set; }
    }
}
