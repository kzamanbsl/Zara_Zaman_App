using app.Services.EmployeeServices;

namespace app.Services.ATMAssemble.AssembleWorkServices
{
    public class AssembleWorkMainDashboardViewModel
    {
        public long AssembleWorkCategoryId { get; set; }
        public string AssembleWorkCategoryName { get; set; }
        public DateTime AssembleDate { get; set; }
        public List<EmployeeViewModel> EmployeeList { get; set; } = new List<EmployeeViewModel>();
        public string EmployeesName { get; set; }
        public int TodayTarget { get; set; }
        public int WorkCompleted { get; set; }
        public int FaultQty { get; set; }
        public decimal Achievement => ((100 * WorkCompleted) / (TodayTarget > 0 ? TodayTarget : 1));

        public IEnumerable<AssembleWorkMainDashboardViewModel> MainDashboardList { get; set; }
    }
}
