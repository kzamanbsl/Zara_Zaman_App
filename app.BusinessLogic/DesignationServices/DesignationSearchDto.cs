using app.EntityModel;
using app.EntityModel.DataTableSearchModels;

namespace app.Services.DesignationServices
{
    public class DesignationSearchDto: BaseDataTableSearch
    {
        public string Name { get; set; }

        public string DeleteReasion { get; set; }
        public string Remarks { get; set; }
    }
}
