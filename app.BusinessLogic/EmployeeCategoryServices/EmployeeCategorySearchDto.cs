using app.EntityModel;
using app.EntityModel.DataTableSearchModels;

namespace app.Services.EmployeeCategoryServices
{
    public class EmployeeCategorySearchDto: BaseDataTableSearch
    {
        public string Name { get; set; }
    }
}
