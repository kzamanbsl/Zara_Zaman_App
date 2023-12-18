using System.ComponentModel;

namespace app.Services.LeaveBalanceServices
{
    public class LeaveBalanceCountViewModel
    {
        [DisplayName("Leave Qty")]
        public int LeaveQty { get; set; }
        public int LeaveUsedQty { get; set; }
        public int LeaveRemainingQty { get; set; }
        public string Description { get; set; }
        public long LeaveCategoryId { get; set; }
        [DisplayName("Leave Category Name")]
        public string LeaveCategoryName { get; set; }
    }
}
