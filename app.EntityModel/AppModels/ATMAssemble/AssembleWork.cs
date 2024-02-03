namespace app.EntityModel.AppModels.ATMAssemble
{
    public class AssembleWork : BaseEntity
    {
        public long AssembleWorkCategoryId { get; set; }
        public DateTime AssembleDate { get; set; }
        //public int AssembleTarget { get; set; }
        public string Description { get; set; }
        public int StatusId { get; set; }

        public AssembleWorkCategory AssembleWorkCategory { get; set; }
    }
}
