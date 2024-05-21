namespace app.Services.BankServices
{
    public class BankViewModel:BaseViewModel
    {
        public string Name { get; set; }
        public IEnumerable<BankViewModel> BankList { get; set; }
    }
}
