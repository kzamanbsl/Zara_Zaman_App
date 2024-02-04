namespace app.Services.ATMAssemble.AssembleWorkStepItemServices
{
    public class AssembleWorkStepItemViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public long AssembleWorkStepId { get; set; }
        public string AssembleWorkStepName { get; set; }
        public IEnumerable<AssembleWorkStepItemViewModel> AssembleWorkStepItemList { get; set; }
    }
}
