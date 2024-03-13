
using app.EntityModel.DataTableSearchModels;
using app.Services.ATMAssemble.AssembleWorkStepItemServices;
using System.ComponentModel;

namespace app.Services.ATMAssemble.AssembleWorkStepServices
{
    public class AssembleWorkStepSearchDto : BaseDataTableSearch
    {

        [DisplayName("Step Name")]
        public string Name { get; set; }
        public string Description { get; set; }

        [DisplayName("Assemble Name")]
        public long AssembleWorkCategoryId { get; set; }

        [DisplayName("Assemble Name")]
        public string AssembleWorkCategoryName { get; set; }
      
    }
}
