using app.EntityModel.DataTableSearchModels;

namespace app.Services.BankServices
{
    public class BankSearchDto: BaseDataTableSearch
    {
        public string Name { get; set; }
       
    }
}
