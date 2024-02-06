
namespace app.Services.ATMAssemble.AssembleWorkDetailServices
{
    public class AssembleWorkDetailViewModel : BaseViewModel
    {
        public long AssembleWorkId { get; set; }
        public string AssembleWorkName { get; set; }
        public long AssembleWorkStepId { get; set; }
        public string AssembleWorkStepName { get; set; }
        public long AssembleWorkStepItemId { get; set; }
        public string AssembleWorkStepItemName { get; set; }
        public string Remarks { get; set; }
        public bool IsComplete { get; set; }


        public IEnumerable<AssembleWorkDetailViewModel> AssembleWorkDetailList { get; set; }
    }
}
