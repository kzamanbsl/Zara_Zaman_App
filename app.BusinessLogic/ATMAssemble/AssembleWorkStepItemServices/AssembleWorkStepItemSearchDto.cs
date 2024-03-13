using app.EntityModel.DataTableSearchModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace app.Services.ATMAssemble.AssembleWorkStepItemServices
{
    public class AssembleWorkStepItemSearchDto : BaseDataTableSearch
    {

        [DisplayName("Step Name")]
        public string Name { get; set; }

        [DisplayName("Description")]
        public string Description { get; set; }

        [DisplayName("Step Work Name")]
        public long AssembleWorkStepId { get; set; }

        [DisplayName("Step Work Name")]
        public string AssembleWorkStepName { get; set; }

        [DisplayName("Work Category")]
        public long AssembleWorkCategoryId { get; set; }

        [DisplayName("Work Category")]
        public string AssembleWorkCategoryName { get; set; }
        
    }
}
