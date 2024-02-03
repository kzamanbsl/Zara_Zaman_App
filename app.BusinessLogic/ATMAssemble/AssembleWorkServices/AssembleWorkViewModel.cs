
namespace app.Services.ATMAssemble.AssembleWorkStepServices
{
    public class AssembleWorkViewModel : BaseViewModel
    {
        public long AssembleWorkCategoryId { get; set; }
        public string AssembleWorkCategoryName { get; set; }
        public DateTime AssembleDate { get; set; }
        public int AssembleTarget { get; set; } // False Prop
        public string Description { get; set; }
        public int StatusId { get; set; }

        public IEnumerable<AssembleWorkViewModel> AssembleWorkList { get; set; }
    }
}
