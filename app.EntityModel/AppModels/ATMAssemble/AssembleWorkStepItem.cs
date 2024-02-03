namespace app.EntityModel.AppModels.ATMAssemble
{
    public class AssembleWorkStepItem : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public long AssembleWorkStepId { get; set; }

        public AssembleWorkStep AssembleWorkStep { get; set; }
    }
}
