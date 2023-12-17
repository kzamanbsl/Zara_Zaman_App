namespace app.Services.EmployeeGradeServices
{
    public class EmployeeGradeViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public IEnumerable<EmployeeGradeViewModel> EmployeeGradeList { get; set; }
    }
}
