namespace app.EntityModel.AppModels.EmployeeModels
{
    public class Shift : BaseEntity
    {
        public string Name { get; set; }
        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }

    }
}
