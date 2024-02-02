namespace app.EntityModel.AppModels
{
    public class AssembleWorkStep : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public long AssembleWorkCategoryId { get; set; }

        public AssembleWorkCategory AssembleWorkCategory { get; set; }
    }
}
