using app.EntityModel.AppModels;

namespace app.Services.LeaveBalanceServices
{
    public class LeaveBalanceViewModel:BaseViewModel
    {
        public int LeaveQty { get; set; }
        public string Description { get; set; }
        public long LeaveCategoryId { get; set; }
        public string LeaveCategoryName { get; set; }
        public IEnumerable<LeaveBalanceViewModel> LeaveBalanceList { get; set; }
        public List<LeaveCategory> leaveCategories { get; set; }
    }
}
