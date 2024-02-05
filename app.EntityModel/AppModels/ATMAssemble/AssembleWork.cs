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

        public List<AssembleWorkDetail> WorkDetails { get; set; } = new List<AssembleWorkDetail>();
        public List<AssembleWorkEmployee> WorkEmployees { get; set; } = new List<AssembleWorkEmployee>();
    }
}
