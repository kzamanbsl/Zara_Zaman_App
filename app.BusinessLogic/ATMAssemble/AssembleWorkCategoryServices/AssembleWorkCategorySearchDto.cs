using app.EntityModel.DataTableSearchModels;

namespace app.Services.ATMAssemble.AssembleWorkCategoryServices
{
    public class AssembleWorkCategorySearchDto : BaseDataTableSearch
    {
        public string Name { get; set; }
        public string Description { get; set; }
      
    }
}
