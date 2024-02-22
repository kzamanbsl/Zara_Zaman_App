
using app.EntityModel.DataTableSearchModels;
using app.Services.ATMAssemble.AssembleWorkStepItemServices;

namespace app.Services.ATMAssemble.AssembleWorkStepServices
{
    public class AssembleWorkStepSearchDto : BaseDataTableSearch
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public long AssembleWorkCategoryId { get; set; }
        public string AssembleWorkCategoryName { get; set; }
      
    }
}
