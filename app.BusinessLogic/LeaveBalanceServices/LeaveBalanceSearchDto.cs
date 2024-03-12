using app.EntityModel.DataTableSearchModels;
using System.ComponentModel;

namespace app.Services.LeaveBalanceServices
{
    public class LeaveBalanceSearchDto: BaseDataTableSearch
    {
        [DisplayName("Leave Qty")]
        public int LeaveQty { get; set; }
        public string Description { get; set; }
        public long LeaveCategoryId { get; set; }

        [DisplayName("Leave Category Name")]
        public string LeaveCategoryName { get; set; }
    }
}
