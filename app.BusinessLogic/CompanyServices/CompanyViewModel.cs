namespace app.Services.CompanyServices
{
    public class CompanyViewModel:BaseViewModel
    {
        public string Name { get; set; }
        public IEnumerable<CompanyViewModel> CompanyList { get; set; }
    }
}
