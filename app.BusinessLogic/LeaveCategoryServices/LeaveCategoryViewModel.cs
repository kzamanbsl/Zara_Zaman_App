namespace app.Services.LeaveCategoryServices
{
    public class LeaveCategoryViewModel: BaseViewModel
    {
        public string Name { get; set; }
        public IEnumerable<LeaveCategoryViewModel> LeaveCategoryList { get; set; }
    }
}
