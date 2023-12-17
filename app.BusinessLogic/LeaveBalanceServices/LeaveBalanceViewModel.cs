using System.ComponentModel;

namespace app.Services.LeaveBalanceServices
{
    public class LeaveBalanceViewModel:BaseViewModel
    {
        [DisplayName("Leave Qty")]
        public int LeaveQty { get; set; }
        public string Description { get; set; }
        public long LeaveCategoryId { get; set; }
        [DisplayName("Leave Category Name")]
        public string LeaveCategoryName { get; set; }
        public IEnumerable<LeaveBalanceViewModel> LeaveBalanceList { get; set; }
    }
}
