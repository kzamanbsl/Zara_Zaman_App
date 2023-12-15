namespace app.EntityModel.AppModels
{
    public class DropdownItem : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int DropdownTypeId { get; set; }
    }

}
