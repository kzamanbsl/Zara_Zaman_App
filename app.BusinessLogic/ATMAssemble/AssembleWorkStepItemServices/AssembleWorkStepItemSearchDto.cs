using app.EntityModel.DataTableSearchModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace app.Services.ATMAssemble.AssembleWorkStepItemServices
{
    public class AssembleWorkStepItemSearchDto : BaseDataTableSearch
    {

        [DisplayName("Step Item")]
        public string Name { get; set; }

        [DisplayName("Description")]
        public string Description { get; set; }

        [DisplayName("Work Step")]
        public long AssembleWorkStepId { get; set; }

        [DisplayName("Work Step")]
        public string AssembleWorkStepName { get; set; }

        [DisplayName("Work Category")]
        public long AssembleWorkCategoryId { get; set; }

        [DisplayName("Work Category")]
        public string AssembleWorkCategoryName { get; set; }
        
    }
}
