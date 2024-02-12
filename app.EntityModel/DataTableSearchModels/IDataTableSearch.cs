using System.ComponentModel.DataAnnotations;

namespace app.EntityModel.DataTableSearchModels
{
    public interface IDataTableSearch
    {
        public long? Id { get; set; }
        public int? SerialNo { get; set; }
        public string Action { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsActive { get; set; }
    }
}
