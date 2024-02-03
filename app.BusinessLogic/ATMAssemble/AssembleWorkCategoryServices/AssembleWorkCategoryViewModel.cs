namespace app.Services.ATMAssemble.AssembleWorkCategoryServices
{
    public class AssembleWorkCategoryViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<AssembleWorkCategoryViewModel> AssembleWorkCategoryList { get; set; }
    }
}
