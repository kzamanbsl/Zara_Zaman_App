namespace app.EntityModel.AppModels.Office
{
    public class Shift : BaseEntity
    {
        public string Name { get; set; }
        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }

    }
}
