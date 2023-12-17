using System.ComponentModel;

namespace app.Services.ShiftServices
{
    public class ShiftViewModel:BaseViewModel
    {
        public string Name { get; set; }
        [DisplayName("Start At")]
        public DateTime StartAt { get; set; }

        [DisplayName("End At")]
        public DateTime EndAt { get; set; }

        public IEnumerable<ShiftViewModel> ShiftList { get; set; }
    }
}
