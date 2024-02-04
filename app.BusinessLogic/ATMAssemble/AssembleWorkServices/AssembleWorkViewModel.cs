
namespace app.Services.ATMAssemble.AssembleWorkServices
{
    public class AssembleWorkViewModel : BaseViewModel
    {
        public long AssembleWorkCategoryId { get; set; }
        public string AssembleWorkCategoryName { get; set; }
        public DateTime AssembleDate { get; set; }
        public int AssembleTarget { get; set; } // False Prop
        public string Description { get; set; }
        public int StatusId { get; set; }
        private long[] EmployeeId;
        public long[] EmployeeIds
        {
            get { return EmployeeId; }
            set { EmployeeId = value; }
        }
        public IEnumerable<AssembleWorkViewModel> AssembleWorkList { get; set; }
    }
}
