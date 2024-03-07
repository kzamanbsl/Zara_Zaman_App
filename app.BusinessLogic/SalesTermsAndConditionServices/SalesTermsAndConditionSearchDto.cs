using app.EntityModel.DataTableSearchModels;

namespace app.Services.SalesTermsAndConditonServices
{
    public class SalesTermsAndConditionSearchDto : BaseDataTableSearch
    {
        public string Key { get; set; }
        public string Value { get; set; }
       
    }
}
