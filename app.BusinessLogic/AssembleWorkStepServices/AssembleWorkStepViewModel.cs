using app.Services.AssembleWorkCategoryServices;
using System.ComponentModel.DataAnnotations;

namespace app.Services.AssembleWorkStepServices
{
    public class AssembleWorkStepViewModel:BaseViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public long AssembleWorkCategoryId { get; set; }
        public string AssembleWorkCategoryName { get; set; }
        [Display(Name = "Select Assemble")]
        public IEnumerable<AssembleWorkCategoryViewModel> AssembleWorkCategoryList { get; set; }
        public IEnumerable<AssembleWorkStepViewModel> AssembleWorkStepList { get; set; }
    }
}
