namespace app.Services.ATMAssemble.AssembleWorkServices
{
    public class AssembleWorkMainDashboardViewModel
    {
        public long AssembleWorkCategoryId { get; set; }
        public string AssembleWorkCategoryName { get; set; }
        public DateTime AssembleDate { get; set; }
        public string EmployeesName { get; set; }
        public int TodayTarget { get; set; }
        public int WorkCompleted { get; set; }
        public int FaultQty { get; set; }
        public decimal Achievement => ((100 * WorkCompleted) / TodayTarget);

        public IEnumerable<AssembleWorkMainDashboardViewModel> MainDashboardList { get; set; }
    }
}
