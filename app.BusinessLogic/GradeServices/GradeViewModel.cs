namespace app.Services.GradeServices
{
    public class GradeViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public IEnumerable<GradeViewModel> GradeList { get; set; }
    }
}
