using app.EntityModel.DataTableSearchModels;

namespace app.Services.ATMAssemble.AssembleWorkStepItemServices
{
    public class AssembleWorkStepItemSearchDto : BaseDataTableSearch
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public long AssembleWorkStepId { get; set; }
        public string AssembleWorkStepName { get; set; }
        public long AssembleWorkCategoryId { get; set; }
        public string AssembleWorkCategoryName { get; set; }
        
    }
}
