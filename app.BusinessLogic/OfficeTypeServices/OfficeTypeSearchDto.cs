using app.EntityModel;
using app.EntityModel.DataTableSearchModels;

namespace app.Services.OfficeTypeServices
{
    public class OfficeTypeSearchDto : BaseDataTableSearch
    {
        public string Name { get; set; }

    }
}
