using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace app.EntityModel.DataTableSearchModels;

public abstract class BaseDataTableSearch : IDataTableSearch
{
    public long? Id { get; set; }

    [DisplayName("#SL")]
    public int? SerialNo { get; set; }

    public string Action { get; set; }

    [DisplayName("Created By")]
    public string CreatedBy { get; set; }

    [DisplayName("Created On")]
    public DateTime CreatedOn { get; set; }

    [DisplayName("Updated By")]
    public string UpdatedBy { get; set; }

    [DisplayName("Updated On")]
    public DateTime? UpdatedOn { get; set; }

    public bool IsActive { get; set; }
}