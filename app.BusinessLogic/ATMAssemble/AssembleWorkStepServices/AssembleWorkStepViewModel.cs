
namespace app.Services.ATMAssemble.AssembleWorkStepServices
{
    public class AssembleWorkStepViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public long AssembleWorkCategoryId { get; set; }
        public string AssembleWorkCategoryName { get; set; }
        public IEnumerable<AssembleWorkStepViewModel> AssembleWorkStepList { get; set; }
    }
}
