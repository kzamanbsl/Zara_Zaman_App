using app.EntityModel.DataTableSearchModels;

namespace app.Services.CompanyServices
{
    public class CompanySearchDto : BaseDataTableSearch
    {
        public string Name { get; set; }

    }
}
