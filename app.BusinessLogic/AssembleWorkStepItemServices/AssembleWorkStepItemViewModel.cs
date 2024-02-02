namespace app.Services.AssembleWorkStepItemServices
{
    public class AssembleWorkStepItemViewModel:BaseViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<AssembleWorkStepItemViewModel> AssembleWorkStepItemList { get; set; }
    }
}
