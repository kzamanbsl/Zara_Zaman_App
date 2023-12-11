namespace app.Services.ShiftServices
{
    public class ShiftViewModel:BaseViewModel
    {
        public string Name { get; set; }
        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }
        public IEnumerable<ShiftViewModel> ShiftList { get; set; }
    }
}
