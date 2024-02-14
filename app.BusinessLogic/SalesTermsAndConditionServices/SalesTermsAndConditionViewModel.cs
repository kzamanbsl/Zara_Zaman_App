namespace app.Services.SalesTermsAndConditonServices
{
    public class SalesTermsAndConditionViewModel : BaseViewModel
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public IEnumerable<SalesTermsAndConditionViewModel> SalesTermsAndConditionList { get; set; }
    }
}
