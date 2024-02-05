namespace app.EntityModel.AppModels.ATMAssemble
{
    public class AssembleWorkDetail : BaseEntity
    {
        public long AssembleWorkId { get; set; }
        public long AssembleWorkStepItemId { get; set; }
        public string Remarks { get; set; }
        public bool IsComplete { get; set; }

        public AssembleWork AssembleWork { get; set; }
        public AssembleWorkStepItem AssembleWorkStepItem { get; set; }
    }
}
