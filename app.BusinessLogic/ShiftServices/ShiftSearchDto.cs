using app.EntityModel.DataTableSearchModels;
using System.ComponentModel;

namespace app.Services.ShiftServices
{
    public class ShiftSearchDto: BaseDataTableSearch
    {
        public string Name { get; set; }
        [DisplayName("Start At")]
        public DateTime StartAt { get; set; } = DateTime.Now;

        [DisplayName("End At")]
        public DateTime EndAt { get; set; }= DateTime.Now;

    }
}
